using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController : MonoBehaviour
{
    PerlinNoise gameManager;
    InputField input;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PerlinNoise>();
        input = GetComponent<InputField>();
        input.onEndEdit.AddListener(delegate { OnEndEdit(input.text); });
        UpdateUI();
    }

    public void OnEndEdit(string value)
    {
        SetValue(float.Parse(value));
    }

    public void UpdateUI() => input.text = Value.ToString();

    private float Value => gameManager.Scale;

    private void SetValue(float value) => gameManager.Scale = value;
}
