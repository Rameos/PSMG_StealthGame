﻿using UnityEngine;
using System;

public class InteractionManager : MonoBehaviour 
{
	bool isInteracting = false;

	Vector3 itemOriginalPos;
	public float itemDistanceFromCamera = 2f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	public float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;

    public delegate void DialogEvent (object sender, string data, int index);
    public static event DialogEvent PlayVoice;
    private Suspect activeSuspect;
	
	/// <summary>
	/// Starts interaction with selected object.
	/// </summary>
	public void StartInteraction(GameObject selection)
	{
		if(!isInteracting)
		{
			switch(selection.tag)
			{
			case "Interactable": 
				GameState.ChangeState(GameState.States.Inspecting);
				Inspect(selection);
				isInteracting = true;
				break;
				
			case "Suspect":
                //Debug.Log("Interrogating " + selection.GetComponent<Suspect>().currentSuspect.ToString());
				GameState.ChangeState(GameState.States.Interrogating);
				Interrogate(selection);
				isInteracting = true;
				break;
				
			case "Door":
				EnterDoor(); 
				break;
				
			default: break;
			}
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
		if(isInteracting)
		{
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
			GameState.ChangeState(GameState.States.InGame);
			isInteracting = false;
		}
		else
		{
			return;
		}
	}
	
	public bool IsInteracting()
	{
		return isInteracting;
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
        if (PlayVoice != null)
        {
            activeSuspect = suspect.GetComponent<Suspect>();
            //Debug.Log(activeSuspect.currentSuspect.ToString() + " " +  activeSuspect.numberOfConversations);
            if (PlayVoice != null)
            {
                PlayVoice(this, activeSuspect.currentSuspect.ToString(), activeSuspect.numberOfConversations);
            }
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
			interactable.transform.Rotate(Vector3.up * 50 * Time.deltaTime,Space.World);
	}
	
	public void RotateItemRight(GameObject interactable)
	{
		if(GameState.IsState(GameState.States.Inspecting))
			interactable.transform.Rotate(Vector3.down * 50 * Time.deltaTime,Space.World);
	}
}
