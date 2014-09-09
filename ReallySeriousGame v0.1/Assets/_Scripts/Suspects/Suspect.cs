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
	
	//private BehaviourController behaviour;
	
	void Awake()
	{
		//behaviour = GetComponent<BehaviourController>();
	}
	
	void Update()
	{
		//Debug.Log("in action: " + behaviour.IsInAction);
		//Debug.Log("suspect state: " + state);
	}
	
	public void SetNervousState()
	{
		Debug.Log("suspect nervous");
		state = SuspectState.Nervous;
	}
	
	public void SetNeutralState()
	{
		Debug.Log("suspect neutral");
		state = SuspectState.Neutral;
	}
	
	public SuspectState GetSuspectState()
	{
		return state;
	}
}
