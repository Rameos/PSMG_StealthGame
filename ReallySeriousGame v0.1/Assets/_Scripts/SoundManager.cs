using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	
	private AudioSource backgroundSource;
	private AudioSource voiceOverSource;
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
        voiceOverSource = gameObject.AddComponent<AudioSource>();
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
        voiceOverSource.Stop();
        switch (track)
        {
            case Constants.EventBarkeeperDrink:
                voiceOverSound = voiceClip[0];
                break;
            case Constants.EventBarkeeperMixexperte:
                voiceOverSound = voiceClip[1];
                break;
            case Constants.EventBarkeeperFleck:
                voiceOverSound = voiceClip[2];
                break;            
            case Constants.EventBarkeeperMischung:
                voiceOverSound = voiceClip[3];
                break;
            case Constants.EventBarkeeperErfolgsgeheimnis:
                voiceOverSound = voiceClip[4];
                break;
            case Constants.EventBarkeeperKillerdrink:
                voiceOverSound = voiceClip[5];
                break;
            case Constants.EventBarkeeperRatten:
                voiceOverSound = voiceClip[6];
                break;
            case Constants.EventBarkeeperDrogen:
                voiceOverSound = voiceClip[7];
                break;
            case Constants.EventBarkeeperRattengift:
                voiceOverSound = voiceClip[8];
                break;
            case Constants.EventBarkeeperBesterDrink:
                voiceOverSound = voiceClip[9];
                break;
            case Constants.EventBarkeeperAllesMischen:
                voiceOverSound = voiceClip[10];
                break;
            //case Constants.EventBarkeeperFleck:
            //    voiceOverSound = voiceClip[2];
            //case Constants.EventBarkeeperFleck:
            //    voiceOverSound = voiceClip[2];
                //break;
                //break;
                //break;
                //break;
                //break;
                //break;
                //break;
                //break;
                //break;
                //break;
            default:
                break;
        }
        voiceOverSource.clip = voiceOverSound;
        voiceOverSource.Play();
	}
	
	public void StopVoiceOver()
	{
        voiceOverSource.Stop();
        voiceOverSource.clip = null;
	}
	
	public void PlaySoundEffect()
	{
	
	}
	
	public void StopSoundEffect()
	{
	
	}
}
