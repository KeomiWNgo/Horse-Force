using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider enemyHealthBar;
    public Health enemyHealth;

    private void Awake()
    {
    //    enemyHealth =  FindAnyObjectByType<Health>();
    }

    void Start()
    {
        enemyHealthBar.maxValue = enemyHealth.maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.value = enemyHealth.currhealth;
    }
}
