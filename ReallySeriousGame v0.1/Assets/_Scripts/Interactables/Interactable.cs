using UnityEngine;
using System.Collections;
using iViewX;

public class Interactable : MonoBehaviourWithGazeComponent 
{

	private Color initialColor;
	public Color highlightColor = new Color (0.75f, 1f, 0.75f, 1f);
	bool isHighlighted = false;
	
	void OnMouseEnter()
	{
		if(!GameState.IsPaused && !isHighlighted)
		{	
			Highlight();
		}
	}
	
	void OnMouseOver()
	{
		if(!GameState.IsPaused && !isHighlighted)
		{
			Highlight();
		}
		if(GameState.IsPaused && isHighlighted)
		{
			UnHighlight();
		}
		//Unhighlight when interacting with highlighted object
		if(gameObject == GameController.instance.GetSelectedObject())
		{
			UnHighlight();
		}
		
		//UGGGGGGGGGGGG
		if(Keyboard.inputInteract())
		{
			if(GameState.IsState(GameState.States.Interrogating))
			{	
				GameController.instance.GetCurrentSuspect().SendMessage("ReactionOnInteractable", this.name);
				ClueManager.instance.FoundClue(gameObject);
			}
		}
	}
	
	void OnMouseExit()
	{
		if(isHighlighted)
		{
			UnHighlight();
		}
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
	
	void Highlight() 
	{
		//Do not highlight selected object again.
		if(gameObject != GameController.instance.GetSelectedObject())
		{
			initialColor = renderer.material.color;
			renderer.material.color = highlightColor;
		
			isHighlighted = true;
		}
	}
	
	void UnHighlight()
	{
		renderer.material.color = initialColor;
		isHighlighted = false;
	}
}
