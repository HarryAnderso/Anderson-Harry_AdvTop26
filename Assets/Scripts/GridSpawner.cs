using UnityEngine;
using System.Collections.Generic;

public class GridSpawner : MonoBehaviour
{
     public GameObject TileFab;
    [Header("Grid Size Input")]
    public int Width = 10;
    public int length = 10;
    [Header("Perlin Parameters")]
    public float perlinScale = 1.0f;
    public float perlinOffset = 0.0f;
    public float MountainCutoff = 0.5f;
    public float SeaCutoff = 0.4f;
    public float hotCutoff = 0.5f;
    public float coldCutoff = 0.4f;

    private float highest =0;
    private float lowest =1;
    private float temp;

    public List<GameObject> tileList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach(GameObject tile in tileList)
            {
                Destroy(tile);
            }
            tileList.Clear();
            Generate();

            
        }

        if (Input.GetKeyDown(KeyCode.A)) analyize();
    }

    public void Generate()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                //Instantiate(TileFab, new Vector3(j, 0, i), Quaternion.identity);
                GameObject newtile = Instantiate(TileFab, new Vector3(j, 0, i), Quaternion.identity);
                tileList.Add(newtile);
                newtile.GetComponent<PerlinGenerator>().perlinseed = perlinOffset;
                newtile.GetComponent<PerlinGenerator>().perlinScale = perlinScale;
                newtile.GetComponent<PerlinGenerator>().MountainCutoff = MountainCutoff;
                newtile.GetComponent<PerlinGenerator>().SeaCutoff = SeaCutoff;
                newtile.GetComponent<PerlinGenerator>().hotCutoff = hotCutoff;
                newtile.GetComponent<PerlinGenerator>().coldCutoff = coldCutoff;

            }
        }
    }

    public void analyize()
    {
        foreach (GameObject tile in tileList)
        {
            temp = tile.GetComponent<PerlinGenerator>().heightP; 

            if (temp > highest)
            {
                highest = temp;
            }

            if (temp < lowest)
            {
                lowest = temp;
            }
        }

        Debug.Log("Highest: " + highest + ", Lowest: " + lowest);
    }
}
