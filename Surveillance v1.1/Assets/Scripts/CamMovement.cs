using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

	public int curpos = 0;
	public Transform SurvCam;
	public Transform FPCam; 
	public CapsuleCollider survcollider;
	public Collider fpcollider;
	public Rigidbody body;
	
	public GameObject face;
	public GameObject meshBody;
	
	public Material invisible;
	public Material survViewMat;
	public GameObject protagonist;
	
	public GameObject controller;
	public GameObject gun;
	public GameObject inputManager;
	
	
	// Use this for initialization
	void Start () {
		if(curpos == 0)
		{
			body.useGravity = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if( OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyUp(KeyCode.Space) ) 
		{
			Swap();
			Debug.Log("Pressed");
			Debug.Log(curpos);
		}
		
		if(curpos == 1)
		{
			transform.position = new Vector3(FPCam.transform.position.x, 1.551f, FPCam.transform.position.z);
			transform.rotation = FPCam.transform.rotation;
			survcollider.enabled = true;
			fpcollider.enabled = false;
			body.detectCollisions = true;
			body.isKinematic = false;
			
			face.SetActive(false);
			meshBody.SetActive(false);
			protagonist.SetActive(false);
			
			
			controller.SetActive(false);
			gun.SetActive(true);
			inputManager.GetComponent<ControllerScript>().enabled = false;
			inputManager.GetComponent<GunScript>().enabled = true;
			
		}
		if(curpos == 0)
		{
			survcollider.enabled = false;
			fpcollider.enabled = true;
			body.detectCollisions = false;
			body.isKinematic = true;
			
			face.SetActive(true);
			meshBody.SetActive(true);
			protagonist.SetActive(true);
			
			controller.SetActive(true);
			gun.SetActive(false);
			inputManager.GetComponent<ControllerScript>().enabled = true;
			inputManager.GetComponent<GunScript>().enabled = false;
		}
	}
	
	void Swap()
	{
		if(curpos == 0)
		{
			transform.position = new Vector3(FPCam.position.x + 0.011009f, 1.551f, FPCam.position.z + 0.019077f);
			transform.rotation = FPCam.rotation;
			curpos = curpos+1;
		}
		
		else if(curpos == 1)
		{
			
			transform.position = SurvCam.position;
			transform.rotation = SurvCam.rotation;
			curpos = curpos-1;
		}
		
	}
	
	public bool Pressable()
	{
		if(curpos == 0)
		{
		return true;
		}
			return false;
		
	}
}
