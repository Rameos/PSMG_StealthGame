using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour 
{
	public static GameController gameControl;
	
	public static GameState gameState;
	
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
	}
	
	void Update () 
	{
		
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
