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
		if(Input.GetButtonDown("Interact") && !gazeModel.isEyeTrackerRunning && Mouse.rayTarget().collider != null)
		{
			GameController.instance.SetSelectedMouseObject();
			interaction.StartInteraction(GameController.instance.GetSelectedObject());
		}
		
		if(Input.GetButtonDown("Stop Interaction"))
		{
			interaction.StopInteraction();
			GameController.instance.ClearSelections();
		}
		
		if(Input.GetButtonDown("Accuse") && !gazeModel.isEyeTrackerRunning)
		{
			if(Mouse.rayTarget().collider != null)
			{
				interaction.StartAccusationOn(Mouse.rayTarget().collider.gameObject);
			}
		}
		#endregion
		
		#region movement
		
		if(GameState.IsState(GameState.States.InGame))
		{
			if(Keyboard.inputForward())		movement.moveForward();
			
			if(Keyboard.inputBackward())	movement.moveBackward();
			
			if(Keyboard.inputLeft())		movement.strafeLeft();
			
			if(Keyboard.inputRight())		movement.strafeRight();
		}
		#endregion
		
		//NOTEBOOK
		if(Input.GetButtonDown("Notebook"))
		{
			notebook.ToggleNotebook();
		}
		
		//PAUSE
		if(Input.GetButtonDown("Pause"))
		{
			pause.TogglePause();
		}
	}
	
	void CheckMouseInputs() 
	{
        //Debug.Log(Application.loadedLevelName);
        //Debug.Log(Application.loadedLevelName.Equals("MainMenu"));
		#region movement mouse
        if (!notebook.NoteBookIsOpen() && !Application.loadedLevelName.Equals("MainMenu"))
            {
                if (ScrollAreas.left.Contains(Mouse.Position()))    movement.turnLeft();
			
			    if(ScrollAreas.right.Contains(Mouse.Position()))	movement.turnRight();
			
			    if(ScrollAreas.top.Contains(Mouse.Position()))		movement.turnUp();
			
			    if(ScrollAreas.bottom.Contains(Mouse.Position()))	movement.turnDown();
		}
		#endregion
		
		#region interactions mouse
		if(Input.GetButton("Turn Horizontal"))
		{
			interaction.RotateItemLeft(GameController.instance.GetSelectedObject());
		}
		
		if(Input.GetButton("Turn Vertical")) 
		{
			interaction.RotateItemRight(GameController.instance.GetSelectedObject());
		}
		#endregion
 	}
 	
	void CheckGazeInputs()
	{
        if (!notebook.NoteBookIsOpen() && !Application.loadedLevelName.Equals("MainMenu"))
		{
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