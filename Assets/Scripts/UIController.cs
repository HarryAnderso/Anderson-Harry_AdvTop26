using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class UIController : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public GameObject Head;
    public GameObject Arms;
    public GameObject Body;
    public GameObject Legs;

    private Vector3 lastposition = Vector3.zero;
    private Vector3 currentposition = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //thing.GetComponent<UnityEngine.UI.Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ArrowReset();
            upArrow.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            Head.GetComponent<Health>().TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ArrowReset();
            downArrow.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            Legs.GetComponent<Health>().TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ArrowReset();
            leftArrow.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            Arms.GetComponent<Health>().TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ArrowReset();
            rightArrow.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            Body.GetComponent<Health>().TakeDamage(10);

        }

        lastposition = currentposition;
        currentposition = Input.mousePosition;



    }
    void ArrowReset ()
    {
        upArrow.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        downArrow.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        leftArrow.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        rightArrow.GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }

    
}

//txt.GetComponent<TMP_Text>().text = txt.text;
//txt.text = "Shuriken: " + shcount;
