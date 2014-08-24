using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour 
{
	public static GameController gameControl;
	
	SoundManager sound;
	//ClueManager clueManager;
	
	//private string dataFileName = "/gameprogress.dat";
	
	int currentLevel = -1;
	
	void Awake() 
	{
		#region singleton
		if(gameControl == null) 
		{
			DontDestroyOnLoad(gameObject);
			gameControl = this;
		} 
		else if(gameControl != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
		sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
		//clueManager = GameObject.FindGameObjectWithTag("ClueManager").GetComponent<ClueManager>();
	}
	
	void Update () 
	{	
		CheckControls();
		CheckGameState();
	}
	/// <summary>
	/// Checks GameState and sets Background sound accordingly.
	/// </summary>
	void CheckGameState()
	{
		if(!(currentLevel == Application.loadedLevel))
		{
			switch(Application.loadedLevelName)
			{
			case "MainMenu":
				sound.StopAmbientSound();
				sound.PlayBGMusic(Application.loadedLevelName);
				GameState.ChangeState(GameState.States.MainMenu);
				break;
			case "BarScene":
			case "Scene_2":
				sound.StopBGMusic();
				sound.PlayAmbientSound(Application.loadedLevelName);
				GameState.ChangeState(GameState.States.InGame);
				break;
			default:
				break;
			}
			currentLevel = Application.loadedLevel;
		}
		
		ControllBGVolume();
	}
	
	void CheckControls()
	{
		if(!(Application.loadedLevel == 0))
		{
			if(ControlsOptions.IsKeyboardControls)
			{
				InputController.inputController.KeyboardControls();
			}
			else if(ControlsOptions.IsGamepadControls)
			{
				InputController.inputController.GamepadControls();
			}
		}
	}
	
	void ControllBGVolume()
	{
		if(GameState.IsInteracting)
		{
			sound.LowerBGVolume();
		}
		else
		{
			sound.DefaultBGVolume();
		}
	}
	
	/*
	#region save/load player data
	public void Save() 
	{
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + dataFileName, FileMode.Open);
		
		PlayerData data = new PlayerData();
		data.foundClues = foundClues;
		
		formatter.Serialize(file, data);
		file.Close();
	}
	
	public void Load() 
	{
		if(File.Exists(Application.persistentDataPath + dataFileName))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + dataFileName", FileMode.Open);
			PlayerData data = (PlayerData)formatter.Deserialize(file);
			file.Close();
			
			foundClues = data.foundClues;
		}
    }
    #endregion
    */
}

/*
[Serializable]
class PlayerData 
{
	public int foundClues;
}
*/
