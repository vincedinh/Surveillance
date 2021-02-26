using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour {


	public CamMovement camCheck;
	public GameObject laser;
	public AudioSource defenseSystem;
	public AudioClip defensesActivated;
	public AudioClip defensesDisabled;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
			
			{
				if(laser.activeSelf == true)
				{
					defenseSystem.clip = defensesDisabled;
					defenseSystem.Play();	
					laser.SetActive(false);
				}
				else
				{
					defenseSystem.clip = defensesActivated;
					defenseSystem.Play();
					laser.SetActive(true);
				}
				
			}
	}

	public void pressButton()
	{
		
		if(camCheck.Pressable() == true)
		{

				if(laser.activeSelf == true)
				{
					defenseSystem.clip = defensesActivated;
					defenseSystem.Play();	
					laser.SetActive(false);
				}
				else
				{
					defenseSystem.clip = defensesDisabled;
					defenseSystem.Play();
					laser.SetActive(true);
				}
			
		}
	}
	
}