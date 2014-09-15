using UnityEngine;
using System.Collections;
using iViewX;

public class Interactable : MonoBehaviourWithGazeComponent 
{

	private Color initialColor;
	public Color highlightColor = new Color (0.75f, 1f, 0.75f, 1f);
	bool isHighlighted = false;
	bool inInteraction = false;
	bool hasRecentlyBeenAccused = false;
	//int transitionToNeutral = 10;
	/*bool transitioning = false;
	bool isFixating = false;*/
	
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
		if(!GameState.IsPaused && !isHighlighted)
		{	
			Highlight();
		}
		
		if(this.tag == "Suspect")
		{
			/*if(hasRecentlyBeenAccused && GameState.IsState(GameState.States.Interrogating))
			{
				SendMessage("SetNervousState");
			}*/
			this.SendMessage("RandomReaction");
		}
	}
	
	void OnStayBehaviour()
	{
		/*isFixating = true;*/
		
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
		
		/*if(hasRecentlyBeenAccused)
		{	
			SendMessage("SetNervousState");
		}*/
		
		//UGGGGGGGGGGGG
		if(Keyboard.inputInteract())
		{
			if(GameState.IsState(GameState.States.InGame))
			{
				inInteraction = true;
			}
			if(GameState.IsState(GameState.States.Interrogating) && this.tag != "Suspect" && this.tag != "Box")
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
	
	void OnExitBehaviour()
	{
		if(isHighlighted)
		{
			UnHighlight();
		}
		
		/*if(this.tag == "Suspect")
		{
			if(!transitioning)
			{
				if(!(!NoteBook.instance.NoteBookIsOpen() && GameState.IsState(GameState.States.Interrogating) && !isFixating))
				{
					transitioning = false;
				}
				else
				{
					StartCoroutine("TransitionToNeutral");
				}
			}
		}
		
		isFixating = false;*/
	}
	
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
	
	/*IEnumerator TransitionToNeutral()
	{
		Debug.Log("transitioning");
		transitioning = true;
		
		while(!NoteBook.instance.NoteBookIsOpen() && GameState.IsState(GameState.States.Interrogating) && !isFixating)
		{
			Debug.Log("transition");
			float timer = 0;
			Debug.Log(timer);
			if(timer == transitionToNeutral)
			{
				SendMessage("SetNeutralState");
				timer = 0;
				transitioning = false;
			}
			timer++;
			yield return new WaitForSeconds(1f);
		}
	}
	
	public void SetIsFixating()
	{
		isFixating = true;
	}*/
	
	public bool HasBeenAccused()
	{
		return hasRecentlyBeenAccused;
	}
	
	public void SetAccused()
	{
		hasRecentlyBeenAccused = true;
		if(GetComponent<Suspect>() != null)
		{
			SendMessage("SetNervousState");
		}
	}
	
	public void ResetAccusedState()
	{
		hasRecentlyBeenAccused = false;
	}
}
