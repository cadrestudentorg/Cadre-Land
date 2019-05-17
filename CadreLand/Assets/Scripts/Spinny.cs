using UnityEngine;
using System.Collections;

public class Spinny : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Sending s1 = GameObject.Find();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate x,y,z

        // float tempX = 	IMUManager.inst.getImuDataX();
        // float tempY = 	IMUManager.inst.getImuDataY();
        // float tempZ = 	IMUManager.inst.getImuDataZ();

        transform.Rotate(
                 
                 IMUManager.inst.getImuDataY() * Time.deltaTime,
                 IMUManager.inst.getImuDataX() * Time.deltaTime,
                 IMUManager.inst.getImuDataZ() * Time.deltaTime);
                   
              

        //print(Time.deltaTime);
        //print(transform.rotation.y);
        // transform.Rotate(0,90*Time.deltaTime,0);
        // transform.Rotate(0,0,tempZ*Time.deltaTime);
        // transform.Rotate(tempY*Time.deltaTime,0,tempZ*Time.deltaTime);
        //transform.Rotate(tempY*Time.deltaTime,tempX*Time.deltaTime,tempZ*Time.deltaTime);
        //transform.Rotate(0,temp/10,temp/50);
    }
}
