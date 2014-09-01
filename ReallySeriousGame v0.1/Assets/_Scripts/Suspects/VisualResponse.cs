using UnityEngine;
using System.Collections;
using System;

public class VisualResponse : MonoBehaviour 
{
	private string dir;
	
	private float gestureDurationShort 	= 3.5f;
	private float gestureDurationLong;
	
	private Sprite newSprite;
	public string newSpritePath;
	private Sprite defaultSprite;
	
	private bool inGesture = false;
	
	void Awake()
	{
		newSprite = GetComponent<SpriteRenderer>().sprite;
		
		dir = "Sprites/Barkeep/" + gameObject.name;
		
		defaultSprite = Resources.Load(dir + "_Default_Neutral_0", typeof(Sprite)) as Sprite;
	}
	
	/*void Update()
	{
		Debug.Log("sprite path: " + newSpritePath);
		Debug.Log("new sprite: " + newSprite);
		Debug.Log("last sprite: " + lastSprite);
	}*/
	
	public void AccusationGesture(string subject)
	{
		Debug.Log("Cross arms");
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
		newSpritePath = dir + "_Positive_" + UnityEngine.Random.Range(0,2);
			
		StartCoroutine("DoShortGesture");
	}
	
	public void FixatedOnClueGesture(string clueID)
	{
		newSpritePath = dir + "_Nervous_" + clueID;
		
		StartCoroutine("DoShortGesture");
	}
	
	public void RandomOnClueGesture(string clueID)
	{
		newSpritePath = dir + "_Nervous_" + clueID;
			
		StartCoroutine("DoShortGesture");
	}
	
	public void GestureForInteractable(string interactableName)
	{
		newSpritePath = dir + "_Default_Neutral_0";
		
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
			
			GetComponent<SpriteRenderer>().sprite = defaultSprite;
			inGesture = false;
		}
	}
}
