using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("1")) && (Input.GetKey("2")))
        {

            print("hi");
            Application.Quit();
        }
            if (Input.GetKey("0"))
            {
            print("reset");
            SceneManager.LoadScene("StartMenu");
               // PublicVariables.pigments = -.85f;
               // PublicVarPig.pigmentsCol = 0;
            }

        if (Input.GetKey("8"))
        {
            print("reset");
            SceneManager.LoadScene("VR2.0Island");
            // PublicVariables.pigments = -.85f;
            // PublicVarPig.pigmentsCol = 0;
        }

        if (Input.GetKey("9"))
        {
            print("reset");
            SceneManager.LoadScene("CL_3Gods");
            // PublicVariables.pigments = -.85f;
            // PublicVarPig.pigmentsCol = 0;
        }


    }
}
