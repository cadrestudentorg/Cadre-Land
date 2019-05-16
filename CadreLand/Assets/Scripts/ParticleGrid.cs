using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGrid : MonoBehaviour {

	private SerialListener serialListner;
	private GameObject serialController;

	public ParticleSystem ps;
	// public Rigidbody rb;

	private ParticleSystem.Particle[] particlesArray;
	public int resolution = 11;
	public float spacing = 0.2f;
	// public float diviser = 20f;


	// Use this for initialixation
	void Start() {
		serialController = GameObject.Find("SerialController");
		serialListner = serialController.GetComponent<SerialListener>();

		ps = GetComponent<ParticleSystem>();
		// rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		if((resolution % 2) == 0) {
			resolution += 1;
		}

		float angularSpeed = 0;

		// float spacing = Map(angularSpeed,0f,2f,0.05f,1f);

		int particleCount = (int)Mathf.Pow((float)resolution, 3);

		float diviser = Map(angularSpeed, 0f, 1000f, 20, 1);

		var main = ps.main;

		particlesArray = new ParticleSystem.Particle[particleCount];
		main.maxParticles = particleCount;
		ps.Emit(particleCount);
		ps.GetParticles(particlesArray);

		for(float i = 0, x = 0; x < resolution; x++) {
    	for(float y = 0; y < resolution; y++) {
				for(float z = 0; z < resolution; z++, i++) {
					particlesArray[(int)i].position = new Vector3(
						x * spacing - OffsetPosition(),
						y * spacing - OffsetPosition(),
						z * spacing - OffsetPosition()
					);
				}
    	}
		}

		// Draw Particle
		ps.SetParticles(particlesArray, particlesArray.Length);
	}

	float OffsetPosition() {
		// To center at the origin, move
		Vector3 gbPosition;
		float gbOffset = (resolution - 1) * spacing / 2;
		gbPosition = new Vector3(-gbOffset, -gbOffset, -gbOffset);
		// transform.position = gbPosition;
		return gbOffset;
	}

	float Quadratic(float x, float diviser) {
		float y;
		y = x + Mathf.Pow(x, 2) / diviser * diviser;
		return y;
	}

	float Map(float s, float a1, float a2, float b1, float b2) {
    return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}
}
