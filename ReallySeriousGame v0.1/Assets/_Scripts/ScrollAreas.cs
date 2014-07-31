using UnityEngine;
using System.Collections;

public class ScrollAreas : MonoBehaviour 
{
	public static Rect top, right, bottom, left;
	
	void Start() 
	{
		top 	= new Rect(0, Screen.height - Screen.height / 6, Screen.width, Screen.height / 6);
		right 	= new Rect(Screen.width - Screen.width / 6, 0, Screen.width / 6, Screen.height);
		bottom 	= new Rect(0, 0, Screen.width, Screen.height / 6);
		left 	= new Rect(0, 0, Screen.width / 6, Screen.height);
	}
}
