using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class IMUManager : MonoBehaviour
{

    public static SerialPort sp;
    public static IMUManager inst;

    float timePassed = 0.0f;
    string whichPlatform = "win";
    public string rawStrIn;
    float dataX = 0.0f;
    float dataY = 0.0f;
    float dataZ = 0.0f;

    void Awake()
    {
        inst = this;
        // print("Awake -- " + gdata);

        if (RuntimePlatform.OSXEditor == Application.platform)
        {
            print("Mac platform");
            whichPlatform = "mac";
        }

        if (RuntimePlatform.WindowsEditor == Application.platform)
        {
            print("Win platform");
            whichPlatform = "win";
        }




    }

    //Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;

        string wp = this.getPlatform();

        if (wp == "mac")
        {
            sp = new SerialPort("/dev/cu.usbserial-ADAPDELcm", 115200, Parity.None, 8, StopBits.One);
            // sp = new SerialPort("/dev/cu.usbserial-ADAPDELcm", 115200);
            print("MAC port being opened");
        }

        if (wp == "win")
        {
            sp = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            print("WIN port being opened");
        }


        OpenConnection();

    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;
        if (timePassed >= 0.02f)
        {

            rawStrIn = sp.ReadLine();
            string[] dataStr = rawStrIn.Split(':');
            string[] xyzStr = dataStr[1].Split('\t');
            float[] nums = System.Array.ConvertAll(dataStr[1].Split('\t'), float.Parse);

            dataX = nums[0];

            if (dataX > 180)
            {
                dataX = -360 + dataX;
            }

            dataY = -nums[1];
            dataZ = nums[2];

            print(dataX + " \t " + dataY + " \t " + dataZ);

            timePassed = 0.0f;

        }
    }


    string getPlatform()
    {
        print("platform is" + whichPlatform);
        return whichPlatform;
    }

    public float getImuDataX()
    {
        //  print("GetIMU " + dataX);
        return dataX;
    }
    public float getImuDataY()
    {
        //  print("GetIMU " + dataX);
        return dataY;
    }
    public float getImuDataZ()
    {
        //  print("GetIMU " + dataX);
        return dataZ;
    }


    void setImuDataX(float d)
    {
        dataX = d;
        //print("SetIMU " + gdata);
    }


    void displayImuData()
    {
        GUI.Label(new Rect(10, 5, 100, 100), "dataX: " + getImuDataX());
        GUI.Label(new Rect(10, 20, 100, 100), "dataY: " + getImuDataY());
        GUI.Label(new Rect(10, 35, 100, 100), "dataZ: " + getImuDataZ());

    }


    void OnGUI()
    {
        displayImuData();
    }


    void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 16;  //16 sets the timeout value before reporting error
                print("Port Opened!");
                //		message = "Port Opened!";
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }



}
