using UnityEngine;

public class RNGerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int num = Random.Range(1, 4);
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        //meshRenderer.material = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
