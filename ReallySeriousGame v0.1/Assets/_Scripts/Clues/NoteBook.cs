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
			GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize*2), barmannClue1, btnStyle);
		}
		if (clue.CheckClue(1)) {
			GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue2, btnStyle);
		}
		if (clue.CheckClue(2)) {
			GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.23f, defaultButtonSize, defaultButtonSize), barmannClue3, btnStyle);
		}
		if (clue.CheckClue(3)) {
			GUI.Button(new Rect(notebook.width*0.17f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue1, btnStyle);
		}
		if (clue.CheckClue(4)) {
			GUI.Button(new Rect(notebook.width*0.41f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue2, btnStyle);
		}
		if (clue.CheckClue(5)) {
			GUI.Button(new Rect(notebook.width*0.65f, notebook.height*0.39f, defaultButtonSize, defaultButtonSize), docClue3, btnStyle);
		}

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

	/*
	public Rect windowRect0 = new Rect(20, 20, 120, 50);
	public Rect windowRect1 = new Rect(20, 100, 120, 50);
	void OnGUI() {
		GUI.color = Color.red;
		windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "Red Window");
		GUI.color = Color.green;
		windowRect1 = GUI.Window(1, windowRect1, DoMyWindow, "Green Window");
	}
	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
			print("Got a click in window with color " + GUI.color);
		
		GUI.DragWindow(new Rect(0, 0, 1000, 1000));
	}
	*/
}
