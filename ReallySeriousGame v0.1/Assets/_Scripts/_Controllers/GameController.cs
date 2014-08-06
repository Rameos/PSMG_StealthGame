using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour 
{
	public static GameController gameControl;
	
	SoundManager sound;
	
	//InputController inputController;
	
	//private string dataFileName = "/gameprogress.dat";
	
	void Awake() 
	{
		#region singleton
		if(gameControl == null) {
			DontDestroyOnLoad(gameObject);
			gameControl = this;
		} else if(gameControl != this) {
			Destroy(gameObject);
		}
		#endregion
		
		sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		
		//inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
	}
	
	void Update () 
	{	
		CheckGameState();
	}
	
	void CheckGameState()
	{
		if(!GameState.IsPaused && !InteractionManager.isInteracting)
		{
			if(Application.loadedLevelName == "MainMenu" && !GameState.IsState(GameState.States.MainMenu))
			{
				GameState.ChangeState(GameState.States.MainMenu);
				sound.PlayBackgroundSound("music");
			}
			if(Application.loadedLevelName == "BarScene" && !GameState.IsState(GameState.States.InGame))
			{
				GameState.ChangeState(GameState.States.InGame);
				sound.PlayBackgroundSound("ambient");
			}
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
