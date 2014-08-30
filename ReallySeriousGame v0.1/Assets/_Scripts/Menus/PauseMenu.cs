using UnityEngine;
using System.Collections;
using iViewX;

public class PauseMenu : MonoBehaviour 
{
	private bool isPaused = false;
	private GameState.States previousGameState;

	float buttonWidth 	= Screen.width 	* 0.3f;
	float buttonHeight 	= Screen.height * 0.1f;
	float buttonXPos 	= Screen.width 	* 0.35f;
	
	float buttonPos1 	= Screen.height * 0.3f;
	float buttonPos2 	= Screen.height * 0.4f;
	float buttonPos3 	= Screen.height * 0.5f;
	float buttonPos4 	= Screen.height * 0.6f;
	float buttonPos5 	= Screen.height * 0.7f;
	
	void OnGUI () 
	{	
		if(isPaused)
		{
			if(GUI.Button(new Rect(buttonXPos, buttonPos1, buttonWidth, buttonHeight), "Resume Game")) 
			{
				ResumeGame();
			}
			
			if(GUI.Button(new Rect(buttonXPos, buttonPos2, buttonWidth, buttonHeight), "Load Save")) 
			{
				
			}
			
			if(GUI.Button(new Rect(buttonXPos, buttonPos3, buttonWidth, buttonHeight), "Set Controls")) 
			{
				
			}
			
			if(GUI.Button(new Rect(buttonXPos, buttonPos4, buttonWidth, buttonHeight), "Recalibrate"))
			{	
				GazeControlComponent.Instance.StartCalibration();
			}
			
			if(GUI.Button(new Rect(buttonXPos, buttonPos5, buttonWidth, buttonHeight), "Return to Main Menu")) 
			{
				Application.LoadLevel("MainMenu");
				GameState.ChangeState(GameState.States.MainMenu);
				isPaused = false;
				Time.timeScale = 1;
			}
		}
	}
	
	public void PauseGame()
	{
		isPaused = true;
		previousGameState = GameState.gameState;
		GameState.ChangeState(GameState.States.Paused);
		Time.timeScale = 0;
	}
	
	public void ResumeGame()
	{
		isPaused = false;
		GameState.ChangeState(previousGameState);
		Time.timeScale = 1;
	}
	
	public void TogglePause()
	{
		isPaused = !isPaused;
		
		if(isPaused)
		{
			PauseGame();
		}
		else
		{
			ResumeGame();
		}
	}
}
