using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObj : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
=======
	[SerializeField] bool isBeingHeld = false;
>>>>>>> parent of a0e7bb4... updated placeableobj
	[SerializeField] bool canRelease = false;
=======
	[SerializeField] bool isBeingHeld = false;
	[SerializeField] bool canRelease = true;
>>>>>>> parent of 947e0b3... Intergated PlaceableObj with VRTK
	[SerializeField] float buildSpeed = 50;
	Vector3 Anchor;
	Quaternion AnchorRotation;
	Rigidbody rigbdy;

	void Start()
	{
		rigbdy = GetComponent<Rigidbody>();
		rigbdy.useGravity = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (isBeingHeld)
		{
			//Check ground below
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10000))
			{
				// set Anchor to snap to when object reaches the ground
				if (hit.transform.tag == "Land")
				{
					canRelease = true;
					Anchor = hit.point + new Vector3(0, transform.localScale.x / 2.5f, 0);
					//-print("Anchor = " + Anchor);
				}
				else // obj is not above cadre land
				{
					canRelease = false;
				}

			}
		}
	}
	
	public void GrabObject(GameObject GrabParent)
	{
		this.transform.parent = GrabParent.transform;
		isBeingHeld = true;
	}

	[ContextMenu("Release")]
	public bool ReleaseObject()
	{
		if (canRelease)
		{
			this.transform.parent = null;
			AnchorRotation = this.transform.rotation;
			isBeingHeld = false;
			rigbdy.AddForce(Vector3.down * buildSpeed * 1000);
			//rigbdy.useGravity = true;

			return true;
		}
		else
			return false; // didn't drop the obj on the land
	}

	// snap to ground
	void OnCollisionEnter(Collision collision)
	{
		transform.position = Anchor;
		transform.rotation = AnchorRotation;
		rigbdy.isKinematic = true;
	}
}
