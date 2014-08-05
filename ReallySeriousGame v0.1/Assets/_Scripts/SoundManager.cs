using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	//public static SoundManager soundManager;
	
	public AudioClip[] musicClips;
	public AudioClip[] ambientClips;
	
	private AudioClip backgroundSound;
	
	void Awake () 
	{
		/*#region singleton
		if(soundManager == null) 
		{
			DontDestroyOnLoad(gameObject);
			soundManager = this;
		} 
		else if(soundManager != this) 
		{
			Destroy(gameObject);
		}
		#endregion*/
	}
	
	void Update () 
	{
	}
	
	void PlayBackgroundSound() 
	{
	}
}
