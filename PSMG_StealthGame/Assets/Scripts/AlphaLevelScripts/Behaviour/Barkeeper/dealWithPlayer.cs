using UnityEngine;
using System.Collections;

public class dealWithPlayer : MonoBehaviour {

	public AudioClip[] sounds;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void dealWithMessage(string message)
	{
		
		switch (message)
		{
		case "Eye":
			print("eye");
			PlayEye();
			break;
		case "EyeLong":
			PlayEyeLong();
			break;
		case "Blood":
			PlayBlood();
			break;
		case "GreenSpot":
			PlayGreenSpot();
			break;

		default:
			//default stuff
			break;
		}
	}


	IEnumerator PlayEye()
	{
		if (!audio.isPlaying)
		{
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 0.1f;
			AudioClip nextClip = sounds[0];
			audio.clip = nextClip;
			audio.Play();
			yield return new WaitForSeconds (audio.clip.length);
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 1.0f;
		}
	}
	IEnumerator PlayEyeLong()
	{
		if (!audio.isPlaying)
		{
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 0.1f;
			AudioClip nextClip = sounds[1];
			audio.clip = nextClip;
			audio.Play();
			yield return new WaitForSeconds (audio.clip.length);
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 1.0f;
		}
	}

	IEnumerator PlayBlood()
	{
		if (!audio.isPlaying)
		{
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 0.1f;
			AudioClip nextClip = sounds[3];
			audio.clip = nextClip;
			audio.Play();
			yield return new WaitForSeconds (audio.clip.length);
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 1.0f;
		}
	}

	IEnumerator PlayGreenSpot()
	{
		if (!audio.isPlaying)
		{
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 0.1f;
			AudioClip nextClip = sounds[2];
			audio.clip = nextClip;
			audio.Play();
			yield return new WaitForSeconds (audio.clip.length);
			Camera.main.gameObject.GetComponent<AudioSource>().volume = 1.0f;
		}
	}
}
