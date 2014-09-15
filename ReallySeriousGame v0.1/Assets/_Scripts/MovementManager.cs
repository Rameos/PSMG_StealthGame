using UnityEngine;
using System.Collections;

public class MovementManager : MonoBehaviour 
{	
	#region speed modifiers
	public float moveSpeed = 5f;
	public float turnSpeed = 40f;
	#endregion

	#region movement
	//Translate
	public void move(float x, float z)
	{
		x = x * moveSpeed * Time.deltaTime;
		z = z * moveSpeed * Time.deltaTime;
		transform.Translate		(x, 0, z, Space.World);
	}
	
	public void moveForward() 
	{
		transform.Translate		(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
	}

	public void moveBackward() 
	{
		transform.Translate		(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
	}

	public void strafeRight() 
	{
		transform.Translate		(Vector3.right * moveSpeed * Time.deltaTime);
	}

	public void strafeLeft() 
	{
		transform.Translate		(Vector3.left * moveSpeed * Time.deltaTime);
	}

	public void moveUp() 
	{
		transform.Translate		(Vector3.up * moveSpeed * Time.deltaTime);
	}

	public void moveDown() 
	{
		transform.Translate		(Vector3.down * moveSpeed * Time.deltaTime);
	}
	
	//Rotate
	public void turnLeft() 
	{
		transform.Rotate		(Vector3.down * turnSpeed * Time.deltaTime, Space.World);
	}
	
	public void turnRight() 
	{
		transform.Rotate		(Vector3.up * turnSpeed * Time.deltaTime, Space.World);
	}
	
	public void turnUp()
	{
		transform.Rotate		(Vector3.left * turnSpeed * Time.deltaTime);
	}
	
	public void turnDown()
	{
		transform.Rotate		(Vector3.right * turnSpeed * Time.deltaTime);
	}
	#endregion

}
