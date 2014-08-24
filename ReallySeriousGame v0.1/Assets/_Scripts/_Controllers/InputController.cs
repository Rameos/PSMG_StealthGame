using UnityEngine;

public class InputController : MonoBehaviour 
{
	public static InputController inputController;
	
	#region component declarations
	NoteBook 			notebook;
	ClueManager 		clueManager;
	MovementManager 	movement;
	InteractionManager 	interaction;
	PauseMenu			pause;
	#endregion
	
	GameObject hitObject;
	GameObject selectedObject;

	void Awake () 
	{
		#region singleton
		if(inputController == null) 
		{
			inputController = this;
		} 
		else if(inputController != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
		#region component initializations
		pause			= GetComponent<PauseMenu>();
		notebook		= gameObject.GetComponentInChildren<NoteBook>();
		clueManager		= GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
		movement 		= GetComponent<MovementManager> ();
		interaction		= GetComponent<InteractionManager> ();
		#endregion
	}
	
	// CHECK DEVICE INPUTS
	
	#region device inputs
	void CheckKeyBoardInputs() 
	{	
		#region interactions keyboard
		if(Keyboard.inputInteract())
		{
			if(hitObject.tag != "Clue")
			{
				selectedObject = hitObject;
				
				interaction.StartInteraction(selectedObject);
				if(selectedObject != null)
					clueManager.ActivateCluesOn(selectedObject); //???
			}
			else
			{
				clueManager.FoundClue(hitObject);
			}
		}
		
		if(Keyboard.inputReturn())
		{
			//deactivate clues on object when quitting interaction
			if(selectedObject != null)
				clueManager.DeactivateCluesOn(selectedObject);
			
			interaction.StopInteraction();
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
		hitObject = Mouse.rayTarget().collider.gameObject;
		
		#region movement mouse
		if(ScrollAreas.left.Contains(Mouse.Position()))		movement.turnLeft();
			
		if(ScrollAreas.right.Contains(Mouse.Position()))	movement.turnRight();
			
		if(ScrollAreas.top.Contains(Mouse.Position()))		movement.turnUp();
			
		if(ScrollAreas.bottom.Contains(Mouse.Position()))	movement.turnDown();
		#endregion
		
		#region interactions mouse
		if(Mouse.leftClicked())
		{
			interaction.RotateItemLeft(selectedObject);
		}
		
		if(Mouse.rightClicked()) 
		{
			interaction.RotateItemRight(selectedObject);
		}
		#endregion
 	}
 	
	void CheckGazeInputs()
	{	
		hitObject = Gaze.rayTarget().collider.gameObject;
		
		if(ScrollAreas.left.Contains(Gaze.Position()))		movement.turnLeft();
		
		if(ScrollAreas.right.Contains(Gaze.Position()))		movement.turnRight();
		//BUG
		if(ScrollAreas.top.Contains(Gaze.Position()))		movement.turnDown();
			
		if(ScrollAreas.bottom.Contains(Gaze.Position()))	movement.turnUp();
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

//SCROLL AOI
[System.Serializable]
public class ScrollAreas
{
	public static Rect top 		= new Rect(0, Screen.height - Screen.height / 6, Screen.width, Screen.height / 6);
	public static Rect right 	= new Rect(Screen.width - Screen.width / 6, 0, Screen.width / 6, Screen.height);
	public static Rect bottom 	= new Rect(0, 0, Screen.width, Screen.height / 6);
	public static Rect left 	= new Rect(0, 0, Screen.width / 6, Screen.height);
}
