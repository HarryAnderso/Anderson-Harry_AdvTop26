using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1f;
    public float SprintSensitivity = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * sensitivity;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * Time.deltaTime * sensitivity;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * Time.deltaTime * sensitivity;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * sensitivity;
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.position += Vector3.up * Time.deltaTime * sensitivity;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += Vector3.down * Time.deltaTime * sensitivity;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sensitivity = sensitivity * SprintSensitivity;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            sensitivity = sensitivity / SprintSensitivity;
        }
    }
}
