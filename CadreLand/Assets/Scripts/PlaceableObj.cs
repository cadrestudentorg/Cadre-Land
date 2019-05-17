using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlaceableObj : MonoBehaviour
{
	[SerializeField] bool isBeingHeld = false;
	[SerializeField] bool canRelease = false;
	[SerializeField] float buildSpeed = 50;
	Vector3 Anchor;
	Quaternion AnchorRotation;
	Rigidbody rigbdy;
	MeshFilter meshFilter;
	float height;

	VRTK_InteractableObject interactable;

	void Start()
	{
		rigbdy = GetComponent<Rigidbody>();
		rigbdy.useGravity = false;
		interactable = GetComponent<VRTK_InteractableObject>();
		meshFilter = GetComponent<MeshFilter>();
		height = meshFilter.mesh.bounds.size.x;
		
	}

	// Update is called once per frame
	void Update()
	{
		if (interactable.IsGrabbed())
		{
			//Check ground below
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10000))
			{
				// set Anchor to snap to when object reaches the ground
				if (hit.transform.tag == "Land")
				{
					canRelease = true;
					Anchor = hit.point + new Vector3(0, height / 2.5f, 0);
					//Anchor = hit.point;
					//-print("Anchor = " + Anchor);
				}
				else // obj is not above cadre land
				{
					canRelease = false;
				}

			}
		} else if(canRelease)
		{
			ReleaseObject();
		}

	}
	
	public void GrabObject(GameObject GrabParent)
	{
		this.transform.parent = GrabParent.transform;
	}

	[ContextMenu("Release")]
	public bool ReleaseObject()
	{
		if (canRelease)
		{
			//this.transform.parent = null;
			AnchorRotation = this.transform.rotation;
			//isBeingHeld = false;
			rigbdy.AddForce(Vector3.down * buildSpeed);
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
