using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainGenerator :  GridSpawner 
{

  
    
    
    public float scale = 45.0f;

    public float heightmultiplier = 1.0f;

    private Terrain terrain;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        terrain = GetComponent<Terrain>();
        //GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            GenerateTerrain();  
        }
    }

    void GenerateTerrain()
    {
        //Debug.Log("f");
        float[,] heights = new float[width, length];

        if(tileList.Count == 0)
        {
            Debug.Log("Fuck");
        }
        foreach (GameObject tile in tileList)
        {
            Debug.Log("f");
            //float xCoord = (tile.transform.position.x + perlinOffset) / scale;
            //float zCoord = (tile.transform.position.z + perlinOffset) / scale;
            float xCoord = tile.transform.position.x;
            float zCoord = tile.transform.position.z;
            Debug.Log(xCoord + " " + zCoord);
            //float sample = noise.snoise(new float2(xCoord, zCoord));
            float sample = Mathf.PerlinNoise(xCoord, zCoord);
            //int2 currentlocation = new int2((int)xCoord, (int)zCoord);
            heights[(int)xCoord, (int)zCoord] = sample * heightmultiplier;
        }
        

        terrain.terrainData.SetHeights(0, 0, heights);
    }
}
