using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	public static ClueManager clueManager;
	
	List<GameObject> clues;
	bool isActivated = true;
	
	void Awake()
	{
		#region singleton
		if(clueManager == null) {
			DontDestroyOnLoad(gameObject);
			clueManager = this;
		} else if(clueManager != this) {
			Destroy(gameObject);
		}
		#endregion
		
		clues = new List<GameObject>(GameObject.FindGameObjectsWithTag("Clue"));
		DeactivateAllClues();
	}
	
	/// <summary>
	/// Activate all Clue objects on selected GameObject.
	/// </summary>
	/// <param name="selectedObject">Selected GameObject.</param>
	public void ActivateCluesOn(GameObject selectedObject)
	{
		foreach (Transform child in selectedObject.transform)
		{
			if(child.tag == "Clue")
				child.gameObject.SetActive(true);
		}
	}
	
	/// <summary>
	/// Deactivate all Clue objects on selected GameObject.
	/// </summary>
	/// <param name="selectedObject">Selected GameObject.</param>
	public void DeactivateCluesOn(GameObject selectedObject)
	{
		foreach (Transform child in selectedObject.transform)
		{
			if(child.tag == "Clue")
				child.gameObject.SetActive(false);
		}
	}
	
	public void DeactivateAllClues()
	{
		Debug.Log("Total clues in scene: " + clues.Count);
		if(isActivated)
		{
			foreach (GameObject clue in clues)
			{
				clue.SetActive(false);
			}
			isActivated = false;
		}
	}
}
