using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthbar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider objHealthBar;
    public EnemyBehaviour objHealth;

    public TextMeshProUGUI HealthV;

    private void Awake()
    {
        //    enemyHealth =  FindAnyObjectByType<Health>();
    }

    void Start()
    {
        objHealthBar.maxValue = objHealth.enemyMax;
    }

    // Update is called once per frame
    void Update()
    {
        objHealthBar.value = objHealth.enemyHealth;
        HealthV.text = objHealth.enemyHealth.ToString();


    }


}
