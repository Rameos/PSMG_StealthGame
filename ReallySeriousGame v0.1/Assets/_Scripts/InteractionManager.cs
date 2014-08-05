using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour 
{
	Vector3 itemOriginalPos;
	float itemDistanceFromCamera = 2f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;
	
	/// <summary>
	/// Pull object into camera center and switch Gamestate to inspecting.
	/// </summary>
	
	public void Inspect(GameObject item)
	{
		currentItem = item;
		itemOriginalPos = currentItem.transform.position;
		transform.LookAt(currentItem.transform);
		currentItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * itemDistanceFromCamera;
		
		GameState.ChangeState(GameState.States.Inspecting);
	}
	
	public void StopInspection()
	{
		currentItem.transform.position = itemOriginalPos;
		GameState.ChangeState(GameState.States.InGame);
	}
	
	/// <summary>
	/// Move Camera towards suspect and switch Gamestate to Interrogating.
	/// </summary>
	
	public void Interrogate(GameObject suspect)
	{
		currentSuspect = suspect;
		playerOriginalPos = transform.position;
		Vector3 suspectPos = new Vector3(currentSuspect.transform.position.x, transform.position.y, currentSuspect.transform.position.z); //Lock Y-Axis
		transform.LookAt(suspectPos);
		transform.position = Vector3.Lerp(transform.position, currentSuspect.transform.position, suspectDistanceFromPlayer);
		
		GameState.ChangeState(GameState.States.Interrogating);
	}
	
	public void StopInterrogation()
	{
		transform.position = playerOriginalPos;
		GameState.ChangeState(GameState.States.InGame);
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
