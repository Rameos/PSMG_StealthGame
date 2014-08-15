using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	public static ClueManager clueManager;
	
	static List<string> foundClues = new List<string>();
	Clue selectedClue;
	bool cluesActivated = false;
	
	void Awake ()
	{
		#region singleton
		if(clueManager == null) 
		{
			DontDestroyOnLoad(gameObject);
			clueManager = this;
		} 
		else if(clueManager != this) 
		{
			Destroy(gameObject);
		}
		#endregion
	}
	
	/// <summary>
	/// Activate all Clue objects on selected GameObject.
	/// </summary>
	/// <param name="selectedObject">Selected GameObject.</param>
	public void ActivateCluesOn(GameObject selectedObject)
	{
		if(!cluesActivated)
		{
			foreach (Transform child in selectedObject.transform)
			{
				string childClueName = child.GetComponent<Clue>().clueName;
				if(child.tag == "Clue")
				{
					if(!foundClues.Contains(childClueName))
						child.gameObject.SetActive(true);
				}
			}
			cluesActivated = true;
		}
		else
		{
			return;
		}
	}
	
	/// <summary>
	/// Deactivate all Clue objects on selected GameObject.
	/// </summary>
	/// <param name="selectedObject">Selected GameObject.</param>
	public void DeactivateCluesOn(GameObject selectedObject)
	{
		if(cluesActivated)
		{
			foreach (Transform child in selectedObject.transform.parent != null ? selectedObject.transform.parent : selectedObject.transform)
			{
				if(child.tag == "Clue")
					child.gameObject.SetActive(false);
			}
			cluesActivated = false;
		}
		else
		{
			return;
		}
	}
	
	/// <summary>
	/// Sets the selected Clue to discovered and adds it to the found clues list.
	/// </summary>
	/// <param name="newClue">Selected Clue.</param>
	public void FoundClue(GameObject newClue)
	{
		if(newClue.tag == "Clue")
		{
			selectedClue = newClue.GetComponent<Clue>();
			selectedClue.SetDiscovered();
			if(!foundClues.Contains(selectedClue.clueName))
				foundClues.Add(selectedClue.clueName);
		}
	}
	
	/// <summary>
	/// Returns all found clues as a List.
	/// </summary>
	/// <returns>List of type Clue.</returns>
	public List<string> GetFoundClues()
	{
		return foundClues;
	}
}
