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

        if (name.Contains("X"))
        {
            input.text = gameManager.SeedX.ToString();
        }
        else
        {
            input.text = gameManager.SeedY.ToString();
        }
    }

}
