using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    [SerializeField] public Button infoButton;
    [SerializeField] public GameObject infoPanel;
    [SerializeField] public Button closeButton;

    private void Awake()
    {
        infoPanel.SetActive(false);
    }

    public void InfoButtonPress()
    {
        infoPanel.SetActive(true);
    }

    public void InfoButtonResume()
    {
        infoPanel.SetActive(false);
    }
    
}