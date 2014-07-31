using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour 
{
	/// <summary>
	/// Pull object into camera center and switch Gamestate to inspecting. Return it to its original location afterwards.
	/// </summary>
	
	public void Inspect()
	{
		Debug.Log("Shush I'm concentrating");
	}
	
	/// <summary>
	/// Zoom camera onto suspect and switch Gamestate to Interrogating.
	/// </summary>
	
	public void Interrogate()
	{
		Debug.Log("'sup d00d");
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
		if(GameController.gameState == GameState.Inspecting)
		interactable.transform.Rotate(Vector3.up * 50 * Time.deltaTime,Space.World);
	}
	
	public void RotateItemRight(GameObject interactable)
	{
		if(GameController.gameState == GameState.Inspecting)
		interactable.transform.Rotate(Vector3.up * 50 * Time.deltaTime,Space.World);
	}
}
