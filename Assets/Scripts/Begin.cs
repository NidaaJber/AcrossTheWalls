using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Begin : MonoBehaviour
{
    [SerializeField] GameObject backgroundCanvas;
    [SerializeField] GameObject introCanvas;


    public void OnStartButtonPressed()
    {
        backgroundCanvas.SetActive(false);
        introCanvas.SetActive(false);
    }

}
