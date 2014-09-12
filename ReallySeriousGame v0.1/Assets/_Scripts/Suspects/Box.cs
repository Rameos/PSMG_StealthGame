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
		transform.FindChild("Exclamation").gameObject.SetActive(true);
		audio.Play();
		yield return new WaitForSeconds(2f);
		transform.FindChild("Exclamation").gameObject.SetActive(false);
	}
}
