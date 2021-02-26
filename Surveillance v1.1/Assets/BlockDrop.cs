using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Enemy") == true)
		{
			other.gameObject.GetComponent<EnemyHealth>().TakeDamage(100);
				
		}
		
	}
}
