using System.IO;
using UnityEngine;

public class DataSaverJSON : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }


    public void Update()
    {
        SaveData();
    }

    public void SaveData() 
    {
        string json = JsonUtility.ToJson(gameManager);

        Debug.Log(json);

        using (StreamWriter writer = new StreamWriter(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.Json")) {


            writer.Write(json);
        
        }
    }

    public void LoadData() 
    {
        string json = string.Empty;


            using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.Json")) 
        {

            json = reader.ReadToEnd();
            
        
        
        }


        GameManager tempgamemanager = JsonUtility.FromJson<GameManager>(json);

        gameManager.setHighscore(tempgamemanager.highScore);

    }

}
