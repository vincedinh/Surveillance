using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

	public int curpos = 0;
	public Transform SurvCam;
	public Transform FPCam; 
	public CapsuleCollider survcollider;
	public CapsuleCollider fpcollider;
	public Rigidbody body;
	
	public Material invisible;
	public Material survViewMat;
	public GameObject protagonist;
	
	// Use this for initialization
	void Start () {
		if(curpos == 0)
		{
			body.useGravity = false;
			protagonist.GetComponent<MeshRenderer>().material = survViewMat;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( OVRInput.Get(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyUp(KeyCode.Space) ) 
		{
			Swap();
			Debug.Log("Pressed");
			Debug.Log(curpos);
		}
		
		if(curpos == 1)
		{
			transform.position = FPCam.transform.position;
			transform.rotation = FPCam.transform.rotation;
			survcollider.enabled = true;
			fpcollider.enabled = false;
			body.detectCollisions = true;
			protagonist.GetComponent<MeshRenderer>().material = invisible;
		}
		if(curpos == 0)
		{
			survcollider.enabled = false;
			fpcollider.enabled = true;
			body.detectCollisions = false;
			protagonist.GetComponent<MeshRenderer>().material = survViewMat;
		}
	}
	
	void Swap()
	{
		if(curpos == 0)
		{
			transform.position = FPCam.position;
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
}
