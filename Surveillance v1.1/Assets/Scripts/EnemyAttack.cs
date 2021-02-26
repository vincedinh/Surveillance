using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.


    public Animator playerAnim;                              // Reference to the animator component.
	public Animator enemyAnim;
    public GameObject player;                          // Reference to the player GameObject.
	public GameObject player2;
    public PlayerHealth playerHealth;                  // Reference to the player's health.
    public EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer = 0.0f;                                // Timer for counting up to the next attack.
	
	public AudioSource enemyAudio;
	public AudioClip hashtag;
	
	


    void Awake ()
    {

    }


    void OnTriggerEnter (Collider other)
    {
        // If the entering collider is the player...
        if(other.gameObject == player || other.gameObject == player2)
        {
            // ... the player is in range.
            enemyAnim.SetBool("InAttackRange", true);
			playerInRange = true;
			
        }
    }


    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player || other.gameObject == player2)
        {
            // ... the player is no longer in range.
			enemyAnim.SetBool("InAttackRange", false);
            playerInRange = false;
        }
    }


    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            // ... attack.
            Attack();
        }


    }


    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if(playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
			enemyAnim.SetTrigger("Hurt");
        }
		if(playerHealth.currentHealth < 0)
		{
			StartCoroutine("ExecuteAudioAfterTime");
		}
    }
	
	IEnumerator ExecuteAudioAfterTime()
	{
		Debug.Log("AudioWait");
		
     yield return new WaitForSeconds(2.0f);
		enemyAudio.clip = hashtag;
		enemyAudio.Play();
	}
}