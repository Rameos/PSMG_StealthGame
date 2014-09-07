using UnityEngine;
using System.Collections;

public class VerbalResponse : MonoBehaviour 
{
	private string dir = "Sounds/Dialog/";
	
	private string newVOClipPath;
	
	private AudioClip newVOClip;
	
	public void AccusationVO(string subject)
	{
		Debug.Log("Wasn't me! ");
	}
	
	public void NotLookingVO()
	{
		newVOClipPath = dir + gameObject.name + "/Not_Looking_" + Suspect.state + "/" + Random.Range(0,4);
		PlayVO();
	}
	
	public void RandomVO()
	{
		newVOClipPath = dir + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + Random.Range(0,4);
		PlayVO();
	}
	
	public void FixatedVO()
	{
		newVOClipPath = dir + gameObject.name + "/" + GameState.gameState + "_" + Suspect.state + "/" + Random.Range(0,4);
		PlayVO();
	}
	
	public void FixatedOnClueVO(string clueID)
	{
		if(clueID == "EyeContact")
		{
			newVOClipPath = dir + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,9);
		}
		else
		{
			newVOClipPath = dir + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,3);
		}
		PlayVO();
	}
	
	public void RandomOnClueVO(string clueID)
	{
		if(clueID == "EyeContact")
		{
			newVOClipPath = dir + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,9);
		}
		else
		{
			newVOClipPath = dir + gameObject.name + "/" + clueID + "_" + Suspect.state + "/" + Random.Range(0,3);
		}
		
		PlayVO();
	}
	
	public void VoiceOverForInteractable(string interactableName)
	{
		if(Suspect.state == Suspect.SuspectState.Nervous)
		{
			newVOClipPath = dir + gameObject.name + "/Interactable_" + Suspect.state + "/" + Random.Range(0,6); //Except T-Virus Hadouken
		}
		else
		{
			newVOClipPath = dir + gameObject.name + "/" + interactableName + "_" + Suspect.state + "/" + Random.Range(0,3);
		}
		
		PlayVO();
	}
	
	public bool IsSpeaking
	{
		get
		{
			return audio.isPlaying;
		}
	}
	
	void PlayVO()
	{
		if(audio.isPlaying)
		{
			return;
		}
		
		audio.Stop();
		audio.clip = Resources.Load(newVOClipPath, typeof(AudioClip)) as AudioClip;
		audio.Play();
	}
}
