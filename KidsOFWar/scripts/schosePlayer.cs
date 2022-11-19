using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class schosePlayer : MonoBehaviour
{
   [SerializeField] InputField InputFieldText ;
   [SerializeField] int NumberOfPLayers;
   public int numberOfPLayers { get { return NumberOfPLayers; } }

    private void Start()
    {
        InputFieldText.text = "1";
    }
    private void Update()
    {
        NumberOfPlayerUp();
        NumberOfPlayerDown();
        ChoseNumberOfPlayer();
    }

    public void LoadLvlWithParametr()
    {
        SceneManager.LoadScene(1);
    }
    public void NumberOfPlayerDown()
    {
        if (NumberOfPLayers >= 2) NumberOfPLayers -= 1;
    } 
    public void NumberOfPlayerUp()
    {
        if (NumberOfPLayers <= 4) NumberOfPLayers += 1;
    }
    public void ChoseNumberOfPlayer()
    {   
        InputFieldText.text = NumberOfPLayers.ToString();
    }

}
