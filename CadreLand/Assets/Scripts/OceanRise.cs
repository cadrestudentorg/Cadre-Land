using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanRise : MonoBehaviour
{
	private Vector3 baseLevel = new Vector3(0, -11, 0);
	private float phase1Time;
	private float phase2Time;
	public Transform phase1End;
	public Transform phase2End;
	public float phase1Dist;
	public float phase2Dist;
	public float phase1Rate;
	public float phase2Rate;
	public bool phase2 = false;

	// Start is called before the first frame update
	void Start()
    {
		phase1Time = 2*60;
		phase2Time = 1*60;

		phase1Dist = phase1End.position.y - transform.position.y;
		phase2Dist = phase2End.position.y - phase1End.position.y;

		phase1Rate = phase1Dist / phase1Time;
		phase2Rate = phase2Dist / phase2Time;
	}

    // Update is called once per frame
    void Update()
    {
		if(phase2)
			transform.Translate(new Vector3(0, 0, -phase2Rate * Time.deltaTime));
		else
		{
			if (transform.position.y > phase1End.position.y)
				phase2 = true;
			transform.Translate(new Vector3(0, 0, -phase1Rate * Time.deltaTime));
		}
	}
}
