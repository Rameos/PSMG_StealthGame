using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteBook : MonoBehaviour 
{
	ClueManager clue;
	
	public GUIStyle notebookStyle;
	public GUIStyle btnStyle;
	public Texture notebookTexture;
	public Texture barmannClue1, barmannClue2, barmannClue3;
	public Texture docClue1, docClue2, docClue3;
	//übergangsweise, muss noch refactored werden
	public Texture drink, mixbuch, gift, pille, pflanze, docbuch;
	private Texture clueNote;

	private float defaultButtonSize;

	private Rect notebook;
	private Rect notebookWindow;
	private float notebookX;
	private float notebookY;
	private float notebookWidth		= Screen.width*0.22f;
	private float notebookHeight 	= Screen.height * 0.9f;
	private float offset			= 30;
	
	private Rect note;
	private float noteHeight;
	private float noteWidth;
	
	private List<string> notes;

	private const int NOTEBOOK_ID = 0;
	private string notebookHeader = "NOTES";
	private bool isToggled = false;
	private bool clueNotesActive = false;
	
	void Awake()
	{
		clue = GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
		
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
		defaultButtonSize =notebook.width * 0.18f;



		GUI.DrawTexture(new Rect(0,0,notebook.width,notebook.height),notebookTexture,ScaleMode.StretchToFill,true);




		if (clue.CheckClue(0)) {
			if (GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue1, btnStyle)) {
				clueNote = drink;
				clueNotesActive = true;
			}
		}
		if (clue.CheckClue(1)) {
			if (GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue2, btnStyle)) {
				clueNote = mixbuch;
				clueNotesActive = true;
			}
		}
		if (clue.CheckClue(2)) {
			if (GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue3, btnStyle)) {
				clueNote = gift;
				clueNotesActive = true;
			}
		}
		if (clue.CheckClue(3)) {
			if (GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue1, btnStyle)) {
				clueNote = pille;
				clueNotesActive = true;
			}
		}
		if (clue.CheckClue(4)) {
			if (GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue2, btnStyle)) {
				clueNote = pflanze;
				clueNotesActive = true;
			}
		}
		if (clue.CheckClue(5)) {
			if (GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue3, btnStyle)) {
				clueNote = docbuch;
				clueNotesActive = true;
			}
		}


		if (clueNotesActive) {

			// verbugt, ergibt nullpointer
			//if (GUI.Button(new Rect(0, 0, notebook.width, notebook.height), clue.GetClueNotesAtPosition(0))) {

			if (GUI.Button(new Rect(0, 0, notebook.width, notebook.height), clueNote)) {
					clueNotesActive = false;
			}
		}

		//old
		for(int i = 0; i < notes.Count; i++)
		{
			if(GUI.Button(new Rect(offset, (offset * 2) + (noteHeight * i), noteWidth, noteHeight), notes[i]))
				Debug.Log("stuff");
		}
	}
	
	public void ToggleNotebook()
	{
		isToggled = !isToggled;
	}
	
}
