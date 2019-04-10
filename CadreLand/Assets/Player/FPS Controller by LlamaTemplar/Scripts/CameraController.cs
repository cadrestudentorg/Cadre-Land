using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    //Store enum in axes
    private RotationAxis axes = RotationAxis.MouseY;


    //Sensitivity
    [SerializeField] private float sensHorizontal = 10.0f;
    [SerializeField] private float sensVertical = 10.0f;

    
    private float minimumVert = -90.0f; //Max and min angle for looking up and down
    private float maximumVert = 90.0f;
    private float rotationX = 0;
    private float rotationY = 0;
    private Camera FpsCam;

    private void Start()
    {
        FpsCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate left or righy
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0, Space.Self);

        //record mouse Y input
        rotationY -= Input.GetAxis("Mouse Y") * sensVertical;
        //set limit to vertical rotation
        rotationY = Mathf.Clamp(rotationY, minimumVert, maximumVert);

        //rotate camera vertically
        FpsCam.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);

    }
}
