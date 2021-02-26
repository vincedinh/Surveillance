using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public Transform Gun;
	
	public Deactivate deactivateButton;
	
	
	
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
		if(Input.GetButtonUp("Fire1") || OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
		{
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
				
				//need to change this for second part of gameplay!!
				
				
			}
		}
	}
	

	
	
}