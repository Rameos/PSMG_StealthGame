using UnityEngine;
using System.Collections;

// DS4 Layout
// Facebuttons: 0 = Square, 1 = Cross, 2 = Circle, 3 = Triangle
// 4 = Left Shoulder, 5 = Right Shoulder, 6 = Left Trigger, 7 = Right Trigger
// 8 = Share, 9 = Options, 13 = Touchpad Click
// 10 = Left Stick Click, 11 = Right Stick Click, 12 = PS Home

public class GamepadInput : MonoBehaviour 
{
	/*
	public bool inputLeft()
	{
		if(Input.GetAxis("4th axis") < 0)
			return true;
		return false;
	}
	
	public bool inputRight()
	{
		if(Input.GetAxis("4th axis") > 0)
			return true;
		return false;
	}
	*/
	
	/// <summary>
	/// Reads input for action: 'interact'
	/// </summary>
	/// <returns><c>true</c>, if button for 'interact' was pressed, <c>false</c> otherwise.</returns>
	
	public bool inputInteract()
	{
		if(Input.GetKeyDown(KeyCode.Joystick1Button1))
			return true;
		return false;
	}
	
	public bool inputLeftTrigger()
	{
		if(Input.GetKeyDown(KeyCode.Joystick1Button6))
			return true;
		return false;
	}
	
	public bool inputRightTrigger()
	{
		if(Input.GetKeyDown(KeyCode.Joystick1Button7))
			return true;
		return false;
	}
}
