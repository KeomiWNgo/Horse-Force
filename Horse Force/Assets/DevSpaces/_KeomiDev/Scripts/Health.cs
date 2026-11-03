using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    #region Events

    public delegate void Playerdied();

    public event Playerdied EPlayerDied;

    #endregion

    #region Vars
    [SerializeField]
    public int maxhealth;
    public int currhealth { get;  set; }
    [SerializeField] private int deathSceneIndex = 12; // Scene index to load on death
    private bool isDead = false;
    #endregion

    void Start()
    {
        currhealth = maxhealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (currhealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                EPlayerDied();
            }
            if (gameObject.CompareTag("HasHealthComp"))
            {
                Destroy(gameObject);
                SwitchScene(deathSceneIndex);
            }
        }
    }
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
