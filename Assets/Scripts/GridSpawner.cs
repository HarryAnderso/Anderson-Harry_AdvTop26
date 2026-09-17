using UnityEngine;

public class GridSpawner : MonoBehaviour
{
     public GameObject TileFab;
    [Header("Grid Size Input")]
    public int Width = 10;
    public int length = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Instantiate(TileFab, new Vector3(j, 0, i), Quaternion.identity);
              
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
