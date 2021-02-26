using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScript : MonoBehaviour {


	public CamMovement camCheck;
	public AudioSource defenseMalfunction;
	public GameObject ventDoor;
	public Material pressedButton;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void pressButton()
	{
		
		if(camCheck.Pressable() == true)
		{
			defenseMalfunction.Play();	
				GetComponent<Renderer>().material = pressedButton;
			ventDoor.SetActive(false);
			
		}
	}
}
