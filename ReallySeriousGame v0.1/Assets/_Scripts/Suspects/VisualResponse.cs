using UnityEngine;
using System.Collections;
using System;

public class VisualResponse : MonoBehaviour 
{
	private string dir = "Sprites/Barkeep/";
	private string nullErrorMsg = "Faulty string.";
	
	private float gestureDurationShort 	= 4f;
	private float gestureDurationLong	= 8f;
	
	private Sprite lastSprite, newSprite;
	private string newSpritePath;
	
	void Awake()
	{
		newSprite = GetComponent<SpriteRenderer>().sprite;
	}
	
	public void RandomGesture()
	{
		lastSprite = newSprite;
		
		newSpritePath = dir + gameObject.name + "_Default_" + Suspect.state + "_" + UnityEngine.Random.Range(0,2);
		newSprite = Resources.Load(newSpritePath, typeof(Sprite)) as Sprite;
		
		try
		{
			StartCoroutine("DoShortGesture");
		}
		catch(NullReferenceException e)
		{
			Debug.Log(nullErrorMsg);
		}
	}
	
	public void FixatedGesture()
	{
		lastSprite = newSprite;
		
		newSpritePath = dir + gameObject.name + "_" + GameState.gameState + "_Positive_" + UnityEngine.Random.Range(0,2);
		newSprite = Resources.Load(newSpritePath, typeof(Sprite)) as Sprite;
		
		try
		{
			StartCoroutine("DoShortGesture");
		}
		catch(NullReferenceException e)
		{
			Debug.Log(nullErrorMsg);
		}
	}
	
	public void FixatedClueGesture(int clueID)
	{
		
	}
	
	public void RandomClueGesture(int clueID)
	{
		
	}
	
	IEnumerator DoShortGesture()
	{	
		if(newSprite != lastSprite)
		{
			GetComponent<SpriteRenderer>().sprite = newSprite;
				
			yield return new WaitForSeconds(gestureDurationShort);
				
			GetComponent<SpriteRenderer>().sprite = lastSprite;
			newSprite = lastSprite;
		}
	}
}
