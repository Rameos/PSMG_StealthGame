using UnityEngine;

public class Keyboard
{	
	#region movement
	public static bool inputForward() 
	{
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
			return true;   
		return false;
	}

	public static bool inputBackward() 
	{
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
			return true;
		return false;
	}

	public static bool inputRight() 
	{
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
			return true; 
		return false;
	}

	public static bool inputLeft() 
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
	
	public static bool inputInteract() 
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
			return true;
		return false;
	}
	
	public static bool inputAccuse()
	{
		if(Input.GetKeyDown(KeyCode.B))
			return true;
		return false;
	}
	
	/// <summary>
	/// Reads input for action: 'return'
	/// </summary>
	/// <returns><c>true</c>, if RETURN was pressed, <c>false</c> otherwise.</returns>
	
	public static bool inputReturn()
	{
		if(Input.GetKeyDown(KeyCode.Return))
			return true;
		return false;
	}
	
	public static bool inputToggleNotebook()
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
	
	public static bool inputPause()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			return true;
		return false;
	}
	#endregion
}