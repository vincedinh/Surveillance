using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public Transform Gun;
	
	public AudioSource shot;
	
	public float force = 1000.0f;
	public float radius = 5.0f;
	public float upwardsModifier  = 0.0f;
	public ForceMode forceMode;
	
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	
	//if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
	
	/*		
	if(Input.GetButtonUp("Fire1") <---Mouse button testing
	*/
	
	void Update () 
	{
		if(Input.GetButtonUp("Fire2") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
		{
			shot.Play();
			RaycastGun();
			Debug.Log("Pressed primary button.");
		}
	}
	
	//if(Physics.Raycast(Gun.position, Gun.forward, out hit))
		
	//Ray inputRay = Camera.main.ScreenPointToRay(Mouse.position);
	//if(Physics.Raycast(inputRay, out hit))
	
		private void RaycastGun()
	{
		RaycastHit hit;
		
		Debug.DrawRay(Gun.position, Gun.forward, Color.white);
		
		
		
		if(Physics.Raycast(Gun.position, Gun.forward, out hit))
		{
			
			
			
			if(hit.collider.gameObject.CompareTag("Breakable") == true)
			{
				foreach(Collider col in Physics.OverlapSphere(hit.point, radius))
				{
					if(col.GetComponent<Rigidbody>() != null)
					{
						col.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, radius, upwardsModifier, forceMode);
					}	
				}	
				
				//need to change this for second part of gameplay!!
				
				
			}
		}
	}
	

	
	
}