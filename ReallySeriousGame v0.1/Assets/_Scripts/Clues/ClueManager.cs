using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	public static ClueManager clueManager;
	
	List<GameObject> clues;
	List<Clue> foundClues = new List<Clue>();
	Clue selectedClue;
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
	
	/// <summary>
	/// Sets the selected Clue to discovered and adds it to the found clues list.
	/// </summary>
	/// <param name="newClue">Selected Clue.</param>
	public void FoundClue(GameObject newClue)
	{
		selectedClue = newClue.GetComponent<Clue>();
		selectedClue.SetDiscovered();
		foundClues.Add(selectedClue);
	}
	
	/// <summary>
	/// Returns all found clues as a List.
	/// </summary>
	/// <returns>List of type Clue.</returns>
	public List<Clue> GetFoundClues()
	{
		return foundClues;
	}
	
	void DeactivateAllClues()
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
