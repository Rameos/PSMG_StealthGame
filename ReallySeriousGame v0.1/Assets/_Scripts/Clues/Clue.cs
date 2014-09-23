using UnityEngine;
using System.Collections;
using iViewX;

public class Clue : MonoBehaviourWithGazeComponent
{
	public string clueName;
	private Light highlight;
	public bool isHighlighted 	= false;
	public bool isDiscovered 	= false; //Discovered by player?
	public bool isVisible 		= true; //Visible on suspect?
	public bool isRelevant 		= false; //Relevant to solving the case?
	
	InteractionManager interaction;
	
	void Awake()
	{
		highlight = GetComponent<Light>();
		highlight.enabled = false;
		interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>();
	}
	
	#region mouse
	void OnMouseEnter()
	{
		if(!gazeModel.isEyeTrackerRunning)
		{
			OnEnterBehaviour();
		}
	}
	
	void OnMouseOver()
	{
		if(!gazeModel.isEyeTrackerRunning)
		{
			OnStayBehaviour();
		}
	}
	
	void OnMouseExit()
	{
		if(!gazeModel.isEyeTrackerRunning)
		{
			OnExitBehaviour();
		}
	}
	#endregion
	
	#region gaze
	public override void OnGazeEnter(RaycastHit hit)
	{
		if(gazeModel.isEyeTrackerRunning)
		{
			OnEnterBehaviour();
		}
	}
	
	public override void OnGazeStay(RaycastHit hit)
	{	
		if(gazeModel.isEyeTrackerRunning)
		{
			OnStayBehaviour();
			
			if(Keyboard.inputInteract())
			{
				GameController.instance.SetSelectedGazeObject(gameObject);
				interaction.StartInteraction(gameObject);
			}
			
			if(Keyboard.inputAccuse())
			{
				interaction.StartAccusationOn(gameObject);
			}
		}
	}
	
	public override void OnGazeExit()
	{
		if(gazeModel.isEyeTrackerRunning)
		{
			OnExitBehaviour();
		}
	}
	#endregion
	
	void OnEnterBehaviour()
	{
		HighlightClue();
	}
	
	void OnStayBehaviour()
	{
		if(Keyboard.inputInteract())
		{
			if(transform.parent.CompareTag("Suspect"))
			{
				transform.parent.SendMessage("RandomOnClueReaction", clueName);
			}
			ClueManager.instance.FoundClue(gameObject);
		}
		
		if(transform.parent.CompareTag("Suspect"))
		{
			transform.parent.SendMessage("FixatedOnClueReaction", clueName);
			/*if(transform.parent.GetComponent<Interactable>().HasBeenAccused())
			{
				transform.parent.SendMessage("SetNervousState");
			}
			transform.parent.SendMessage("SetIsFixating");*/
		}
	}
	
	void OnExitBehaviour()
	{
		UnHighlightClue();
	}
	
	/// <summary>
	/// Highlights the clue during interaction if it hasn't been discovered yet and is visible.
	/// </summary>
	
	void HighlightClue()
	{
		if(GameState.IsInteracting && !isHighlighted && isVisible)
		{	
			highlight.enabled = true;
			isHighlighted = true;
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
	
	public void SetDiscovered()
	{
		isDiscovered = true;
	}
	
	public void ToggleVisibility()
	{
		isVisible = !isVisible;
	}
}
