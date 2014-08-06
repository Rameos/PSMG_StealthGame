using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	
	public AudioClip[] musicClips;
	public AudioClip[] ambientClips;
	
	private AudioClip backgroundSound;
	
	void Awake () 
	{
		#region singleton
		if(soundManager == null) 
		{
			DontDestroyOnLoad(gameObject);
			soundManager = this;
		} 
		else if(soundManager != this) 
		{
			Destroy(gameObject);
		}
		#endregion
	}
	
	void Update () 
	{
	
	}
	
	public void PlayBackgroundSound(string sound) 
	{
		switch (sound)
		{
		case "music":
			backgroundSound = musicClips[Random.Range(0, musicClips.Length)];
			break;
		case "ambient":
			backgroundSound = ambientClips[Random.Range(0, ambientClips.Length)];
			break;
		default:
			break;
		}
		audio.clip = backgroundSound;
		audio.Play();
	}
}
