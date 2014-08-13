using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour 
{	
	#region movement
	public bool inputForward() 
	{
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
			return true;   
		return false;
	}

	public bool inputBackward() 
	{
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
			return true;
		return false;
	}

	public bool inputRight() 
	{
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
			return true; 
		return false;
	}

	public bool inputLeft() 
	{
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
			return true; 
		return false;
	}
	#endregion
	
	
	#region interaction
	/// <summary>
	/// Reads input for action: 'interact'
	/// </summary>
	/// <returns><c>true</c>, if SPACE was pressed, <c>false</c> otherwise.</returns>
	
	public bool inputInteract() 
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
			return true;
		return false;
	}
	
	/// <summary>
	/// Reads input for action: 'return'
	/// </summary>
	/// <returns><c>true</c>, if RETURN was pressed, <c>false</c> otherwise.</returns>
	
	public bool inputReturn()
	{
		if(Input.GetKeyDown(KeyCode.Return))
			return true;
		return false;
	}
	
	public bool inputToggleNotebook()
	{
		if(Input.GetKeyDown(KeyCode.N))
			return true;
		return false;
	}
	#endregion
	
	#region ui
	/// <summary>
	/// Reads input for action: 'pause'
	/// </summary>
	/// <returns><c>true</c>, if ESC was pressed, <c>false</c> otherwise.</returns>
	
	public bool inputPause()
	{
		if(Input.GetKey(KeyCode.Escape))
			return true;
		return false;
	}
	#endregion
}