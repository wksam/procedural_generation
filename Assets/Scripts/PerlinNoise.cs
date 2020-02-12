using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerlinNoise : MonoBehaviour
{
    public GameObject square;
    int width;
    int height;
    GameObject[,] tiles;
    public Button btnChange;

    public float Scale { get; set; }

    public int SeedX { get; set; }
    public int SeedY { get; set; }

    public float WaterPercentage { get; set; }
    public float SandPercentage { get; set; }
    public float GrassPercentage { get; set; }
    public float ForestPercentage { get; set; }
    public float MountainPercentage { get; set; }

    private void Awake()
    {
        Scale = 0.1f;
        SeedX = 499999;
        SeedY = 499999;
        WaterPercentage = 0.2f;
        SandPercentage = 0.1f;
        GrassPercentage = 0.3f;
        ForestPercentage = 0.2f;
        MountainPercentage = 0.2f;
    }

    void Start()
    {
        Button btn = btnChange.GetComponent<Button>();
        btn.onClick.AddListener(GenerateMap);

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        width = Mathf.CeilToInt(screenBounds.x);
        height = Mathf.CeilToInt(screenBounds.y);

        tiles = new GameObject[(width * 2) + 1, (height * 2) + 1];

        int x = 0;
        int y = 0;
        for (int i = -width; i <= width; i++)
        {
            for (int j = -height; j <= height; j++)
            {
                tiles[x, y] = Instantiate(square, new Vector2(i, j), Quaternion.identity);
                y++;
            }
            y = 0;
            x++;
        }

        GenerateMap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GenerateMap();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SeedY += 1;
            GenerateMap();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SeedY -= 1;
            GenerateMap();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SeedX += 1;
            GenerateMap();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SeedX -= 1;
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        for (int i = 0; i < (width * 2) + 1; i++)
        {
            for (int j = 0; j < (height * 2) + 1; j++)
            {
                tiles[i, j].GetComponent<SpriteRenderer>().color = GetColor(Mathf.PerlinNoise((i * Scale) + SeedX, (j * Scale) + SeedY));
            }
        }
    }

    Color GetColor(float noise, bool grayscale = false)
    {
        float wp = WaterPercentage;
        float sp = wp + SandPercentage;
        float gp = sp + GrassPercentage;
        float fp = gp + ForestPercentage;
        float mp = fp + MountainPercentage;

        if (mp != 1) return Color.white;

        if (grayscale)
        {
            return new Color(noise, noise, noise);
        }
        else
        {
            if (noise < wp)
            { // Water
                return new Color32(182, 227, 219, 255);
            }
            else if (noise < sp)
            { // Sand
                return new Color32(229, 217, 194, 255);
            }
            else if (noise < gp)
            { // Grass
                return new Color32(181, 186, 97, 255);
            }
            else if (noise < fp)
            { // Forest
                return new Color32(124, 141, 76, 255);
            }
            else
            { // Montain
                return new Color32(114, 84, 40, 255);
            }
        }
    }
}
