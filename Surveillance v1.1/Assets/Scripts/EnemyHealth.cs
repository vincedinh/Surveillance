using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth = 100;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public AudioClip deathClip;                 // The sound to play when the enemy dies.
	public AudioSource enemyAudio;
	public AudioClip hurtClip;
	
	public EnemyMovement moving;
	
	public GameObject enemy;

    public Animator anim;                              // Reference to the animator.
	
    bool isDead = false;                                // Whether the enemy is dead.
    bool isSinking = false;                             // Whether the enemy has started sinking through the floor.
	


    void Awake ()
    {

    }

    void Update ()
    {
        // If the enemy should be sinking...
        if(isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        // If the enemy is dead...
        if(isDead)
           
            return;

        // Play the hurt sound effect.
		enemyAudio.clip = hurtClip;
        enemyAudio.Play ();
		anim.SetTrigger("Hurt");
		

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
		
		moving.Chase();

        // If the current health is less than or equal to zero...
        if(currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death ();
        }
    }


    void Death ()
    {
        // The enemy is dead.
        isDead = true;

        // Tell the animator that the enemy is dead.
		anim.SetTrigger("ReallyHurt");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
		
		StartCoroutine("ExecuteSinkAfterTime");
    }


    public void StartSinking ()
    {
        // Find and disable the Nav Mesh Agent.
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

		
		
        // The enemy should now sink.
        isSinking = true;

        // After 2 seconds destory the enemy.
        StartCoroutine("ExecuteAfterTime");
    }


	IEnumerator ExecuteAfterTime()
	{
		
     yield return new WaitForSeconds(2);
	 
	 
		enemy.SetActive(false);
		
	}
	
	IEnumerator ExecuteSinkAfterTime()
	{
		
		yield return new WaitForSeconds(3);
		StartSinking();
	}
	
}		