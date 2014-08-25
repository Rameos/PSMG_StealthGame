using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager instance;
	
	private AudioSource musicSource;
	public AudioClip[] musicClip;
	
	private AudioSource ambientSource;
	public AudioClip[] ambientClip;
	
	private AudioSource[] soundEffectSource;
	//public AudioClip[] soundEffectClip;
	
	private AudioClip backgroundSound;
	
	void Awake () 
	{
		#region singleton
		if(instance == null) 
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		} 
		else if(instance != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.loop = true;
		
		ambientSource = gameObject.AddComponent<AudioSource>();
		ambientSource.loop = true;
	}
	
	public void PlayBGMusic(string level)
	{
		musicSource.Stop();
		switch(level)
		{
			case "MainMenu":
				backgroundSound = musicClip[Random.Range(0, musicClip.Length)];
				break;
			default: break;
		}
		musicSource.clip = backgroundSound;
		musicSource.Play();
	}
	
	public void StopBGMusic()
	{
		musicSource.Stop();
		musicSource.clip = null;
	}
	
	public void PlayAmbientSound(string level) 
	{
		ambientSource.Stop();
		switch (level)
		{
		case "BarScene":
			backgroundSound = ambientClip[Random.Range(0, 2)];
			break;
		case "Scene_2":
			backgroundSound = ambientClip[Random.Range(2, ambientClip.Length)];
			break;
		default:
			break;
		}
		ambientSource.clip = backgroundSound;
		ambientSource.Play();
	}
	
	public void StopAmbientSound()
	{
		ambientSource.Stop();
		ambientSource.clip = null;
	}
	
	public void PlaySoundEffect()
	{
	
	}
	
	public void StopSoundEffect()
	{
		
	}
	
	public void LowerBGVolume()
	{
		if(ambientSource.isPlaying) 
		{
			ambientSource.volume = 0.66f;
		}
	}
	
	public void DefaultBGVolume()
	{
		if(ambientSource.isPlaying)
		{
			ambientSource.volume = 1f;
		}
	}
}
