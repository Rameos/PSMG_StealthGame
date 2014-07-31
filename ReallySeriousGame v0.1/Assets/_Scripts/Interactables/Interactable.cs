using UnityEngine;
using System.Collections;
using iViewX;

public class Interactable : MonoBehaviourWithGazeComponent 
{

	private Color initialColor;
	private bool isHighlighted;
	
	void OnMouseEnter()
	{
		Highlight();
		Debug.Log ("What're you lookin' at?");
	}
	
	void OnMouseExit()
	{
		UnHighlight();
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
	
	
	void Highlight() 
	{
		initialColor = renderer.material.color;
		renderer.material.color = Color.yellow;
		
		isHighlighted = true;
	}
	
	void UnHighlight()
	{
		renderer.material.color = initialColor;
		isHighlighted = false;
	}
}
