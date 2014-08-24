using UnityEngine;
using System.Collections;
using iViewX;

[System.Serializable]
public static class SuspectID
{
	public const int BARKEEP_ID = 0;
	public const int DOCTOR_ID = 1;
}

public class Suspect : MonoBehaviourWithGazeComponent 
{
	public enum SuspectState
	{
		Positive,
		Neutral,
		Negative
	}
	
	public static SuspectState state = SuspectState.Neutral;
	public int suspectID;
	
	private BehaviourController behaviour;
	
	void Awake()
	{
		behaviour = GetComponent<BehaviourController>();
	}
	
	void OnMouseEnter()
	{
		behaviour.RandomReaction();
	}
	
	void OnMouseOver()
	{
		behaviour.FixatedReaction();
	}
	
	public override void OnGazeEnter(RaycastHit hit)
	{
		
	}
	
	public override void OnGazeStay(RaycastHit hit)
	{
		
	}
	
	public override void OnGazeExit()
	{
		
	}
}
