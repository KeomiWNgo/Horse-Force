using UnityEngine;
using TMPro;

public class Numbers : MonoBehaviour
{
    private AttackButton atkref;
    public TextMeshProUGUI number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atkref = FindAnyObjectByType<AttackButton>();
    }

    // Update is called once per frame
    void Update()
    {
        number.text = ( Mathf.Clamp(( 5 - atkref.GetCooldown()),0,10)).ToString();
    }
}
