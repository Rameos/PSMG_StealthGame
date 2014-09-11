using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using iViewX;

public class NoteBook : MonoBehaviour 
{
	ClueManager clue;
	InteractionManager interaction;
	
	public GUIStyle notebookStyle;
	public Texture notebookTexture;
	
	private Rect notebook;
	private float notebookX;
	private float notebookY;
	private float notebookWidth		= Screen.width / 3;
	private float notebookHeight 	= Screen.height * 0.7f;
	private float offset			= 10;
	
	private float noteHeight;
	private float noteWidth;
	
	private List<string> notes;
	
	private const int NOTEBOOK_ID = 0;
	private string notebookHeader = "NOTES";
	private bool isToggled = false;
	private List<GazeButton> gazeUI;
	
	public float setNervousTime = 7f;
	
	void Awake()
	{
		clue = GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
		interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>();
		
		notebookX 	= Screen.width - notebookWidth - offset;
		notebookY 	= Screen.height - notebookHeight;
		notebook 	= new Rect(notebookX, notebookY, notebookWidth, notebookHeight);
		
		noteHeight 	= notebookHeight * 0.1f;
		noteWidth 	= notebookWidth - (offset * 2);
	}
	
	void OnGUI()
	{
		if(isToggled)
		{
			notes = clue.GetFoundClues();
			notebook = GUI.Window(NOTEBOOK_ID, notebook, DisplayFoundClues, notebookHeader);
		}
	}
	
	void DisplayFoundClues(int ID)
	{
		for(int i = 0; i < notes.Count; i++)
		{
			if(GUI.Button(new Rect(offset, (offset * 2) + (noteHeight * i), noteWidth, noteHeight), notes[i]))
			{
				if(GameState.IsState(GameState.States.Interrogating))
				{
					Debug.Log("note: " + GameObject.Find(notes[i]));
					interaction.StartAccusationOn(GameObject.Find(notes[i]));
				}
			}
		}
	}
	
	public bool NoteBookIsOpen()
	{
		return isToggled;
	}
	
	public void ToggleNotebook()
	{
		if(!isToggled)
		{
			SoundManager.instance.PlaySoundEffect("Notebook");
		}
		isToggled = !isToggled;
		
		if(isToggled)
		{
			StartCoroutine("SetNervous");
		}
	}
	
	IEnumerator SetNervous()
	{
		float timer = 0f;
		while(isToggled && GameState.IsState(GameState.States.Interrogating))
		{
			if(timer == setNervousTime)
			{	
				GameController.instance.GetCurrentSuspect().GetComponent<Suspect>().SetNervousState();
			}
			timer++;
			yield return new WaitForSeconds(1f);
		}
	}
}
