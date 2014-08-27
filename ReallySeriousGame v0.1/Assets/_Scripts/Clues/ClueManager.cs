using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	//old
	static List<string> foundClues = new List<string>();


	public static ClueManager clueManager;

	public Texture bmDrink, bmMixbuch, bmGift, bmHand, bmFleck;
	public Texture docPille, docPlfanze, docBuch;
	public Texture detTatwaffe, detStoff;
	public Texture bmDrinkNote, bmMixbuchNote, bmGiftNote, bmHandNote, bmFleckNote, docPilleNote, docPlfanzeNote, docBuchNote, detStoffNote, detTatwaffeNote;

	static List<string> foundCluesBarmann = new List<string>();
	static List<string> foundCluesDoctor = new List<string>();
	static List<string> foundCluesDetective = new List<string>();

	
	private Dictionary<string, Texture> nameToTexture = new Dictionary<string, Texture>();
	private Dictionary<string, Texture> nameToTextureNote = new Dictionary<string, Texture>();
	
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
		#endregion

		fillLists ();

		fillDetectiveNotes ();

	}

	private void fillDetectiveNotes () {
		foundCluesDetective.Add ("detTatwaffe");
		foundCluesDetective.Add ("detStoff");
	}

	private void fillLists (){
		fillClueDict();
		fillClueNoteDict();
	}

	private void fillClueDict () {
		nameToTexture.Add("barmannDrink", bmDrink);
		nameToTexture.Add("barmannMixBuch", bmMixbuch);
		nameToTexture.Add("barmannGift", bmGift);
		nameToTexture.Add("barmannHand", bmHand);
		nameToTexture.Add("barmannFleck", bmFleck);
		nameToTexture.Add("docPille", docPille);
		nameToTexture.Add("docPflanze", docPlfanze);
		nameToTexture.Add("docBuch", docBuch);
		nameToTexture.Add("detTatwaffe", detTatwaffe);
		nameToTexture.Add("detStoff", detStoff);

	}

	private void fillClueNoteDict () {
		nameToTextureNote.Add("barmannDrink", bmDrinkNote);
		nameToTextureNote.Add("barmannMixBuch", bmMixbuchNote);
		nameToTextureNote.Add("barmannGift", bmGiftNote);
		nameToTextureNote.Add("barmannHand", bmHandNote);
		nameToTextureNote.Add("barmannFleck", bmFleckNote);
		nameToTextureNote.Add("docPille", docPilleNote);
		nameToTextureNote.Add("docPflanze", docPlfanzeNote);
		nameToTextureNote.Add("docBuch", docBuchNote);
		nameToTextureNote.Add("detTatwaffe", detTatwaffeNote);
		nameToTextureNote.Add("detStoff", detStoffNote);
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
		if (isAlreadyFound(selectedClue.clueName)) {
			if (selectedClue.clueName.Substring(0, 3) == "bar") {
				foundCluesBarmann.Add(selectedClue.clueName);
			}
			if (selectedClue.clueName.Substring(0, 3) == "doc") {
				foundCluesDoctor.Add(selectedClue.clueName);
			}
			foundClues.Add(selectedClue.clueName);
		}
	}

	private bool isAlreadyFound (string clueName) {
		for (int i = 0; i < foundClues.Count; i++){
			if (foundClues[i] == clueName) {
				return false;
			}
		}
		return true;
	}
	
	/// <summary>
	/// Returns all found clues as a List.
	/// </summary>
	/// <returns>List of type Clue.</returns>
	public List<string> GetFoundClues()
	{
		return foundClues;
	}

	public List<string> GetCluesBarmann() 
	{
		return foundCluesBarmann;
	}

	public List<string> GetCluesDoctor() 
	{
		return foundCluesDoctor;
	}

	public List<string> GetCluesDetective() 
	{
		return foundCluesDetective;
	}

	public Texture GetCluesTexture(string name) 
	{
		return nameToTexture[name];
	}
	
	public Texture GetCluesNoteTexture(string name) 
	{
		return nameToTextureNote[name];
	}
}
