using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteBook : MonoBehaviour 
{
	ClueManager clue;
	
	public GUIStyle notebookStyle;
	public GUIStyle btnStyle;
	public Texture notebookTextureClean, notebookTextureAll, notebookInfo;
	public Texture buttonChar , buttonClues, buttonHome;

	private Texture clueNote, notebookTexture;

	private float defaultButtonSize;

	private Rect notebook;
	private Rect notebookWindow;
	private float notebookX;
	private float notebookY;
	private float notebookWidth		= Screen.width*0.22f;
	private float notebookHeight 	= Screen.height * 0.9f;
	private float offset			= 30;

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
	private bool startFensterActive = true;
	private bool infoIsActive = false;
	
	void Awake()
	{
		clue = GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
		
		notebookX 	= Screen.width - notebookWidth - offset;
		notebookY 	= Screen.height - notebookHeight;
		notebook 	= new Rect(notebookX, notebookY, notebookWidth, notebookHeight);

	}
	
	void OnGUI()
	{
		if(isToggled)
		{
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

		if (startFensterActive) {
			notebookTexture = notebookTextureClean;
		} else {
			notebookTexture = notebookTextureAll;
		}


		if (startFensterActive && !infoIsActive) {
			float buttonPosY = notebook.height*0.27f;
			float buttonPosX = offset*2.5f;		
			float noteHeight = notebookHeight * 0.2f;
			float noteWidth = notebookWidth - buttonPosX*2;
			
			if (GUI.Button(new Rect(buttonPosX, buttonPosY, noteWidth, noteHeight), buttonChar)) {
				infoIsActive = true;
			}

			if (GUI.Button(new Rect(buttonPosX, buttonPosY*2, noteWidth, noteHeight), buttonClues)) {
				startFensterActive = false;
			}


		} else {
			showClues (cluesBarmann, barmannsCluesName);
			showClues (cluesDoctor, doctorCluesName);
			showClues (cluesDetective, detectiveCluesName);

			if (clueNotesActive) {
				if (GUI.Button(new Rect(0, 0, notebook.width, notebook.height), clueNote)) {
					clueNotesActive = false;
				}
			}
		}

		if (infoIsActive) {
			GUI.DrawTexture(new Rect(0,0,notebook.width,notebook.height),notebookInfo,ScaleMode.StretchToFill,true);
		}

		if (GUI.Button(new Rect(notebook.width/2-(defaultButtonSize*0.8f)/2,notebook.height*0.88f,defaultButtonSize*0.8f,defaultButtonSize*0.8f), buttonHome, btnStyle)) {
			startFensterActive = true;
			infoIsActive = false;
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
