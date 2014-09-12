using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour 
{
	public void SetAlert()
	{
		StartCoroutine("Alert");
	}
	
	IEnumerator Alert()
	{
		Debug.Log("Alert");
		yield return new WaitForSeconds(3f);
		Debug.Log("Finish");
	}
}
