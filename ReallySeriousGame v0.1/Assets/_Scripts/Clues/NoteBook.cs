using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using iViewX;

public class NoteBook : MonoBehaviour 
{
	public static NoteBook instance;

	ClueManager clueManager;
	InteractionManager interaction;
	
	public GUIStyle notebookStyle;
	public Texture notebookTexture;
	
	private Rect notebook;
	private float notebookX;
	private float notebookY;
	private float notebookWidth		= Screen.width / 3;
	private float notebookHeight 	= Screen.height * 0.85f;
	private float offset			= 10;
	
	private float noteHeight;
	private float noteWidth;
	
	private List<string> notes = new List<string>();
	
	private bool isToggled = false;
	
	private GazeButton infoBox;
	private bool isInfoBoxActive = false;
	private Texture2D clueInfoBox;
	private string infoBoxDir = "Notebook/";
	
	private List<GazeButton> gazeUI = new List<GazeButton>();
	public GUIStyle gazeStyle;
	
	public float setNervousTime = 5f;
	
	void Awake()
	{
		#region singleton
		if(instance == null) 
		{
			instance = this;
		} 
		else if(instance != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
		clueManager = GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
		interaction = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>();
	}
	
	void Start()
	{
		notebookX 	= Screen.width - notebookWidth - offset;
		notebookY 	= Screen.height - notebookHeight;
		notebook 	= new Rect(notebookX, notebookY, notebookWidth, notebookHeight);
		
		noteHeight 	= notebookHeight * 0.08f;
		noteWidth 	= notebookWidth * 0.5f - (offset * 2);
	}
	
	void OnGUI()
	{
		if(isToggled)
		{
			GUI.DrawTexture(notebook,notebookTexture,ScaleMode.ScaleToFit,true);
			//GUI.Box(notebook, notebookTexture);
			
			foreach(GazeButton button in gazeUI)
			{
				button.OnGUI();
			}
			
			if(isInfoBoxActive)
			{
				buttonCallbackListener3 buttonAction3 = DeactivateInfoBox;
				infoBox = new GazeButton(notebook, clueInfoBox, gazeStyle, buttonAction3);
				infoBox.OnGUI();
			}
		}
	}
	
	void Update()
	{
		if(isToggled)
		{
			foreach(GazeButton button in gazeUI)
			{
				button.Update();
			}
			if(isInfoBoxActive)
			{
				infoBox.Update();
			}
		}
	}
	
	public void UpdateNoteButtonList()
	{
		gazeUI.Clear();
		
		notes = clueManager.GetFoundClues();
		
		for(int i = 0; i < notes.Count; i++)
		{
			buttonCallbackListener buttonAction = NoteAccusation;
			buttonCallbackListener2 buttonAction2 = NoteSelection;
			gazeUI.Add(new GazeButton(new Rect(notebookX + noteWidth / 2 + offset * 2, notebookY + notebookHeight / 6 + (noteHeight * i), noteWidth, noteHeight), notes[i], gazeStyle, buttonAction, buttonAction2));
		}
	}
	
	public void NoteAccusation(GameObject note)
	{
		if(!isInfoBoxActive)
		{
			if(GameState.IsState(GameState.States.Interrogating))
			{
				interaction.StartAccusationOn(note);
			}
		}
	}
	
	public void NoteSelection(string itemName)
	{
		if(!isInfoBoxActive)
		{
			Debug.Log(infoBoxDir + itemName);
			clueInfoBox = Resources.Load(infoBoxDir + itemName, typeof(Texture2D)) as Texture2D;
			isInfoBoxActive = true;
		}
	}
	
	public void DeactivateInfoBox()
	{
		if(isInfoBoxActive)
		{
			isInfoBoxActive = false;
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
