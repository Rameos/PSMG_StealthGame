using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	public static ClueManager clueManager;
	public Texture drink, mixbuch, gift, pille, pflanze, docbuch;

	static List<string> foundClues = new List<string>();
	static List<bool> noteBookClues = new List<bool>();

	// verbugt
	static List<Texture> clueNotes;
	

	Clue selectedClue;
	
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
		for (int i = 0; i < 6; i++) {
			noteBookClues.Add(false);
		}
		// verbugt
		List<Texture> clueNotes = new List<Texture>()
		{
			drink, mixbuch, gift, pille, pflanze, docbuch
		};
		Debug.Log ("nitch " +clueNotes[0]);


		#endregion
	}
	
	/// <summary>
	/// Activate all Clue objects on selected GameObject.
	/// </summary>
	/// <param name="selectedObject">Selected GameObject.</param>
	public void ActivateCluesOn(GameObject selectedObject)
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

		Debug.Log (selectedClue.clueName);
		if (selectedClue.clueName.Contains("Drink")) {
			noteBookClues[0] = true;
		}if (selectedClue.clueName.Contains("Mixbuch")) {
			noteBookClues[1] = true;
		}if (selectedClue.clueName.Contains("Gift")) {
			noteBookClues[2] = true;
		}if (selectedClue.clueName.Contains("Pille")) {
			noteBookClues[3] = true;
		}if (selectedClue.clueName.Contains("Pflanze")) {
			noteBookClues[4] = true;
		}if (selectedClue.clueName.Contains("Docbuch")) {
			noteBookClues[5] = true;
		}

		// old
		//foundClues.Add(selectedClue.clueName);
	}
	
	/// <summary>
	/// Returns all found clues as a List.
	/// </summary>
	/// <returns>List of type Clue.</returns>
	public List<string> GetFoundClues()
	{
		return foundClues;
	}

	// verbugt
	public Texture GetClueNotesAtPosition(int index)
	{
		return clueNotes[index];
	}

	public bool CheckClue (int cluePosition) {
		return noteBookClues [cluePosition];
	}
}
