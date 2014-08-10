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
    private AudioClip voiceOverSound;
	
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
	
	public void PlayVoiceOver(string track)
	{
        voiceOverSource[0].Stop();
        switch (track)
        {
            case "Barkeeper":
                voiceOverSound = voiceClip[Random.Range(0, musicClip.Length)];
                break;
            default:
                break;
        }
        voiceOverSource[0].clip = voiceOverSound;
        voiceOverSource[0].Play();
	}
	
	public void StopVoiceOver()
	{
        voiceOverSource[0].Stop();
        voiceOverSource[0].clip = null;
	}
	
	public void PlaySoundEffect()
	{
	
	}
	
	public void StopSoundEffect()
	{
	
	}
}
