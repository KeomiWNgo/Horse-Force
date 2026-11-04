using System.IO;
using UnityEngine;

public class DataSaverJSON : MonoBehaviour
{
    /*
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }


    public void Update()
    {
      //  SaveData();
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

        GameManager tempgamemanager = gameManager;

            using (StreamReader reader = new StreamReader(Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.Json")) 
        {

            json = reader.ReadToEnd();
            
        
        
        }


       JsonUtility.FromJsonOverwrite(json, tempgamemanager);

        gameManager.setHighscore(tempgamemanager.highScore);

    }
    */
}
