using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material[] materials;
    void Start()
    {
        float xPos = transform.position.x +.1f;
        float zPos = transform.position.z +.1f;

        float f = Mathf.PerlinNoise(xPos, zPos);

        if (f < .4)
        {
            GetComponent<MeshRenderer>().material = materials[0];
           

        }
        else if (f < .5)
        {
            GetComponent<MeshRenderer>().material = materials[1];
            Vector3 scaleChange = new Vector3(1, 1.5f, 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z);
        }
        else
        {
            GetComponent<MeshRenderer>().material = materials[2];
            Vector3 scaleChange = new Vector3(1, 2f, 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y +.5f, transform.position.z);
        }

            //Debug.Log(f + ", " + transform.position.x + ", " + transform.position.z);
    }


}
