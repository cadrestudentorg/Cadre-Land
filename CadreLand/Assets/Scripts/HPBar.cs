using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    public float Totalhp;
    public float Currenthp;

    // Use this for initialization
    void Start()
    {
        Currenthp = Totalhp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
