using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour 
{
	public delegate void StartAccusationOn(GameObject accused);
	public static event StartAccusationOn OnAccusation;
	
	public void AccusationOn(GameObject accused)
	{
		if(OnAccusation != null)
			OnAccusation(accused);
	}
	
	public void ClearOnAccusation()
	{
		OnAccusation = null;
	}
}
