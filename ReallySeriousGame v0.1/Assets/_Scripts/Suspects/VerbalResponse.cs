using UnityEngine;
using System.Collections;

public class VerbalResponse : MonoBehaviour 
{
	private string dirDefault = "Sounds/Dialog/";
	private string dirAccused = "Sounds/Dialog/Accusations/";
	
	private string newVOClipPath;
	
	public AudioClip[] defaultVOClip;
	
	private AudioSource voiceSource;
	private AudioSource sfxSource;
	private float sfxVolume = 0.4f;
	
	private bool isWaiting = false;
	private int emptyAccusationCount = 0;
	
	#region dialog index
	private int eyeContactCount = 0;
	private int notInterrogatingCount = 0;
	private int interrogatingCount = 0;
	private int clueDialogCount = 0;
	private int interactableDialogCount = 0;
	#endregion
	
	void Awake()
	{
		voiceSource = gameObject.AddComponent<AudioSource>();
		voiceSource.rolloffMode = AudioRolloffMode.Linear;
		
		sfxSource = gameObject.AddComponent<AudioSource>();
		sfxSource.rolloffMode = AudioRolloffMode.Linear;
		sfxSource.volume = sfxVolume;
	}
	
	public void NotLookingVO()
	{
		if(!isWaiting)
		{	
			PlaySfx("Glass_Breaking_" + Random.Range(0,2));
			newVOClipPath = dirDefault + gameObject.name + "/Not_Looking_" + Suspect.state + "/" + Random.Range(0,4);
			PlayVO();
		}
	}
	
	public void RandomVO()
	{	
		if(!isWaiting)
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + notInterrogatingCount;
			PlayVO();
			
			if(notInterrogatingCount == 3)
			{
				notInterrogatingCount = 0;
			}
			else
			{
				notInterrogatingCount++;
			}
		}
	}
	
	public void FixatedVO()
	{
		if(!isWaiting)
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + interrogatingCount;
			PlayVO();
			if(interrogatingCount == 3)
			{
				interrogatingCount = 0;
			}
			else
			{
				interrogatingCount++;
			}
		}
	}
	
	public void FixatedOnClueVO(string clueID)
	{
		if(!isWaiting)
		{
			if(clueID == "Tollpatsch")
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + eyeContactCount;
				
				if(eyeContactCount == 8)
				{
					eyeContactCount = 0;
				}
				else
				{
					eyeContactCount++;
				}
			}
			else
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + clueDialogCount;
				
				if(clueDialogCount == 2)
				{
					clueDialogCount = 0;
				}
				else
				{
					clueDialogCount++;
				}
			}
			PlayVO();
		}
	}
	
	public void RandomOnClueVO(string clueID)
	{
		if(!isWaiting)
		{
			if(clueID == "Tollpatsch")
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + eyeContactCount;
				if(eyeContactCount == 8)
				{
					eyeContactCount = 0;
				}
				else
				{
					eyeContactCount++;
				}
			}
			else
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + clueDialogCount;
				if(clueDialogCount == 2)
				{
					clueDialogCount = 0;
				}
				else
				{
					clueDialogCount++;
				}
			}
			
			PlayVO();
		}
	}
	
	public void VoiceOverForInteractable(string interactableName)
	{
		if(Suspect.state == Suspect.SuspectState.Nervous)
		{
			string subject = "";
			if(interactableName == "Hadouken")
			{
				subject = "/Hadouken_";
			}
			else if(interactableName == "T-Virus")
			{
				subject = "/T-Virus_";
			}
			else
			{
				subject = "/Interactable_";
			}
			newVOClipPath = dirDefault + gameObject.name + subject + Suspect.state + "/" + interactableDialogCount; //Except T-Virus Hadouken
		}
		else
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + interactableName + "_" + Suspect.state + "/" + Random.Range(0,2);
		}
		
		if(interactableDialogCount == 3)
		{
			interactableDialogCount = 0;
		}
		else
		{
			interactableDialogCount++;
		}
		
		PlayVO();
	}
	
	public void VoiceOverOnBeingAccused(GameObject accused)
	{
		audio.Stop();
		isWaiting = true;
		StartCoroutine("WaitToRespond", accused.name);
	}
	
	public bool IsSpeaking
	{
		get
		{
			return audio.isPlaying || isWaiting;
		}
	}
	
	void PlayVO()
	{
		/*if(audio.isPlaying)
		{
			return;
		}*/
		
		voiceSource.Stop();
		voiceSource.clip = Resources.Load(newVOClipPath, typeof(AudioClip)) as AudioClip;
		voiceSource.Play();
	}
	
	void PlaySfx(string sfx)
	{
		sfxSource.Stop();
		sfxSource.clip = Resources.Load("Sounds/Misc/" + sfx, typeof(AudioClip)) as AudioClip;
		sfxSource.Play();
	}
	
	IEnumerator WaitToRespond(string subject)
	{
		if(ClueManager.instance.GetFoundClues().Contains(subject) && !DialogManager.instance.GetListOfAccusations().Contains(subject) && DialogManager.instance.IsCorrectOrderOfAccusations(subject))
		{
			string subjectName = "";
			if(subject == "Bandage")
			{
				subjectName = "Fleck";
			}
			else if(subject == "T-Virus")
			{
				subjectName = "Cocktailschirm";
			}
			else if(subject == "Urkunde")
			{
				subjectName = "Buntstifte";
			}
			else
			{
				subjectName = subject;
			}
			newVOClipPath = dirAccused + subjectName + "/Suspect/" + Random.Range(0,2);
			audio.clip = Resources.Load(newVOClipPath, typeof (AudioClip)) as AudioClip;
			DialogManager.instance.AddToListOfAccusations(subject);
			DialogManager.instance.AddToListOfAccusations(subjectName);
		}
		else if(ClueManager.instance.GetFoundClues().Count == 0)
		{
			EmptyAccusation();
		}
		else
		{
			DefaultResponseOnAccusation();
		}
		
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip != null)
		{
			yield return new WaitForSeconds(GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip.length);
		}
		
		audio.Play();
		
		gameObject.SendMessage("SetTimeOfLastReaction");
		
		isWaiting = false;
	}
	
	void EmptyAccusation()
	{
		if(emptyAccusationCount + 2 == defaultVOClip.Length)
		{
			emptyAccusationCount = 0;
		}
		
		if(!gameObject.GetComponent<Interactable>().HasBeenAccused())
		{
			audio.clip = defaultVOClip[Random.Range(0,2)];
		}
		else
		{
			audio.clip = defaultVOClip[2 + emptyAccusationCount];
		}
		emptyAccusationCount++;
	}
	
	void DefaultResponseOnAccusation()
	{
		newVOClipPath = dirAccused + "Default_Response/" + Random.Range(0,4);
		audio.clip = Resources.Load(newVOClipPath, typeof (AudioClip)) as AudioClip;
	}
}
