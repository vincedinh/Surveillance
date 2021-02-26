using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibOnCollide : MonoBehaviour {


	public GameObject gib;
	
	void OnCollisionEnter()
	{
		Instantiate(gib, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
