using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationController : MonoBehaviour {

	private SerialListener serialListner;
	private GameObject serialController;
	private Quaternion rbTransform;


	// Use this for initialization
	void Start() {
		serialController = GameObject.Find("SerialController");
		serialListner = serialController.GetComponent<SerialListener>();
	}

	// Update is called once per frame
	void FixedUpdate() {

		// transform.eulerAngles = serialListner.e;		//euler angles
		transform.rotation = serialListner.q;					//quaternion 

	}
}
