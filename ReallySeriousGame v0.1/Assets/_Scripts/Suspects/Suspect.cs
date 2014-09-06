using UnityEngine;
using System.Collections;

public class Suspect : MonoBehaviour 
{
	public enum SuspectState
	{
		Neutral,
		Nervous
	}
	
	public static SuspectState state = SuspectState.Neutral;
	public int suspectID;
	
	private BehaviourController behaviour;
	
	void Awake()
	{
		behaviour = GetComponent<BehaviourController>();
	}
	
	void Update()
	{
		//Debug.Log("in action: " + behaviour.IsInAction);
	}
	
	public void SetNervousState()
	{
		state = SuspectState.Nervous;
	}
	
	public void SetNeutralState()
	{
		state = SuspectState.Neutral;
	}
}
