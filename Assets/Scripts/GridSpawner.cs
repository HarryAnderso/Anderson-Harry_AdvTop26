using UnityEngine;
using System.Collections.Generic;

public class GridSpawner : MonoBehaviour
{
     public GameObject TileFab;
    [Header("Grid Size Input")]
    public int Width = 10;
    public int length = 10;

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
            }
        }
    }
}
