using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {


	public GameObject door;
	public GameObject gun;
	
	
	public AudioSource defensesDisabled;
	public AudioSource openSound;
	public AudioSource bgMusic;
	public AudioSource siren;
	
	public Move move;
	
	// Use this for initialization
	void Start () {
		move.enabled = false;
		gun.SetActive(false);
		defensesDisabled.Play();
		StartCoroutine("ExecuteDoorAfterTime");
		StartCoroutine("ExecuteMoveAfterTime");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	IEnumerator ExecuteDoorAfterTime()
	{
		Debug.Log("AudioWait");
		
     yield return new WaitForSeconds(1.5f);
		openSound.Play();
		door.SetActive(false);
	}
	
	IEnumerator ExecuteMoveAfterTime()
	{
		Debug.Log("AudioWait");
		
     yield return new WaitForSeconds(5.0f);
		bgMusic.Play();
		siren.Play();
		gun.SetActive(true);
		move.enabled = true;
	}
	
	
}
