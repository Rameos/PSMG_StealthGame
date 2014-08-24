using UnityEngine;
using System.Collections;

public class VerbalResponse : MonoBehaviour 
{
	private string dir = "Sounds/Dialog/";
	
	private string newVOClipPath;
	
	private AudioClip newVOClip;
	
	SoundManager VO;

	void Awake()
	{
		VO = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
	}
	
	public void RandomVO()
	{
		newVOClipPath = dir + gameObject.name + "_Default_" + Suspect.state + "_" + Random.Range(0,2);
		PlayVO();
	}
	
	public void FixatedVO()
	{
		newVOClipPath = dir + gameObject.name + "_" + GameState.gameState + "_Positive_" + Random.Range(0,2);
		PlayVO();
	}
	
	public void FixatedClueVO(int clueID)
	{
	
	}
	
	public void RandomClueVO(int clueID)
	{
		
	}
	
	void PlayVO()
	{
		if(audio.isPlaying)
		{
			return;
		}
		
		audio.Stop();
		audio.clip = Resources.Load(newVOClipPath, typeof(AudioClip)) as AudioClip;
		audio.Play();
	}
}
