using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour 
{	
	Ray ray;
	RaycastHit hit;
	Vector3 mousePos;
	
	#region mouse clicks
	public bool leftClicked()
	{
		return Input.GetKeyDown(KeyCode.Mouse0) ? true : false;
	}
	
	public bool rightClicked()
	{
		return Input.GetKeyDown(KeyCode.Mouse1) ? true : false;
	}
	#endregion
	/// <summary>
	/// Returns Vector3 position.
	/// </summary>
	public Vector3 Position()
	{
		return mousePos = Input.mousePosition;
	}
	
	public RaycastHit rayTarget()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, out hit);
		return hit;
	}
}
