using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas main;
    public Canvas menu;

    private SliderController waterSlider;
    private SliderController sandSlider;
    private SliderController grassSlider;
    private SliderController forestSlider;
    private SliderController mountainSlider;

    private PerlinNoise gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PerlinNoise>();
        waterSlider = GameObject.Find("WaterSlider").GetComponent<SliderController>();
        sandSlider = GameObject.Find("SandSlider").GetComponent<SliderController>();
        grassSlider = GameObject.Find("GrassSlider").GetComponent<SliderController>();
        forestSlider = GameObject.Find("ForestSlider").GetComponent<SliderController>();
        mountainSlider = GameObject.Find("MountainSlider").GetComponent<SliderController>();

        main.enabled = true;
        menu.enabled = false;
    }

    private void Start()
    {
        InitValues();
    }

    public void OnOpenMenu()
    {
        menu.enabled = true;
        main.enabled = false;
    }

    public void OnCancel()
    {
        main.enabled = true;
        menu.enabled = false;
    }

    public void OnChange()
    {
        main.enabled = true;
        menu.enabled = false;
    }

    private void InitValues()
    {
        waterSlider.SetSliderValue(gameManager.WaterPercentage);
        waterSlider.SetToggleValue(gameManager.WaterIsLocked);
        sandSlider.SetSliderValue(gameManager.SandPercentage);
        sandSlider.SetToggleValue(gameManager.SandIsLocked);
        grassSlider.SetSliderValue(gameManager.GrassPercentage);
        grassSlider.SetToggleValue(gameManager.GrassIsLocked);
        forestSlider.SetSliderValue(gameManager.ForestPercentage);
        forestSlider.SetToggleValue(gameManager.ForestIsLocked);
        mountainSlider.SetSliderValue(gameManager.MountainPercentage);
        mountainSlider.SetToggleValue(gameManager.MountainIsLocked);
    }

}
