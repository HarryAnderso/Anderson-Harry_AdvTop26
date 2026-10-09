using UnityEngine;

public class ToolTipScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = 0;
        cursorPos.x += 150; // Offset to the right
        cursorPos.y -= 50; //Offset upwards
        transform.position = cursorPos;
    }
}
