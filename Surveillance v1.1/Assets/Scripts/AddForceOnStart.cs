using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnStart : MonoBehaviour {

	public float force = 100.0f;
	public ForceMode forceMode;
	public Rigidbody rigidBody;
	// Use this for initialization
	
	void Start () {
		rigidBody.AddForce(transform.forward*force, forceMode);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
