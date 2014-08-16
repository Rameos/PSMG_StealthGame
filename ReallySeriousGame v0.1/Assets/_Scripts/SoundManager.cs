using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	
	private AudioSource musicSource;
	private AudioSource ambientSource;
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
			backgroundSound = ambientClip[Random.Range(0, 1)];
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
