using UnityEngine;

public class InputController : MonoBehaviour 
{
	public static InputController instance;
	
	#region component declarations
	NoteBook 			notebook;
	MovementManager 	movement;
	InteractionManager 	interaction;
	PauseMenu			pause;
	#endregion
	
	void Awake () 
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
		
		#region component initializations
		pause			= GetComponent<PauseMenu>();
		notebook		= gameObject.GetComponentInChildren<NoteBook>();
		movement 		= GetComponent<MovementManager> ();
		interaction		= GetComponent<InteractionManager> ();
		#endregion
	}
	
	// CHECK DEVICE INPUTS
	
	#region device inputs
	void CheckKeyBoardInputs() 
	{	
		#region interactions keyboard
		if(Keyboard.inputInteract() && !gazeModel.isEyeTrackerRunning && Mouse.rayTarget().collider != null)
		{
			GameController.instance.SetSelectedObject();
			interaction.StartInteraction(GameController.instance.GetSelectedObject());
		}
		
		if(Keyboard.inputReturn())
		{
			interaction.StopInteraction();
			GameController.instance.ClearSelections();
		}
		
		if(Keyboard.inputAccuse())
		{
			if(Mouse.rayTarget().collider != null)
			{
				interaction.StartAccusationOn(Mouse.rayTarget().collider.gameObject);
			}
		}
		#endregion
		
		//NOTEBOOK
		if(Keyboard.inputToggleNotebook())
		{
			notebook.ToggleNotebook();
		}
		
		//PAUSE
		if(Keyboard.inputPause())
		{
			pause.TogglePause();
		}
	}
	
	void CheckMouseInputs() 
	{	
		#region movement mouse
		if(!notebook.NoteBookIsOpen())
		{
			if(ScrollAreas.left.Contains(Mouse.Position()))		movement.turnLeft();
			
			if(ScrollAreas.right.Contains(Mouse.Position()))	movement.turnRight();
			
			if(ScrollAreas.top.Contains(Mouse.Position()))		movement.turnUp();
			
			if(ScrollAreas.bottom.Contains(Mouse.Position()))	movement.turnDown();
		}
		#endregion
		
		#region interactions mouse
		if(Mouse.leftClicked())
		{
			interaction.RotateItemLeft(GameController.instance.GetSelectedObject());
		}
		
		if(Mouse.rightClicked()) 
		{
			interaction.RotateItemRight(GameController.instance.GetSelectedObject());
		}
		#endregion
 	}
 	
	void CheckGazeInputs()
	{	
		if(!notebook.NoteBookIsOpen())
		{
			if(ScrollAreas.left.Contains(Gaze.Position()))		movement.turnLeft();
			
			if(ScrollAreas.right.Contains(Gaze.Position()))		movement.turnRight();
			//BUG
			if(ScrollAreas.top.Contains(Gaze.Position()))		movement.turnDown();
			
			if(ScrollAreas.bottom.Contains(Gaze.Position()))	movement.turnUp();
		}
	}
	
	void CheckGamepadInputs() 
	{	
		if(Gamepad.inputLeftTrigger())
		{
			Debug.Log("Left trigger");
		}
		
		if(Gamepad.inputRightTrigger())
		{
			Debug.Log("Right trigger");
		}
		
		if(Gamepad.inputInteract())
		{
			Debug.Log ("Pad");
		}
	}
	#endregion
	
	//CHECK CONTROLS SETTINGS
	
	#region controls settings
	/// <summary>
	/// If controls set to keyboard, uses keyboard and gazetracker (mouse if gazetracker not running) for inputs.
	/// </summary>
	public void KeyboardControls()
	{	
		if(gazeModel.isEyeTrackerRunning)
		{
			CheckGazeInputs();
		}
		else 
		{
			CheckMouseInputs();
		}	
		CheckKeyBoardInputs();	
	}
	
	/// <summary>
	/// If controls set to gamepad, uses gamepad and gazetracker for inputs.
	/// </summary>
	public void GamepadControls()
	{
		if(gazeModel.isEyeTrackerRunning)
		{
			CheckGamepadInputs();
			CheckGazeInputs();
		}
	}
	#endregion
}

[System.Serializable]
public class ScrollAreas
{
	public static Rect top 		= new Rect(0, Screen.height - Screen.height / 5f, Screen.width, Screen.height / 5f);
	public static Rect right 	= new Rect(Screen.width - Screen.width / 2.5f, 0, Screen.width / 2.5f, Screen.height);
	public static Rect bottom 	= new Rect(0, 0, Screen.width, Screen.height / 5f);
	public static Rect left 	= new Rect(0, 0, Screen.width / 2.5f, Screen.height);
}