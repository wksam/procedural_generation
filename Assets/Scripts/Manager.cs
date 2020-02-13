using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject square;
    private int width;
    private int height;
    private GameObject[,] tiles;
    private GameObject root;
    private RandomNoise randomNoise;

    private void Awake()
    {
        // Solve the problem with dot/comma from float when tried convert to string
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        randomNoise = GetComponent<RandomNoise>();
    }

    private void Start()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        width = Mathf.CeilToInt(screenBounds.x);
        height = Mathf.CeilToInt(screenBounds.y);

        root = new GameObject("Root");
        tiles = new GameObject[(width * 2) + 1, (height * 2) + 1];

        int x = 0;
        int y = 0;
        for (int i = -width; i <= width; i++)
        {
            for (int j = -height; j <= height; j++)
            {
                tiles[x, y] = Instantiate(square, new Vector2(i, j), Quaternion.identity);
                tiles[x, y].transform.parent = root.transform;
                y++;
            }
            y = 0;
            x++;
        }
        randomNoise.GenerateMap(tiles, width, height);
    }
}
