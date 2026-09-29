using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    public int maxhealth;
    public int currhealth { get; private set; }

    void Start()
    {
        currhealth = maxhealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        currhealth--;
    }
}
