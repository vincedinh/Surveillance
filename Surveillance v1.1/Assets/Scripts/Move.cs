using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{

	public GameObject cam;
	public GameObject rightEye;
	public GameObject player;

	float distance =  1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(cam.transform.position.y == 1.551f)
		{			
			if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.W))
			{
				cam.transform.position = rightEye.transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
				player.transform.position = cam.transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
				
				cam.transform.position = new Vector3(cam.transform.position.x, 1.551f, cam.transform.position.z);
				player.transform.position = new Vector3(cam.transform.position.x - 0.011009f, 0.1743003f, cam.transform.position.z - 0.019077f);
				Debug.Log("pressed w");
						

			}
		}
	}
}
