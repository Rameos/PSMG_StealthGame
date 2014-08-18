using UnityEngine;

public class ScrollAreas
{
	public static Rect top 		= new Rect(0, Screen.height - Screen.height / 6, Screen.width, Screen.height / 6);
	public static Rect right 	= new Rect(Screen.width - Screen.width / 6, 0, Screen.width / 6, Screen.height);
	public static Rect bottom 	= new Rect(0, 0, Screen.width, Screen.height / 6);
	public static Rect left 	= new Rect(0, 0, Screen.width / 6, Screen.height);
}
