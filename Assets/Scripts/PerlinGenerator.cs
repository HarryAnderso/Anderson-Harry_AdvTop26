using System.Runtime.CompilerServices;
using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material[] materials;
    int details = 0;
    void Start()
    {
        float xPos = transform.position.x +.1f;
        float zPos = transform.position.z +.1f;

        float f = Mathf.PerlinNoise(xPos, zPos);
        float t = Mathf.PerlinNoise(xPos + 1000f, zPos + 1000f);
       


        if (f < .4)
        {

            details = 0;

        }
        else if (f < .5)
        {
            //GetComponent<MeshRenderer>().material = materials[1];
            details = 10;
            Vector3 scaleChange = new Vector3(1, (1.5f+f), 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y + .25f + (f * 0.5f), transform.position.z);
            temp(t);
        }
        else
        {
            //GetComponent<MeshRenderer>().material = materials[2];
            details = 20;
            Vector3 scaleChange = new Vector3(1, (2f+f), 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y +.5f + (f * 0.5f), transform.position.z);
            temp(t);
        }

        switch (details)
        {

            case 0:
                GetComponent<MeshRenderer>().material = materials[0]; break;
            case 10:
                GetComponent<MeshRenderer>().material = materials[1]; break;
            case 11:
                GetComponent<MeshRenderer>().material = materials[2]; break;
            case 12:
                GetComponent<MeshRenderer>().material = materials[3]; break;
            case 20:
                GetComponent<MeshRenderer>().material = materials[4]; break;
            case 21:
                GetComponent<MeshRenderer>().material = materials[5]; break;
            case 22:
                GetComponent<MeshRenderer>().material = materials[6]; break;
        }
        
        
        
    }
    public void temp(float t)
    {
        if (t < .4)
        {

            details += 1;

        }
        else if (t < .5)
        {
            
            details += 2;
           
        }
    }


}
