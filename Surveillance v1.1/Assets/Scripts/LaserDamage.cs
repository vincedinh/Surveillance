using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour {

	public int damageAmount = 10;
	public Collider collider;
	
	public Animator anim;
	public GameObject player;
	public PlayerHealth playerHealth;
	public GameObject player2;
	
	public bool playerInRange;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerInRange && playerHealth.currentHealth > 0)
		{
			Damage();
			Debug.Log("Player is in range");
		}
			
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player || other.gameObject == player2)
		{
			Debug.Log("trigger");
			playerInRange = true; 
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player || other.gameObject == player2)
		{
			playerInRange = false;
		}
		
	}
	
	void Damage()
	{
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage(damageAmount);
			anim.SetTrigger("Hurt");
		}
	}
	
}
