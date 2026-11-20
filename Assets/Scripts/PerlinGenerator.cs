using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class PerlinGenerator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    enum Environment
    {
        Level_hot,
        Level_normal,
        Level_cold,
        Mountain_hot,
        Mountain_normal,
        Mountain_cold,
        Sea,
    }
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

    public float perlinseed = 0f;
    public float perlinScale = 1.0f;

    [Header("Environment Paramaters")]
    [SerializeField]
    Environment localenvironment;
    public float MountainCutoff = 0.5f;
    public float SeaCutoff = 0.4f;
    public float hotCutoff = 0.5f;
    public float coldCutoff = 0.4f;




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

        
       

        //xPos = transform.position.x + .1f;
        //zPos = transform.position.z + .1f;

        //heightP = Mathf.PerlinNoise(xPos, zPos);
        //tempP = Mathf.PerlinNoise(xPos + 1000f, zPos + 1000f);
        //fertP = Mathf.PerlinNoise(xPos + 500f, zPos + 500f);
        //moistureP = Mathf.PerlinNoise(xPos + 2000f, zPos + 2000f);
        initalize();



        if (heightP < .4)
        {

            details = 0;
            localenvironment = Environment.Sea;

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
            SetEnvironment();
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
            SetEnvironment();
        }

        //switch (details)
        //{

        //    case 0:
        //        GetComponent<MeshRenderer>().material = materials[0]; break;
        //    case 10:
        //        GetComponent<MeshRenderer>().material = materials[1]; break;
        //    case 11:
        //        GetComponent<MeshRenderer>().material = materials[2]; break;
        //    case 12:
        //        GetComponent<MeshRenderer>().material = materials[3]; break;
        //    case 20:
        //        GetComponent<MeshRenderer>().material = materials[4]; break;
        //    case 21:
        //        GetComponent<MeshRenderer>().material = materials[5]; break;
        //    case 22:
        //        GetComponent<MeshRenderer>().material = materials[6]; break;
        //}

        switch(localenvironment)
        {
            case Environment.Sea:
                GetComponent<MeshRenderer>().material = materials[0]; break;
            case Environment.Level_cold:
                GetComponent<MeshRenderer>().material = materials[1]; break;
            case Environment.Level_normal:
                GetComponent<MeshRenderer>().material = materials[2]; break;
            case Environment.Level_hot:
                GetComponent<MeshRenderer>().material = materials[3]; break;
            case Environment.Mountain_cold:
                GetComponent<MeshRenderer>().material = materials[4]; break;
            case Environment.Mountain_normal:
                GetComponent<MeshRenderer>().material = materials[5]; break;
            case Environment.Mountain_hot:
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

    public void SetEnvironment()
    {
        if(tempP<coldCutoff)
        {
            if(heightP < MountainCutoff)
            {
                localenvironment = Environment.Level_cold;
                details += 1;
            }
            else if (heightP > MountainCutoff)
            {
                localenvironment = Environment.Mountain_cold;
                details += 2;
            }
        }
        else if (tempP < hotCutoff)
        {
            if (heightP < MountainCutoff)
            {
                localenvironment = Environment.Level_normal;
                details += 1;
            }
            else if (heightP > MountainCutoff)
            {
                localenvironment = Environment.Mountain_normal;
                details += 2;
            }
        }
        else
        {
            if (heightP < MountainCutoff)
            {
                localenvironment = Environment.Level_hot;
                details += 1;
            }
            else if (heightP > MountainCutoff)
            {
                localenvironment = Environment.Mountain_hot;
                details += 2;
            }
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

    public void initalize()
    {
        xPos = transform.position.x + .1f;
        zPos = transform.position.z + .1f;

        heightP = Mathf.PerlinNoise(xPos, zPos);
        tempP = Mathf.PerlinNoise(xPos + 1000f, zPos + 1000f);
        fertP = Mathf.PerlinNoise(xPos + 500f, zPos + 500f);
        moistureP = Mathf.PerlinNoise(xPos + 2000f, zPos + 2000f);
    }


}
