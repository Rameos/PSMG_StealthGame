using UnityEngine;
using System.Collections;

public class BehaviourController : MonoBehaviour 
{
	public delegate void SuspectTalk();
	public delegate void SuspectRespond(int clueID);
	public static event SuspectTalk OnRandomBehaviour;
	public static event SuspectTalk OnFixatedBehaviour;
	public static event SuspectRespond OnFixatedClueBehaviour;
	public static event SuspectRespond OnRandomClueBehaviour;
	
	private VerbalResponse voice;
	private VisualResponse gesture;
	
	private float interval = 10f;
	private float timeOfLastReaction = -10f;
	
	void Awake()
	{
		voice = GetComponent<VerbalResponse>();
		gesture = GetComponent<VisualResponse>();
	}
	
	/// <summary>
	/// Triggers random suspect behaviour when sighted.
	/// </summary>
	public void RandomReaction()
	{
		if(Time.time >= timeOfLastReaction + interval && !GameState.IsInteracting)
		{
			#region subscribe
			OnRandomBehaviour += voice.RandomVO;
			OnRandomBehaviour += gesture.RandomGesture;
			#endregion
			
			RandomBehaviour();
			ClearRandombehaviour();
			SetTimeOfLastReaction();
		}
	}
	
	/// <summary>
	/// Triggers suspect behaviour when being fixated.
	/// </summary>
	public void FixatedReaction()
	{
		if(Time.time >= timeOfLastReaction + interval && GameState.IsInteracting)
		{
			#region subscribe
			OnFixatedBehaviour += voice.FixatedVO;
			OnFixatedBehaviour += gesture.FixatedGesture;
			#endregion
			
			FixatedBehaviour();
			ClearFixatedBehaviour();
			SetTimeOfLastReaction();
		}
	}
	
	/// <summary>
	/// Triggers specific suspect behaviour when clue/item is being fixated.
	/// </summary>
	/// <param name="clueID">Clue ID.</param>
	public void FixatedOnClueReaction(int clueID)
	{
		#region subscribe
		OnFixatedClueBehaviour += voice.FixatedClueVO;
		OnFixatedClueBehaviour += gesture.FixatedClueGesture;
		#endregion
		
		FixatedOnClueBehaviour(clueID);
		SetTimeOfLastReaction();
	}
	
	/// <summary>
	/// Triggers random suspect behaviour when clue/item is sighted.
	/// </summary>
	/// <param name="clueID">Clue ID.</param>
	public void RandomOnClueReaction(int clueID)
	{
		#region subscribe
		OnRandomClueBehaviour += voice.RandomClueVO;
		OnRandomClueBehaviour += gesture.RandomClueGesture;
		#endregion	
		
		RandomOnClueBehaviour(clueID);
		SetTimeOfLastReaction();
	}
	
	void SetTimeOfLastReaction()
	{
		timeOfLastReaction = Time.time;
	}
	
	#region event triggers
	public void RandomBehaviour()
	{
		if(OnRandomBehaviour != null)
			OnRandomBehaviour();
	}
	
	public void FixatedBehaviour()
	{
		if(OnFixatedBehaviour != null)
			OnFixatedBehaviour();
	}
	
	public void RandomOnClueBehaviour(int clueID)
	{
		if(OnRandomClueBehaviour != null)
			OnRandomClueBehaviour(clueID);
	}
	
	public void FixatedOnClueBehaviour(int clueID)
	{
		if(OnFixatedClueBehaviour != null)
			OnFixatedClueBehaviour(clueID);
	}
	#endregion
	
	#region unsubscribers
	public void ClearRandombehaviour()
	{
		OnRandomBehaviour = null;
	}
	
	public void ClearFixatedBehaviour()
	{
		OnFixatedBehaviour = null;
	}
	
	public void ClearRandomOnClueBahviour()
	{
		OnRandomClueBehaviour = null;
	}
	
	public void ClearFixatedOnClueBehaviour()
	{
		OnFixatedClueBehaviour = null;
	}
	#endregion
}
