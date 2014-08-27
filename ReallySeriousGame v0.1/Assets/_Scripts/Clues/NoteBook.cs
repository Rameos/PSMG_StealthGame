using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteBook : MonoBehaviour 
{
	ClueManager clue;
	
	public GUIStyle notebookStyle;
	public GUIStyle btnStyle;
	public Texture notebookTexture;
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
//	private float noteHeight;
//	private float noteWidth;
	
//	private List<string> notes;
	private List<string> cluesBarmann;
	private List<string> cluesDoctor;
	private List<string> cluesDetective;

	private string barmannsCluesName = "barmannClues";
	private string doctorCluesName = "doctorClues";
	private string detectiveCluesName = "detectiveClues";


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
		
//		noteHeight 	= notebookHeight * 0.1f;
//		noteWidth 	= notebookWidth - (offset * 2);
	}
	
	void OnGUI()
	{
		//Debug.Log ("list "+ clue.GetClueNotesAtPosition(0));

		if(isToggled)
		{
		
//			notes = clue.GetFoundClues();
			cluesBarmann = clue.GetCluesBarmann();
			cluesDoctor = clue.GetCluesDoctor();
			cluesDetective = clue.GetCluesDetective();

			notebook = GUI.Window(NOTEBOOK_ID, notebook, DisplayFoundClues, notebookHeader, notebookStyle);
		}
	}
	
	void DisplayFoundClues(int ID)
	{
		defaultButtonSize = notebook.width * 0.18f;

		GUI.DrawTexture(new Rect(0,0,notebook.width,notebook.height),notebookTexture,ScaleMode.StretchToFill,true);

		showClues (cluesBarmann, barmannsCluesName);
		showClues (cluesDoctor, doctorCluesName);
		showClues (cluesDetective, detectiveCluesName);
//
//
//		if (clue.CheckClue(0)) {
//			if (GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue1, btnStyle)) {
//				clueNote = drink;
//				clueNotesActive = true;
//			}
//		}
//		if (clue.CheckClue(1)) {
//			if (GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue2, btnStyle)) {
//				clueNote = mixbuch;
//				clueNotesActive = true;
//			}
//		}
//		if (clue.CheckClue(2)) {
//			if (GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue3, btnStyle)) {
//				clueNote = gift;
//				clueNotesActive = true;
//			}
//		}
//		if (clue.CheckClue(3)) {
//			if (GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue1, btnStyle)) {
//				clueNote = pille;
//				clueNotesActive = true;
//			}
//		}
//		if (clue.CheckClue(4)) {
//			if (GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue2, btnStyle)) {
//				clueNote = pflanze;
//				clueNotesActive = true;
//			}
//		}
//		if (clue.CheckClue(5)) {
//			if (GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue3, btnStyle)) {
//				clueNote = docbuch;
//				clueNotesActive = true;
//			}
//		}


		if (clueNotesActive) {
			if (GUI.Button(new Rect(0, 0, notebook.width, notebook.height), clueNote)) {
					clueNotesActive = false;
			}
		}

	}
	private void showClues (List<string> clues, string whosClues) {
		float widthMulti = 0.18f;
		float heightMulti = 0;
		int multiWidth;
		if (whosClues.Contains(barmannsCluesName)) {
			heightMulti = 0.23f;
		}
		if (whosClues == doctorCluesName) {
			heightMulti = 0.50f;
		}
		if (whosClues == detectiveCluesName) {
			heightMulti = 0.76f;
		}

		for (int i = 0; i < clues.Count; i++) {
			float buttonPosY;
			float buttonPosX;
			
			if (i < 3) {
				multiWidth = i;
				buttonPosY = heightMulti;
			}else {
				multiWidth = i-3;
				buttonPosY = heightMulti + 0.10f;
			}
			buttonPosX = widthMulti + 0.23f*multiWidth;
			
			if (GUI.Button(new Rect(notebook.width*buttonPosX, notebook.height*buttonPosY, defaultButtonSize, defaultButtonSize), clue.GetCluesTexture(clues[i]), btnStyle)) {
				clueNote = clue.GetCluesNoteTexture(clues[i]);
				clueNotesActive = true;
			}
		}
	}


	public void ToggleNotebook()
	{
		isToggled = !isToggled;
	}

}
