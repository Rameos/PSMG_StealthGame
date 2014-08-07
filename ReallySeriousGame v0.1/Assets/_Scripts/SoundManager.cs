using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	
	private AudioSource backgroundSource;
	private AudioSource[] voiceOverSource;
	private AudioSource[] soundEffectSource;
	
	public AudioClip[] musicClip;
	public AudioClip[] ambientClip;
	public AudioClip[] noiseClip;
	public AudioClip[] voiceClip;
	
	
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
		
		backgroundSource = gameObject.AddComponent<AudioSource>();
		backgroundSource.loop = true;
	}
	
	public void PlayBGSound(string level) 
	{
		backgroundSource.Stop();
		switch (level)
		{
		case "MainMenu":
			backgroundSound = musicClip[Random.Range(0, musicClip.Length)];
			break;
		case "BarScene":
			backgroundSound = ambientClip[Random.Range(0, ambientClip.Length)];
			break;
		default:
			break;
		}
		backgroundSource.clip = backgroundSound;
		backgroundSource.Play();
	}
	
	public void StopBGSound()
	{
		backgroundSource.Stop();
		backgroundSource.clip = null;
	}
	
	public void PlayVoiceOver()
	{
		
	}
	
	public void StopVoiceOver()
	{
	
	}
	
	public void PlaySoundEffect()
	{
	
	}
	
	public void StopSoundEffect()
	{
	
	}
}
