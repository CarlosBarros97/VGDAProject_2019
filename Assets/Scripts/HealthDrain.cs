﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthDrain : MonoBehaviour
{
    public float HealthMax = 100.0f;
    Text HealthDisplay;
    
    public float HealthValue = 0.0f;
    public float DecayRate = 10f; //How fast health decreases
    void Start()
    {
        HealthDisplay = GetComponent<Text>();
        HealthValue = HealthMax; 
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = "HP: " + Mathf.Round(HealthValue);
        HealthValue -= HealthMax * Time.deltaTime / DecayRate; //HealthValue = HealthValue - HealthMax * Time.deltaTime / DecayRate;

        if(HealthValue <= 0)
        {
            HealthValue = 0;
            SceneManager.LoadScene("GameOver");
        }
    }


}
