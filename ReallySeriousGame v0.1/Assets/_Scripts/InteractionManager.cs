using UnityEngine;
using System;

public class InteractionManager : MonoBehaviour 
{
	public float turnSpeed = 66f;
	private bool isInteracting = false;

	Vector3 itemOriginalPos;
	public float itemDistanceFromCamera = 2f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	public float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;
	
	GameObject currentSelection;
	
	/// <summary>
	/// Starts interaction with selected object.
	/// </summary>
	public void StartInteraction(GameObject selection)
	{
		if(selection.tag != "Clue")
		{
			ClueManager.instance.ActivateCluesOn(selection);
			currentSelection = selection;
		}
		else
		{
			ClueManager.instance.FoundClue(selection);
		}
		
		if(!isInteracting)
		{
			switch(selection.tag)
			{
			case "Interactable": 
				Inspect(selection);
				break;
				
			case "Suspect":
				Interrogate(selection);
				break;
				
			case "Door":
				EnterDoor(); 
				break;
				
			default: break;
			}
			isInteracting = true;
		}
		else
		{
			return;
		}
	}
	
	/// <summary>
	/// Stops interaction with selected object.
	/// </summary>
	public void StopInteraction()
	{
		if(GameState.IsInteracting)
		{
			ClueManager.instance.DeactivateCluesOn(currentSelection);
			
			switch(GameState.gameState)
			{
			case GameState.States.Inspecting:
				StopInspection();
				break;
				
			case GameState.States.Interrogating:
				StopInterrogation();
				break;
				
			default: break;
			}
			isInteracting = false;
		}
		else
		{
			return;
		}
	}
	
	/// <summary>
	/// Pull object into camera center.
	/// </summary>
	public void Inspect(GameObject item)
	{
		currentItem = item;
		#region position item
		itemOriginalPos = currentItem.transform.position;
		transform.LookAt(currentItem.transform);
		currentItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * itemDistanceFromCamera;
		#endregion
        if (PlayVoice != null)
        {
            PlayVoice(this, "Detective", 4);
        }
	}
	
	/// <summary>
	/// Quit Inspection and return item to its original position
	/// </summary>
	public void StopInspection()
	{
		currentItem.transform.position = itemOriginalPos;
	}
	
	/// <summary>
	/// Move Player towards suspect.
	/// </summary>
	public void Interrogate(GameObject suspect)
	{
            activeSuspect = suspect.GetComponent<Suspect>();
        if (PlayVoice != null)
        {
            //Debug.Log(activeSuspect.currentSuspect.ToString() + " " +  activeSuspect.numberOfConversations);
            //if (PlayVoice != null)
            //{
            //    PlayVoice(this, activeSuspect.currentSuspect.ToString(), activeSuspect.numberOfConversations);
            //}
        }
		currentSuspect = suspect;
		#region position player
		playerOriginalPos = transform.position;
		Vector3 suspectPos = new Vector3(currentSuspect.transform.position.x, transform.position.y, currentSuspect.transform.position.z); //Lock Y-Axis
		transform.LookAt(suspectPos);
		transform.position = Vector3.Lerp(transform.position, currentSuspect.transform.position, suspectDistanceFromPlayer);
		#endregion
	}
	
	/// <summary>
	/// Quit Interrogation and return player to his original location
	/// </summary>
	public void StopInterrogation()
	{
		transform.position = playerOriginalPos;
        activeSuspect.numberOfConversations++;
	}
	
	/// <summary>
	/// Transition to next level
	/// </summary>
	public void EnterDoor()
	{
		Application.LoadLevel("Scene_2");
	}
	
	public void RotateItemLeft(GameObject interactable)
	{	
		if(GameState.IsState(GameState.States.Inspecting))
			interactable.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime,Space.World);
	}
	
	public void RotateItemRight(GameObject interactable)
	{
		if(GameState.IsState(GameState.States.Inspecting))
			interactable.transform.Rotate(Vector3.down * turnSpeed * Time.deltaTime,Space.World);
	}
}
