using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthbar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider objHealthBar;
    public EnemyBehaviour objHealth;
    public TextMeshProUGUI HealthV;

    /// <summary>
    /// Assigns the newly spawned enemy to the health bar
    /// </summary>
    /// <param name="newEnemy"></param>
    public void SetEnemy(EnemyBehaviour newEnemy)
    {
        objHealth = newEnemy;

        //set slider max value to enemy max health
        objHealthBar.maxValue = objHealth.enemyMax;

        //updates immediately
        UpdateHealthBar();
    }
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
        UpdateHealthBar();
    }

    //update bar and text to match current health
    void UpdateHealthBar()
    {
        if(objHealth == null || objHealthBar == null || HealthV == null)
            return;

        objHealthBar.value = objHealth.enemyHealth;
        HealthV.text = objHealth.enemyHealth.ToString();
    }
}
