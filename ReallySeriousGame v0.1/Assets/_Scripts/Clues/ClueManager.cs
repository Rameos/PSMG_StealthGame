using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClueManager : MonoBehaviour 
{
	public static ClueManager clueManager;
	
	//private GameObject[] allClues;
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
		Debug.Log(clues.Count);
		DeactivateClues();
	}
	
	public void ActivateClues()
	{
		if(!isActivated)
		{
			foreach (GameObject clue in clues)
			{
				clue.SetActive(true);
			}
			isActivated = true;
		}
	}
	
	public void DeactivateClues()
	{
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
