using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private UIController controller;

    private Slider slider;
    private Text percentage;
    private Toggle toggle;

    private void Awake()
    {
        controller = GameObject.Find("GameManager").GetComponent<UIController>();

        slider = transform.Find("Slider").GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(slider.value); });

        toggle = transform.Find("Toggle").GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle.isOn); });

        percentage = transform.Find("Percentage").GetComponent<Text>();
    }

    private void OnSliderValueChanged(float value)
    {
        percentage.text = (value * 100) + "%";
    }

    private void OnToggleValueChanged(bool value)
    {

    }

    public float GetSliderValue()
    {
        return slider.value;
    }

    public void SetSliderValue(float value)
    {
        slider.value = value;
    }

    public bool GetToggleValue()
    {
        return toggle.isOn;
    }

    public void SetToggleValue(bool value)
    {
        toggle.isOn = value;
    }
}
