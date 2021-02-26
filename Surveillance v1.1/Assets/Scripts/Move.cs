using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public GameObject cam;
	public GameObject player;

	float distance =  1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(cam.transform.position == player.transform.position)
		{			
			if(OVRInput.Get(OVRInput.Touch.PrimaryTouchpad) || Input.GetKeyDown(KeyCode.W))
			{
				cam.transform.position = cam.transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
				player.transform.position = cam.transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
				
				
				cam.transform.position = new Vector3(cam.transform.position.x, 1.2f, cam.transform.position.z);
				player.transform.position = new Vector3(player.transform.position.x, 1.2f, player.transform.position.z);
				Debug.Log("pressed w");
			}
		}
	}
}
