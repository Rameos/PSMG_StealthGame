using UnityEngine;
using System.Collections;
using iViewX;

public class augen : MonoBehaviourWithGazeComponent{
	float waitForIt = 2f;
	bool stillLooking = false;
	
	
	public AudioClip[] sounds;

	void Start () {
	}
	
	void Update () {
		
	}

	void OnMouseEnter () 
	{
		StartCoroutine(PlayRandomSound());
		PlayRandomSound();

	}
	
	IEnumerator PlayRandomSound()
	{
		if (!audio.isPlaying)
		{
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 0.1f;
			AudioClip nextClip = sounds[Random.Range (0, sounds.Length)];
			audio.clip = nextClip;
			audio.Play();
			yield return new WaitForSeconds (audio.clip.length);
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 2.0f;
		}
	}

	public override void OnGazeEnter(RaycastHit hit)
	{
		stillLooking = true;
		PlayRandomSound ();

		StartCoroutine(callLater(waitForIt));
	}
	
	public override void OnGazeExit()
	{
		stillLooking = false;
	}
	
	public override void OnGazeStay(RaycastHit hit)
	{
		
	}
	
	IEnumerator callLater(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		if (stillLooking) 
		{

		}
		
	}
}
