using UnityEngine;
using System.Collections;
using System;

public class VisualResponse : MonoBehaviour 
{
	private string dir;
	
	private float gestureDurationShort 	= 3.5f;
	private float gestureDurationLong;
	
	private Sprite newSprite;
	private string newSpritePath;
	private Sprite defaultSprite;
	
	private bool inGesture = false;
	
	void Awake()
	{
		newSprite = GetComponent<SpriteRenderer>().sprite;
		
		dir = "Sprites/Barkeep/" + gameObject.name;
	}
	
	public void SetDefaultSprite()
	{
		GetComponent<SpriteRenderer>().sprite = Resources.Load(dir + "_Default_" + Suspect.state + "_0", typeof (Sprite)) as Sprite;
		if(Suspect.state == Suspect.SuspectState.Nervous)
		{
			GameObject.Find("Bandage").GetComponent<Clue>().ToggleVisibility();
		}
		else
		{
			GameObject.Find("Bandage").GetComponent<Clue>().ToggleVisibility();
		}
	}
	
	public void NotLookingGesture()
	{
		Debug.Log("Flail.");
	}
	
	public void RandomGesture()
	{
		newSpritePath = dir + "_Default_" + Suspect.state + "_" + UnityEngine.Random.Range(0,2);
			
		StartCoroutine("DoShortGesture");
	}
	
	public void FixatedGesture()
	{
		newSpritePath = dir + "_" + Suspect.state + "_" + UnityEngine.Random.Range(0,1);
		
		StartCoroutine("DoShortGesture");
	}
	
	public void FixatedOnClueGesture(string clueID)
	{
		newSpritePath = dir + "_" + Suspect.state + "_" + clueID;
		StartCoroutine("DoShortGesture");
	}
	
	public void RandomOnClueGesture(string clueID)
	{
		newSpritePath = dir + "_" + Suspect.state + "_" + clueID;
			
		StartCoroutine("DoShortGesture");
	}
	
	public void GestureForInteractable(string interactableName)
	{
		newSpritePath = dir + "_Default_" + Suspect.state + "_0";
		
		StartCoroutine("DoShortGesture");
	}
	
	public bool IsInGesture
	{
		get
		{
			return inGesture;
		}
	}
	
	IEnumerator DoShortGesture()
	{	
		newSprite = Resources.Load(newSpritePath, typeof(Sprite)) as Sprite;
		
		if(newSprite != null && !inGesture)
		{
			GetComponent<SpriteRenderer>().sprite = newSprite;
			inGesture = true;
				
			yield return new WaitForSeconds(gestureDurationShort);
			
			GetComponent<SpriteRenderer>().sprite = Resources.Load(dir + "_Default_" + Suspect.state + "_0", typeof (Sprite)) as Sprite;
			inGesture = false;
		}
	}
}
