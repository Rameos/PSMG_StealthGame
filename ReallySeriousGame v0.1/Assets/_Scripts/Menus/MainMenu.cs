using UnityEngine;
using System.Collections;
using System;
using iViewX;

public class MainMenu : MonoBehaviour 
{
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
		GUI.Box(new Rect(Screen.width * 0.25f, Screen.height * 0.1f, Screen.width * 0.5f, Screen.height * 0.8f), "SUPER SERIOUS \nDETECTIVE GAME");
		
		if(GUI.Button(new Rect(buttonXPos, buttonPos1, buttonWidth, buttonHeight), "Start Game")) 
		{
			Application.LoadLevel("BarScene");
		}
		
		if(GUI.Button(new Rect(buttonXPos, buttonPos2, buttonWidth, buttonHeight), "Load Save")) 
		{
			
		}
		
		if(GUI.Button(new Rect(buttonXPos, buttonPos3, buttonWidth, buttonHeight), "Set Controls")) 
		{
			
		}
		
		if(GUI.Button(new Rect(buttonXPos, buttonPos4, buttonWidth, buttonHeight), "Start Calibration"))
		{	
			GazeControlComponent.Instance.StartCalibration();
		}
		
		if(GUI.Button(new Rect(buttonXPos, buttonPos5, buttonWidth, buttonHeight), "Quit Game")) 
		{
			Application.Quit();
		}
	}
}
