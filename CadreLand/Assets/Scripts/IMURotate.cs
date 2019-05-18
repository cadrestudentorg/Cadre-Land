using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMURotate : MonoBehaviour
{

    //https://docs.unity3d.com/ScriptReference/Transform-rotation.html
    // Assign an absolute rotation using eulerAngles
    // float xRotation = 0f;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Start()
    {
        /*
        // Print the rotation around the global X Axis
        print(transform.eulerAngles.x);
        // Print the rotation around the global Y Axis
        print(transform.eulerAngles.y);
        // Print the rotation around the global Z Axis
        print(transform.eulerAngles.z);
        */
    }

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
       // float tiltAroundZ = IMUManager.inst.getImuDataX() * tiltAngle;
      //  float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
       // Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        //  transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        transform.Rotate(

           // Input.GetAxis("Horizontal")
           //  xRotation += IMUManager.inst.getImuDataX();
           //  transform.eulerAngles = new Vector3(xRotation, 0, 0);

           // Quaternion rotation = Quaternion.Euler(new Vector3(xRotation, 0, 0));

           IMUManager.inst.getImuDataY() * Time.deltaTime,
          IMUManager.inst.getImuDataX() * Time.deltaTime,
          IMUManager.inst.getImuDataZ() * Time.deltaTime);
    }
}
