using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoise : MonoBehaviour
{
    public float Scale { get; set; }
    public int SeedX { get; set; }
    public int SeedY { get; set; }


    public void GenerateMap(GameObject[,] tiles, int width, int height)
    {
        for (int i = 0; i < (width * 2) + 1; i++)
        {
            for (int j = 0; j < (height * 2) + 1; j++)
            {
                float value = Random.Range(0f, 1f);
                tiles[i, j].GetComponent<SpriteRenderer>().material.color = new Color(value, value, value);
            }
        }
    }
}
