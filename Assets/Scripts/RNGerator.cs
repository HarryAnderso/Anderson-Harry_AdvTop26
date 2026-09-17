using Unity.VisualScripting;
using UnityEngine;

public class RNGerator : MonoBehaviour
{
    public Material[] materials;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int heightvalue = Random.Range(0, 3);
        Debug.Log(heightvalue);
        GetComponent<MeshRenderer>().material = materials[heightvalue];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
