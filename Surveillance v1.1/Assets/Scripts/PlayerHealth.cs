using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public GameObject input;
	public GameObject playerCam;
	public GameObject playerVoice;
	public GameObject playerModel;
	
	public AudioSource gameOver;
	public AudioClip akhilaGameOver;


    Animator anim;
    AudioSource playerAudio;
    Move playerMovement;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = playerModel.GetComponent <Animator> ();
        playerAudio = playerVoice.GetComponent<AudioSource>();
        playerMovement = GetComponent <Move> ();
        currentHealth = startingHealth;
	
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
		
		if(isDead == true)
		{
			input.GetComponent<Move>().enabled = false;
			playerCam.GetComponent<CamMovement>().enabled = false;
			anim.SetBool("isAlive", false);
			
		}
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        anim.SetTrigger ("Die");

		
		
        playerAudio.clip = deathClip;
		playerAudio.Play();
		
		
		StartCoroutine("ExecuteAudioAfterTime");
		
		
		playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }
	
	IEnumerator ExecuteAudioAfterTime()
	{
		Debug.Log("AudioWait");
     yield return new WaitForSeconds(3);
 
		gameOver.clip = akhilaGameOver;
		gameOver.Play();
	}


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
	

}
