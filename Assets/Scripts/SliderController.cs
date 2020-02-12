using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    PerlinNoise gameManager;
    private Slider slider;
    private Text percentage;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PerlinNoise>();

        slider = transform.Find("Slider").GetComponent<Slider>();
        percentage = transform.Find("Percentage").GetComponent<Text>();
        
        slider.value = GetValue();
        percentage.text = (GetValue() * 100) + "%";
    }

    public void OnValueChanged()
    {
        percentage.text = (float)System.Math.Round(slider.value * 100, 2) + "%";
        SetValue(slider.value);
    }

    private void UpdateValues()
    {
        slider.value = GetValue();
        percentage.text = (GetValue() * 100) + "%";
    }

    private string GetNextSiblingName(string currentName)
    {
        switch (currentName)
        {
            case "WaterSlider":
                return "SandSlider";
            case "SandSlider":
                return "GrassSlider";
            case "GrassSlider":
                return "ForestSlider";
            case "ForestSlider":
                return "MountainSlider";
            case "MountainSlider":
            default:
                return "WaterSlider";
        }
    }

    private float GetValue()
    {
        switch (name)
        {
            case "WaterSlider":
                return gameManager.WaterPercentage;
            case "SandSlider":
                return gameManager.SandPercentage;
            case "GrassSlider":
                return gameManager.GrassPercentage;
            case "ForestSlider":
                return gameManager.ForestPercentage;
            case "MountainSlider":
            default:
                return gameManager.MountainPercentage;
        }
    }

    private void SetValue(float value)
    {
        switch (name)
        {
            case "WaterSlider":
                gameManager.WaterPercentage = value;
                break;
            case "SandSlider":
                gameManager.SandPercentage = value;
                break;
            case "GrassSlider":
                gameManager.GrassPercentage = value;
                break;
            case "ForestSlider":
                gameManager.ForestPercentage = value;
                break;
            case "MountainSlider":
                gameManager.MountainPercentage = value;
                break;
        }
    }
}
