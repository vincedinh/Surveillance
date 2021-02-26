using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour 
{
	public Transform Pointer;
	
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
		if(Input.GetButtonUp("Fire1") || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
		{
			RaycastGun();
			Debug.Log("Pressed primary button.");
		}
	}
	
	//if(Physics.Raycast(Pointer.position, Pointer.forward, out hit))
		
	//Ray inputRay = Camera.main.ScreenPointToRay(Mouse.position);
	//if(Physics.Raycast(inputRay, out hit))
	
		private void RaycastGun()
	{
		RaycastHit hit;
		
		Debug.DrawRay(Pointer.position, Pointer.forward, Color.white);
		
		if(Physics.Raycast(Pointer.position, Pointer.forward, out hit))
		{
			
			Pointer.GetComponent<LineRenderer>().SetPosition(0, new Vector3(Pointer.transform.position.x, Pointer.transform.position.y, Pointer.transform.position.z));
			Pointer.GetComponent<LineRenderer>().SetPosition(1, hit.point);	
			Pointer.GetComponent<LineRenderer>().SetWidth(0.3f, 0.3f);
			StartCoroutine("ExecuteAfterTime");
			
			if(hit.collider.gameObject.CompareTag("Button") == true)
			{
				deactivateButton.pressButton();
				Debug.Log("Pressed.");
				Debug.Log(hit.point);
			}
		}
	}
	
	IEnumerator ExecuteAfterTime()
	{
		Debug.Log("Executed");
     yield return new WaitForSeconds(0.02f);
		Pointer.GetComponent<LineRenderer>().SetWidth(0, 0);
	}
	
	
}
