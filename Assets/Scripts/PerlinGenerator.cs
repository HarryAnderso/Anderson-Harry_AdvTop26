using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class PerlinGenerator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Material[] materials;

    [SerializeField]
    private TMP_Text tooltip;
    
    int details = 0;
    [Header("Perlin Noise Settings")]
    [SerializeField]
    private float xPos;
    [SerializeField]
    private float zPos;
    [SerializeField]
    private float heightP;
    [SerializeField]
    private float tempP;
    [SerializeField]
    private float fertP;
    [SerializeField]
    private float moistureP;
    //[SerializeField]
    public float textTimer ;
    [SerializeField]
     Boolean textActive = false;

    


    void Start()
    {

        Canvas canvas = FindAnyObjectByType<Canvas>();
        if (canvas != null)
        {
            tooltip = canvas.GetComponentInChildren<TMP_Text>();
        }
        else
        {
            Debug.LogError("Canvas not found in the scene.");
        }

        
       

        xPos = transform.position.x + .1f;
         zPos = transform.position.z + .1f;

        heightP = Mathf.PerlinNoise(xPos, zPos);
        tempP = Mathf.PerlinNoise(xPos + 1000f, zPos + 1000f);
        fertP = Mathf.PerlinNoise(xPos + 500f, zPos + 500f);
        moistureP = Mathf.PerlinNoise(xPos + 2000f, zPos + 2000f);



        if (heightP < .4)
        {

            details = 0;

        }
        else if (heightP < .5)
        {
            //GetComponent<MeshRenderer>().material = materials[1];
            details = 10;
            Vector3 scaleChange = new Vector3(1, (1.5f+heightP), 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y + .25f + (heightP * 0.5f), transform.position.z);
            SetTemp(tempP);
            SetFertility(fertP);
            SetMoisture(moistureP);
        }
        else
        {
            //GetComponent<MeshRenderer>().material = materials[2];
            details = 20;
            Vector3 scaleChange = new Vector3(1, (2f+heightP), 1);
            transform.localScale = scaleChange;
            transform.position = new Vector3(transform.position.x, transform.position.y +.5f + (heightP * 0.5f), transform.position.z);
            SetTemp(tempP);
            SetFertility(fertP);
            SetMoisture(moistureP);
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

    public void Update()
    {
        if (textActive) {textTimer += Time.deltaTime; }

        if (textTimer >= .5f)
        {
            textActive = false;
            //tooltip.text = "";
            textTimer = 0f;
            ToolTipTextChange();
        }
    }
    public void SetTemp(float t)
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

    public void SetFertility(float t)
    {
        if (t < .4)
        {

            //details += 1;

        }
        else if (t < .5)
        {

           //details += 2;

        }
    }

    public void SetMoisture(float t)
    {
        if (t < .4)
        {

            //details += 1;

        }
        else if (t < .5)
        {

            //details += 2;

        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       
        textActive = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        tooltip.text = "";
    }

    public void ToolTipTextChange()
    {
        tooltip.text = "Height: " + transform.localScale.y.ToString("F2") + "(" + heightP.ToString("F2") + ")" + "\n" + "Temperature: " + tempP.ToString("F2") + "\n" + "Fertility: " + fertP.ToString("F2") + "\n" + "Moisture: " + moistureP.ToString("F2");
    }


}
