using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour 
{
	bool isInteracting = false;

	Vector3 itemOriginalPos;
	public float itemDistanceFromCamera = 2f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	public float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;

    public delegate void DialogEvent (object sender, string e);
    public static event DialogEvent PlayVoice;
	
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
				break;
				
			case "Suspect":
				GameState.ChangeState(GameState.States.Interrogating);
				Interrogate(selection); 
				break;
				
			case "Door":
				GameState.ChangeState(GameState.States.InGame);
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
		if(isInteracting)
		{
			switch(GameState.gameState)
			{
			case GameState.States.Inspecting:
				GameState.ChangeState(GameState.States.InGame);
				StopInspection();
				break;
				
			case GameState.States.Interrogating:
				GameState.ChangeState(GameState.States.InGame);
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
	}
	
	/// <summary>
	/// Transition to next level
	/// </summary>
	public void EnterDoor()
	{
		Application.LoadLevel("Scene_2");
		Debug.Log ("Entered door");

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
