using UnityEngine;
using System.Collections;
using iViewX;

public class Suspect : MonoBehaviourWithGazeComponent 
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
		Debug.Log("in action: " + behaviour.IsInAction);
	}
	
	public void SetNervousState()
	{
		state = SuspectState.Nervous;
	}
	
	public void SetNeutralState()
	{
		state = SuspectState.Neutral;
	}
	
	public SuspectState GetSuspectState()
	{
		return state;
	}
	
	void OnMouseEnter()
	{
		behaviour.RandomReaction();
	}
	
	void OnMouseOver()
	{
		behaviour.FixatedReaction();
	}
	
	void OnMouseExit()
	{
		StartCoroutine("SeekAttention");
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
	
	IEnumerator SeekAttention()
	{
		yield return new WaitForSeconds(2f);
		behaviour.NotLookingReaction();
	}
}
