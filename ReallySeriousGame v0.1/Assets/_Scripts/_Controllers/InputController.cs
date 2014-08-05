using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour 
{
	public static InputController inputController;
	
	public static InputOption controls;
	
	#region component declarations
	PauseMenu pauseMenu;
	MovementManager movement;
	InteractionManager interaction;
	KeyboardInput keyboard;
	GamepadInput pad;
	MouseInput mouse;
	GazeInput gaze;
	#endregion
	
	GameObject hitObject;
	GameObject selectedObject;

	void Awake () 
	{
		#region singleton
		if(inputController == null) 
		{
			DontDestroyOnLoad(gameObject);
			inputController = this;
		} 
		else if(inputController != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
		#region component initializations
		pauseMenu		= GetComponent<PauseMenu> ();
		movement 		= GetComponent<MovementManager> ();
		interaction		= GetComponent<InteractionManager> ();
		keyboard 		= GetComponent<KeyboardInput> ();
		pad 			= GetComponent<GamepadInput> ();
		mouse 			= GetComponent<MouseInput> ();
		gaze 			= GetComponent<GazeInput> ();
		#endregion
		
		controls = InputOption.KeyboardControls;
	}

	void Update () 
	{	
		if(!GameState.IsState(GameState.States.Paused))
		{
			KeyboardControls();
			GamepadControls();
		}
	}
	
	// CHECK DEVICE INPUTS
	
	#region device inputs
	void CheckKeyBoardInputs() 
	{	
		#region interactions keyboard
		if(keyboard.inputInteract() && GameState.IsRunning)
		{
			selectedObject = hitObject;
			
			switch(selectedObject.tag)
			{
				case "Interactable": 
					interaction.Inspect(selectedObject); 
					break;
					
				case "Suspect":
					interaction.Interrogate(selectedObject); 
					break;
					
				case "Door":
					interaction.EnterDoor(); 
					break;
				
				default: break;
			}
		}
		#endregion
		
		if(keyboard.inputPause())
		{
			pauseMenu.Open();
		}
		
		if(keyboard.inputReturn())
		{
			switch(GameState.gameState)
			{
				case GameState.States.Inspecting:
					interaction.StopInspection();
					break;
				
				case GameState.States.Interrogating:
					interaction.StopInterrogation();
					break;
				
				default: break;
			}
		}
	}
	
	void CheckMouseInputs() 
	{	
		hitObject = mouse.rayTarget().collider.gameObject;
		
		if(!GameState.IsState(GameState.States.Inspecting))
		{
			#region movement mouse
			if(ScrollAreas.left.Contains(mouse.Position()))		movement.turnLeft();
			
			if(ScrollAreas.right.Contains(mouse.Position()))	movement.turnRight();
			
			if(ScrollAreas.top.Contains(mouse.Position()))		movement.turnUp();
			
			if(ScrollAreas.bottom.Contains(mouse.Position()))	movement.turnDown();
			#endregion
		}
		
		#region interactions mouse
		if(mouse.leftClicked())
		{
			interaction.RotateItemLeft(selectedObject);
		}
		
		if(mouse.rightClicked()) 
		{
			interaction.RotateItemRight(selectedObject);
		}
		#endregion
 	}
 	
	void CheckGazeInputs()
	{	
		hitObject = gaze.rayTarget().collider.gameObject;
		
		if(GameState.IsRunning)
		{
			if(ScrollAreas.left.Contains(gaze.Position()))		movement.turnLeft();
			
			if(ScrollAreas.right.Contains(gaze.Position()))		movement.turnRight();
			//BUG
			if(ScrollAreas.top.Contains(gaze.Position()))		movement.turnDown();
			
			if(ScrollAreas.bottom.Contains(gaze.Position()))	movement.turnUp();
		}
	}
	
	void CheckGamepadInputs() 
	{	
		if(pad.inputLeftTrigger())
		{
			Debug.Log("Left trigger");
		}
		
		if(pad.inputRightTrigger())
		{
			Debug.Log("Right trigger");
		}
		
		if(pad.inputInteract())
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
		if(controls == InputOption.KeyboardControls)
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
	}
	
	/// <summary>
	/// If controls set to gamepad, uses gamepad and gazetracker for inputs.
	/// </summary>
	public void GamepadControls()
	{
		if(controls == InputOption.GamepadControls && gazeModel.isEyeTrackerRunning)
		{
			CheckGamepadInputs();
			CheckGazeInputs();
		}
	}
	#endregion
}
