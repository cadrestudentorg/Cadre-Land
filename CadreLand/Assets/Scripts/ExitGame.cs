﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
