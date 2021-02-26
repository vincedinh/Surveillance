using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;               // Reference to the player's position.
    public PlayerHealth playerHealth;      // Reference to the player's health.
    public EnemyHealth enemyHealth;        // Reference to this enemy's health.
    public UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
	public Animator anim;
	public GameObject player2;
	
	public AudioSource chaseLines;
	public AudioClip noTime;
	public AudioClip cantEven;
	public AudioClip noLike;
	
	
	UnityEngine.Random rnd = new UnityEngine.Random();

    void Awake ()
    {
        // Set up the references.
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update ()
    {
		
    } 
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player || other.gameObject == player2)
		{
			nav.isStopped = false;
			anim.SetBool("InChaseRange", true);
			
			int voiceLine = UnityEngine.Random.Range(0, 3);
			
				if(voiceLine == 0)
				{
					chaseLines.clip = noTime;
					chaseLines.Play();
				}
				if(voiceLine == 1)
				{
					chaseLines.clip = cantEven;
					chaseLines.Play();
				}
				if(voiceLine == 2)
				{
					chaseLines.clip = noLike;
					chaseLines.Play();
				}
				
			Chase();
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player || other.gameObject == player2)
		{
			nav.isStopped = true;
			anim.SetBool("InChaseRange", false);
		}
		
	}
	
	public void Chase()
	
	{
		if(player2.activeSelf == false)
			{
				nav.SetDestination(player.transform.position);		
			}
			else
			{
				nav.SetDestination (player2.transform.position);
			}
		
	}
}