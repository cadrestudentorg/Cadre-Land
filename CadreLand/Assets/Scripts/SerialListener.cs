using System;
using UnityEngine;
using System.Collections;


public class SerialListener : MonoBehaviour {

  private string[] list = new string[9];

  public float pot;
  public Boolean button1 = false;
  public Boolean button2 = false;
  public Vector3 e;
  public Quaternion q;

  // Invoked when a line of data is received from the serial device.
  void OnMessageArrived(string msg) {
    float heading;
    float pitch;
    float roll;
    float qw;
    float qx;
    float qy;
    float qz;
    int btn1;
    int btn2;

    list = msg.Split(' ');
    if(list.Length > 1) {
      heading = float.Parse(list[0]);
      pitch = float.Parse(list[1]);
      roll = float.Parse(list[2]);
      qw = float.Parse(list[3]);
      qx = float.Parse(list[4]);
      qy = float.Parse(list[5]);
      qz = float.Parse(list[6]);
      pot = float.Parse(list[7]);
      btn1 = int.Parse(list[8]);
      btn2 = int.Parse(list[9]);
      e = new Vector3(pitch, heading, roll);
      q = new Quaternion(qx, qy, qz, qw);
      button1 = btn1 != 0;
      button2 = btn2 != 0;
    }


    // Debug.Log("Message arrived: " + msg);
  }

  // Invoked when a connect/disconnect event occurs. The parameter 'success'
  // will be 'true' upon connection, and 'false' upon disconnection or
  // failure to connect.
  void OnConnectionEvent(bool success) {
    if(success)
      Debug.Log("Connection established");
    else
      Debug.Log("Connection attempt failed or disconnection detected");
  }
}
