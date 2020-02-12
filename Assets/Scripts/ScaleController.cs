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
        input.text = gameManager.Scale.ToString();
    }
}
