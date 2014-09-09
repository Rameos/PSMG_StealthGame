﻿using UnityEngine;
using System.Collections;
using iViewX;

public class Interactable : MonoBehaviourWithGazeComponent 
{

	private Color initialColor;
	public Color highlightColor = new Color (0.75f, 1f, 0.75f, 1f);
	bool isHighlighted = false;
	bool inInteraction = false;
	bool hasBeenAccused = false;
	
	InteractionManager interaction;
	
	void Awake()
	{
		interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>();
	}
	
	void Update()
	{
		if(!GameState.IsInteracting)
		{
			inInteraction = false;
		}
		if(this.tag == "Suspect")
		{
			if(!gameObject.GetComponent<SpriteRenderer>().isVisible)
			{
				SendMessage("NotLookingReaction");
			}
		}
	}
	
	#region mouse
	void OnMouseEnter()
	{
		if(!gazeModel.isEyeTrackerRunning)
		{
			if(!GameState.IsPaused && !isHighlighted)
			{	
				Highlight();
			}
			
			if(this.tag == "Suspect")
			{
				this.SendMessage("RandomReaction");
			}
		}
	}
	
	void OnMouseOver()
	{
		if(!gazeModel.isEyeTrackerRunning)
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
				if(GameState.IsState(GameState.States.InGame))
				{
					inInteraction = true;
				}
				if(GameState.IsState(GameState.States.Interrogating) && this.tag != "Suspect")
				{	
					GameController.instance.GetCurrentSuspect().SendMessage("ReactionOnInteractable", this.name);
					ClueManager.instance.FoundClue(gameObject);
				}
			}
			
			if(this.tag == "Suspect")
			{
				this.SendMessage("FixatedReaction");
			}
		}
	}
	
	void OnMouseExit()
	{
		if(!gazeModel.isEyeTrackerRunning)
		{
			if(isHighlighted)
			{
				UnHighlight();
			}
		}
	}
	#endregion
	
	#region gaze
	public override void OnGazeEnter(RaycastHit hit)
	{
		if(!GameState.IsPaused && !isHighlighted)
		{	
			Highlight();
		}
		
		if(this.tag == "Suspect")
		{
			this.SendMessage("RandomReaction");
		}
	}
	
	public override void OnGazeStay(RaycastHit hit)
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
			if(GameState.IsState(GameState.States.Interrogating) && this.tag != "Suspect")
			{	
				GameController.instance.GetCurrentSuspect().SendMessage("ReactionOnInteractable", this.name);
				ClueManager.instance.FoundClue(gameObject);
			}
		}
		
		if(this.tag == "Suspect")
		{
			this.SendMessage("FixatedReaction");
		}
		
		if(Keyboard.inputInteract())
		{
			GameController.instance.SetSelectedGazeObject(gameObject);
			interaction.StartInteraction(gameObject);
		}
	}
	
	public override void OnGazeExit()
	{
		if(isHighlighted)
		{
			UnHighlight();
		}
	}
	#endregion
	
	void Highlight() 
	{
		//Do not highlight selected object again.
		if(gameObject != GameController.instance.GetSelectedObject() && !inInteraction)
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
	
	public bool HasBeenAccused()
	{
		return hasBeenAccused;
	}
	
	public void SetAccused()
	{
		hasBeenAccused = true;
		if(GetComponent<Suspect>() != null)
		{
			SendMessage("SetNervousState");
		}
	}
}
