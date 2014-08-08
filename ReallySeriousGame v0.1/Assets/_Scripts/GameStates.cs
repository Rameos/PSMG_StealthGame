using UnityEngine;
using System.Collections;

public class GameState 
{
	public enum States
	{
		MainMenu,
		InGame,
		Paused,
		Inspecting,
		Interrogating
	}	
	public static States gameState = States.InGame;
	
	public static void ChangeState(States newGameState) 
	{
		if(gameState == newGameState) 
			return;  
		gameState = newGameState;  
	}
	
	public static bool IsState(States state) 
	{        
		if(gameState == state)
			return true;
		return false;
	}
	
	public static bool IsRunning 
	{
		get
		{
			return IsState(States.InGame);
		}
	}
	
	public static bool IsPaused 
	{
		get
		{
			return IsState(States.Paused);
		}
	}
	
	public static bool IsInteracting
	{
		get
		{
			return (IsState(States.Inspecting) || IsState(States.Interrogating));
		}
	}
}