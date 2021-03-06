﻿using UnityEngine;
using System.Collections;

public class BehaviourController : MonoBehaviour 
{
	public delegate void SuspectTalk();
	public delegate void SuspectRespond(string clueID);
	public static event SuspectTalk OnNotLookingBehaviour;
	public static event SuspectTalk OnRandomBehaviour;
	public static event SuspectTalk OnFixatedBehaviour;
	public static event SuspectRespond OnFixatedClueBehaviour;
	public static event SuspectRespond OnRandomClueBehaviour;
	public static event SuspectRespond OnInteractableBehaviour;
	public static event SuspectRespond OnAccusationBehaviour;
	
	private VerbalResponse voice;
	private VisualResponse gesture;
	
	private float interval = 6f;
	private float timeOfLastReaction = -6f;
	private bool inAction = false;
	
	private Suspect.SuspectState currentState;
	
	void Awake()
	{
		voice = GetComponent<VerbalResponse>();
		gesture = GetComponent<VisualResponse>();
		currentState = Suspect.state;
	}
	
	void Update()
	{
		SetCurrentState();
		SetClueVisibility();
	}
	
	public bool IsInAction
	{
		get
		{
			inAction = (voice.IsSpeaking || gesture.IsInGesture);
			return inAction;
		}
	}
	
	void SetClueVisibility()
	{
		if(GameController.instance.GetCurrentSuspect() != null)
		{
			if(IsInAction)
			{
				foreach(Transform clue in gameObject.transform)
				{
					clue.gameObject.SetActive(false);
				}
			}
			else
			{	
				foreach(Transform clue in gameObject.transform)
				{
					if(clue.name == "Bandage")
					{
						if(currentState == Suspect.SuspectState.Nervous)
						{
							clue.gameObject.SetActive(false);
						}
						else
						{
							clue.gameObject.SetActive(true);
						}
					}
					else
					{
						clue.gameObject.SetActive(true);
					}
				}
			}
		}
	}
	
	void SetCurrentState()
	{
		if(currentState != Suspect.state)
		{
			currentState = Suspect.state;
			gesture.SetDefaultSprite();
		}
	}
	
	/*IEnumerator SeekAttention()
	{
		yield return new WaitForSeconds(2f);
	}*/
	
	/// <summary>
	/// Triggers suspect behaviour when not being focused by the player during interaction.
	/// </summary>
	public void NotLookingReaction()
	{
		if(!IsInAction)
		{
			if(Time.time >= timeOfLastReaction + interval && !GameState.IsInteracting)
			{
				#region subscribe
				OnNotLookingBehaviour += voice.NotLookingVO;
				OnNotLookingBehaviour += gesture.NotLookingGesture;
				#endregion
				
				NotLookingBehaviour();
				ClearNotLookingBehaviour();
				SetTimeOfLastReaction();
			}
		}
	}
	
	//INTERACTION WITH SUSPECT SELF
	
	/// <summary>
	/// Triggers random suspect behaviour when sighted.
	/// </summary>
	public void RandomReaction()
	{
		if(!IsInAction)
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
	}
	
	/// <summary>
	/// Triggers suspect behaviour when being fixated.
	/// </summary>
	public void FixatedReaction()
	{
		if(!IsInAction)
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
	}
	
	//INTERACTION WITH CLUES
	
	/// <summary>
	/// Triggers specific suspect behaviour when clue/item is being fixated.
	/// </summary>
	/// <param name="clueID">Clue ID.</param>
	public void FixatedOnClueReaction(string clueID)
	{
		if(!IsInAction)
		{
			if(Time.time >= timeOfLastReaction + interval && GameState.IsInteracting)
			{
				#region subscribe
				OnFixatedClueBehaviour += voice.FixatedOnClueVO;
				OnFixatedClueBehaviour += gesture.FixatedOnClueGesture;
				#endregion
			
				FixatedOnClueBehaviour(clueID);
				ClearFixatedOnClueBehaviour();
				SetTimeOfLastReaction();
			}
		}
	}
	
	/// <summary>
	/// Triggers random suspect behaviour when clue/item is sighted.
	/// </summary>
	/// <param name="clueID">Clue ID.</param>
	public void RandomOnClueReaction(string clueID)
	{
		/*if(!IsInAction)
		{*/
			#region subscribe
			OnRandomClueBehaviour += voice.RandomOnClueVO;
			OnRandomClueBehaviour += gesture.RandomOnClueGesture;
			#endregion	
				
			RandomOnClueBehaviour(clueID);
			ClearRandomOnClueBahviour();
			SetTimeOfLastReaction();
		/*}*/
	}
	//INTERACTION WITH INTERACTABLES
	
	/// <summary>
	/// Triggers suspect behaviour on interaction with clue.
	/// </summary>
	/// <param name="clueID">Clue ID.</param>
	public void ReactionOnInteractable(string interactableName)
	{
		/*if(!IsInAction)
		{*/
			#region subscribe
			OnInteractableBehaviour += voice.VoiceOverForInteractable;
			OnInteractableBehaviour += gesture.GestureForInteractable;
			#endregion
			
			BehaviourOnInteractable(interactableName);
			ClearOnInteractableBehaviour();
			SetTimeOfLastReaction();
		/*}*/
	}
	
	public void SetTimeOfLastReaction()
	{
		StartCoroutine("SetTimerForReaction");
	}
	
	IEnumerator SetTimerForReaction()
	{
		if(voice.audio.clip != null)
		{
			yield return new WaitForSeconds(voice.audio.clip.length);
			timeOfLastReaction = Time.time;
		}
	}
	
	#region event triggers
	public void AccusationBehaviour(string subject)
	{
		if(OnAccusationBehaviour != null)
			OnAccusationBehaviour(subject);
	}
	
	public void NotLookingBehaviour()
	{
		if(OnNotLookingBehaviour != null)
			OnNotLookingBehaviour();
	}
	
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
	
	public void RandomOnClueBehaviour(string clueID)
	{
		if(OnRandomClueBehaviour != null)
			OnRandomClueBehaviour(clueID);
	}
	
	public void FixatedOnClueBehaviour(string clueID)
	{
		if(OnFixatedClueBehaviour != null)
			OnFixatedClueBehaviour(clueID);
	}
	
	public void BehaviourOnInteractable(string interactableName)
	{
		if(OnInteractableBehaviour != null)
			OnInteractableBehaviour(interactableName);
	}
	#endregion
	
	#region unsubscribers
	public void ClearAccusationBehaviour()
	{
		OnAccusationBehaviour = null;
	}
	
	public void ClearNotLookingBehaviour()
	{
		OnNotLookingBehaviour = null;
	}
	
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
	
	public void ClearOnInteractableBehaviour()
	{
		OnInteractableBehaviour = null;
	}
	#endregion
}
