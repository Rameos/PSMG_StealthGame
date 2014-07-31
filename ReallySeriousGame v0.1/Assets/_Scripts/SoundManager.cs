using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	// Use this for initialization
	void Awake () 
	{
		#region singleton
		if(soundManager == null) 
		{
			DontDestroyOnLoad(gameObject);
			soundManager = this;
		} 
		else if(soundManager != this) 
		{
			Destroy(gameObject);
		}
		#endregion
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
