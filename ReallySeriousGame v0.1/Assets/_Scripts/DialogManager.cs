using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour 
{
	public static DialogManager instance;
	
	public delegate void StartAccusationOn(GameObject accused);
	public static event StartAccusationOn OnAccusation;
	
	private List<string> listOfAccusations = new List<string>();
	public bool[] correctOrderOfAccusations = new bool[6];
	private int nextInOrder = 0;
	
	void Awake()
	{
		#region singleton
		if(instance == null) 
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		} 
		else if(instance != this) 
		{
			Destroy(gameObject);
		}
		#endregion
	}
	
	public void AccusationOn(GameObject accused)
	{
		Debug.Log("accusation on: " + accused.name);
		if(OnAccusation != null)
		{
			OnAccusation(accused);
		}
	}
	
	public void ClearOnAccusation()
	{
		OnAccusation = null;
	}
	
	public void AddToListOfAccusations(string newAccusation)
	{
		if(!listOfAccusations.Contains(newAccusation))
		{
			listOfAccusations.Add(newAccusation);
		}
	}
	
	public List<string> GetListOfAccusations()
	{
		return listOfAccusations;
	}
	
	public int GetCorrectAccusationsInOrder()
	{
		return nextInOrder;
	}
	
	public bool IsCorrectOrderOfAccusations(string accusation)
	{
		Debug.Log("check order: " + accusation);
		Debug.Log("next in order: " + nextInOrder);
		switch(nextInOrder)
		{
			case 0: 
				if(accusation == "EyeContact") 
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			case 1: 
				if(accusation == "Mustache")
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			case 2: 
				if(accusation == "T-Virus" || accusation == "Umbrella")
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			case 3:
				if(accusation == "Stain" || accusation == "Bandage")
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			case 4:
				if(accusation == "Crayons" || accusation == "Certificate")
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			case 5:
				if(accusation == "Hadouken")
				{
					correctOrderOfAccusations[nextInOrder] = true; 
					nextInOrder++;
					return true;
				}
				else
				{
					correctOrderOfAccusations[nextInOrder] = false;
					return false;
				}
			default: return false;
		}
	}
}
