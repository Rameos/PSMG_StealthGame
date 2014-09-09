using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager instance;
	
	private AudioSource musicSource;
	public AudioClip[] musicClip;
	
	private AudioSource ambientSource;
	public AudioClip[] ambientClip;
	
	private AudioSource soundEffectSource;
	public AudioClip[] soundEffectClip;
	
	private AudioSource voiceSource;
	public AudioClip[] voiceClip;
	
	private AudioClip backgroundSound;
	
	private string dirAccusations = "Sounds/Dialog/Accusations/";
	private string voiceClipPath;
	private int emptyAccusationCount = 0;
	
	private string dirSfx = "Sounds/Misc/";
	
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
		
		soundEffectSource = gameObject.AddComponent<AudioSource>();
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
	
	//MC Voice Output
	#region main character sounds
	public void PlayVoice(string subject)
	{
		if(voiceSource.isPlaying)
		{
			return;
		}
		voiceSource.Stop();
		voiceSource.clip = Resources.Load(subject, typeof(AudioClip)) as AudioClip;
		voiceSource.Play();
	}
	
	public void StopVoice()
	{
		voiceSource.Stop();
		voiceSource.clip = null;
	}
	
	public void PlayAccusation(GameObject accused)
	{
		voiceSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
		
		voiceSource.Stop();
		
		if(ClueManager.instance.GetFoundClues().Count == 0)
		{
			EmptyAccusationOn(accused);
		}
		else
		{
			if(GameState.IsState(GameState.States.Inspecting))
			{
				EmptyAccusationOn(accused);
			}
			else
			{
				if(ClueManager.instance.GetFoundClues().Contains(accused.name))
				{
					voiceClipPath = dirAccusations + accused.name + "/Detective/" + Random.Range(0,2);
					voiceSource.clip = Resources.Load(voiceClipPath, typeof(AudioClip)) as AudioClip;
				}
				else
				{
					voiceSource.clip = null;
				}
			}
		}
		
		voiceSource.Play();
	}
	
	void EmptyAccusationOn(GameObject accused)
	{
		if(emptyAccusationCount + 2 == voiceClip.Length)
		{
			emptyAccusationCount = 0;
		}
		
		if(accused.tag == "Clue")
		{
			if(!accused.transform.parent.GetComponent<Interactable>().HasBeenAccused())
			{
				voiceSource.clip = voiceClip[Random.Range(0, 2)];
			}
			else
			{
				voiceSource.clip = voiceClip[2 + emptyAccusationCount];
			}
		}
		else
		{
			if(accused.GetComponent<Interactable>() as Interactable != null)
			{
				if(!accused.GetComponent<Interactable>().HasBeenAccused())
				{
					voiceSource.clip = voiceClip[Random.Range(0, 2)];
				}
				else
				{
					voiceSource.clip = voiceClip[2 + emptyAccusationCount];
				}
			}
		}
		emptyAccusationCount++;
	}
	
	#endregion
	
	public void PlaySoundEffect(string item)
	{
		soundEffectSource.clip = Resources.Load(dirSfx + item, typeof(AudioClip)) as AudioClip;
		soundEffectSource.Play();
	}
	
	public void StopSoundEffect()
	{
		soundEffectSource = null;
		soundEffectSource.clip = null;
	}
	
	#region volume controls
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
	#endregion
}
