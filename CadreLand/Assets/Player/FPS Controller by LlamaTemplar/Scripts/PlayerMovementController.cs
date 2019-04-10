using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] float jumpPower;
    private bool b_jump;
    private float verticalVelocity;
	public bool isMoving = false;
	private Vector3 PlayerMovementTo;

	private CharacterController charCtrl;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
      
    }

    void Update()
    {
		PlayerMovementTo = WalkTo();

        charCtrl.Move(PlayerMovementTo * Time.deltaTime);
    }

	// Get next vector to move to based on user input
	private Vector3 WalkTo()
	{
		//Get input data from Horizontal nd Vertical
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		if (deltaX > 0 || deltaZ > 0)
			isMoving = true;
		else
			isMoving = false;

		if (IsGrounded())
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				verticalVelocity = jumpPower;
			}
		}
		else // apply gravity if the player has jumped
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}


		var movement = new Vector3(deltaX, verticalVelocity, deltaZ);   //create new 3D postion
		movement = transform.TransformDirection(movement);              //Transforms direction x, y, z from local space to world space.
		return movement;
	}

	//this method will help the controller move down ramps smoothly
	private bool IsGrounded()
	{
		if (charCtrl.isGrounded)
			return true;

		float snapDistance = 0.1f;	//any value higher will cause the jump to glitch

		// Cast a ray and move down that distance
		RaycastHit hit;
		if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, snapDistance))
		{
			charCtrl.Move(new Vector3(0, -hit.distance, 0));
			return true;
		}

		return false;
	}

}


