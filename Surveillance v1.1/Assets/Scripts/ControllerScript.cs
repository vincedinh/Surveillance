using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour 
{


	public AudioClip clip;
	public AudioSource audioSource;
	
	public Transform gunBarrelTransform;
	
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip;
	}
	
	// Update is called once per frame
	
	//if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
	
	/*		
	if(Input.GetButtonUp("Fire1") <---Mouse button testing
	*/
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			audioSource.Play();
			RaycastGun();
			Debug.Log("Pressed primary button.");
		}
	}
	
	//if(Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
		
	//Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
	//if(Physics.Raycast(inputRay, out hit))
	
		private void RaycastGun()
	{
		Ray inputRay = Camera.main.ScreenPointToRay(gunBarrelTransform.position);
		RaycastHit hit;
		
		Debug.DrawRay(gunBarrelTransform.position, gunBarrelTransform.forward, Color.white);
		
		if(Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
		{
			if(hit.collider.gameObject.CompareTag("SpherePart") == true)
			{
				Destroy(hit.collider.gameObject);
				Debug.Log("Destroyed.");
				Debug.Log(hit.point);
			}
		}
	}
}
