using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().Sleep();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
