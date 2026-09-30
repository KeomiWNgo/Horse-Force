using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    public int maxhealth;
    public int currhealth { get;  set; }

    void Start()
    {
        currhealth = maxhealth;

        
    }

    // Update is called once per frame
    void Update()
    {
      //  currhealth--;
    }
}
