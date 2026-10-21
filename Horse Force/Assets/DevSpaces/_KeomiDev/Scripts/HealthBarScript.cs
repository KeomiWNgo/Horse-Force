using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Slider objHealthBar;
    public Health objHealth;

    public TextMeshProUGUI HealthV;

    private void Awake()
    {
    //    enemyHealth =  FindAnyObjectByType<Health>();
    }

    void Start()
    {
        objHealthBar.maxValue = objHealth.maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        objHealthBar.value = objHealth.currhealth;
        HealthV.text = objHealth.currhealth.ToString();


    }


}
