using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedController : MonoBehaviour
{
    PerlinNoise gameManager;
    InputField input;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PerlinNoise>();
        input = GetComponent<InputField>();
        UpdateUI();
    }

    public void OnEndEdit(string value)
    {

    }

    public void UpdateUI() => input.text = Value.ToString();

    private float Value => name.ToLower().Contains("x") ? gameManager.SeedX : gameManager.SeedY;

    private void SetValue(int value)
    {
        if (name.ToLower().Contains("x"))
        {
            gameManager.SeedX = value;
        }
        else
        {
            gameManager.SeedY = value;
        }
    }

}
