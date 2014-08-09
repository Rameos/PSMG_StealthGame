using UnityEngine;
using System.Collections;
using iViewX;

public class Clue : MonoBehaviourWithGazeComponent
{
	public string clueName;
	private Light highlight;
	private bool isHighlighted = false;
	private bool isDiscovered; //Discovered by player?
	private bool isVisible = true;	//Visible on suspect?
	
	void Awake()
	{
		highlight = GetComponent<Light>();
		highlight.enabled = false;
	}
	
	void OnMouseEnter()
	{
		HighlightClue();
	}
	
	void OnMouseExit()
	{
		UnHighlightClue();
	}
	
	public override void OnGazeEnter(RaycastHit hit)
	{
		
	}
	
	public override void OnGazeStay(RaycastHit hit)
	{
		
	}
	
	public override void OnGazeExit()
	{
		
	}
	
	/// <summary>
	/// Highlights the clue during interaction if it hasn't been discovered yet and is visible.
	/// </summary>
	
	void HighlightClue()
	{
		if(GameState.IsInteracting && !isHighlighted && !isDiscovered && isVisible)
		{	
			highlight.enabled = true;
			isHighlighted = true;
			isDiscovered = true;
		}
	}
	
	void UnHighlightClue()
	{
		if(isHighlighted)
		{
			highlight.enabled = false;
			isHighlighted = false;
		}
	}
}
