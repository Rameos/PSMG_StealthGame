using UnityEngine;
using System.Collections;

public class VerbalResponse : MonoBehaviour 
{
	private string dirDefault = "Sounds/Dialog/";
	private string dirAccused = "Sounds/Dialog/Accusations/";
	
	private string newVOClipPath;
	
	public AudioClip[] defaultVOClip;
	
	private bool isWaiting = false;
	private int emptyAccusationCount = 0;
	
	public void NotLookingVO()
	{
		if(!isWaiting)
		{
			newVOClipPath = dirDefault + gameObject.name + "/Not_Looking_" + Suspect.state + "/" + Random.Range(0,4);
			PlayVO();
		}
	}
	
	public void RandomVO()
	{
		if(!isWaiting)
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + Random.Range(0,4);
			PlayVO();
		}
	}
	
	public void FixatedVO()
	{
		if(!isWaiting)
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + Random.Range(0,4);
			PlayVO();
		}
	}
	
	public void FixatedOnClueVO(string clueID)
	{
		if(!isWaiting)
		{
			if(clueID == "EyeContact")
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,9);
			}
			else
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,3);
			}
			PlayVO();
		}
	}
	
	public void RandomOnClueVO(string clueID)
	{
		if(!isWaiting)
		{
			if(clueID == "EyeContact")
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,9);
			}
			else
			{
				newVOClipPath = dirDefault + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,3);
			}
			
			PlayVO();
		}
	}
	
	public void VoiceOverForInteractable(string interactableName)
	{
		if(Suspect.state == Suspect.SuspectState.Nervous)
		{
			newVOClipPath = dirDefault + gameObject.name + "/Interactable_" + Suspect.state + "/" + Random.Range(0,6); //Except T-Virus Hadouken
		}
		else
		{
			newVOClipPath = dirDefault + gameObject.name + "/" + interactableName + "_" + Suspect.state + "/" + Random.Range(0,3);
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
		
		audio.Stop();
		audio.clip = Resources.Load(newVOClipPath, typeof(AudioClip)) as AudioClip;
		audio.Play();
	}
	
	IEnumerator WaitToRespond(string subject)
	{
		
		if(ClueManager.instance.GetFoundClues().Contains(subject))
		{
			newVOClipPath = dirAccused + subject + "/Suspect/" + Random.Range(0,2);
			audio.clip = Resources.Load(newVOClipPath, typeof (AudioClip)) as AudioClip;
		}
		else if(ClueManager.instance.GetFoundClues().Count == 0)
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
		else
		{
			newVOClipPath = dirAccused + "Default_Response/" + Random.Range(0,4);
			audio.clip = Resources.Load(newVOClipPath, typeof (AudioClip)) as AudioClip;
		}
		
		if(GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip != null)
		{
			yield return new WaitForSeconds(GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip.length);
		}
		
		audio.Play();
		
		gameObject.SendMessage("SetTimeOfLastReaction");
		
		isWaiting = false;
	}
}
