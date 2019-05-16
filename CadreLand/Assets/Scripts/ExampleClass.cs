using UnityEngine;
using System.Collections;

// The velocity in y is 10 units per second.  If the GameObject starts at (0,0,0) then
// it will reach (0,100,0) units after 10 seconds.

public class ExampleClass : MonoBehaviour
{
    public Rigidbody rb;

    private float t = 0.0f;
    private bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector3(0, 10, 0);
            moving = true;
            // Debug.Log("jump");
        }

        if (moving)
        {
            // when the cube has moved over 1 second report it's position
            t = t + Time.deltaTime;
            if (t > 1.0f)
            {
                // Debug.Log(gameObject.transform.position.y + " : " + t);
                t = 0.0f;
            }
        }
    }
}
