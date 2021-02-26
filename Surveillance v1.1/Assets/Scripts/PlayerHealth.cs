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
	public Animation deathAnimation;
	
	public AudioSource gameOver;
	public AudioClip akhilaGameOver;
	
	bool isDead;
	


    Animator anim;
    AudioSource playerAudio;
    Move playerMovement;
    bool isDying;
    bool damaged;


    void Awake ()
    {
        anim = playerModel.GetComponent <Animator> ();
        playerAudio = playerVoice.GetComponent<AudioSource>();
        playerMovement = GetComponent <Move> ();
        currentHealth = startingHealth;
		
		isDying = false;
	
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
			
			if(currentHealth <= 0 && isDying == false)
			{
			anim.SetTrigger("Die");
			isDying = true;
			}
			
			
			
		}
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();
		anim.SetTrigger("Hurt");

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;


		
		
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
