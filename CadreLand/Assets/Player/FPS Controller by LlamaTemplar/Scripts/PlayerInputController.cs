using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}
	
	// Update is called once per frame
	void Update ()
    {
		
		if (Cursor.visible && Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		/*
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		*/
	}
}
