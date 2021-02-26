using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's health.
    public float restartDelay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

	
	public GameObject screen;
	public GameObject text;
	public Material mat1;

    void Awake ()
    {
		screen.SetActive(false);
		text.SetActive(false);
        // Set up the reference.
        anim = GetComponent<Animator>();
		
		if(playerHealth.currentHealth > 0)	
		{
			screen.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			text.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
				
		}
    }


    void Update ()
    {
        // If the player has run out of health...
        if(playerHealth.currentHealth == 0)
        {
			screen.SetActive(true);
			text.SetActive(true);
            // ... tell the animator the game is over.
            anim.SetTrigger ("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if(restartTimer == restartDelay)
            {
                // .. then reload the currently loaded level.
				Debug.Log("Scene Restarted");
                SceneManager.GetActiveScene();
            }
        }
    }
}