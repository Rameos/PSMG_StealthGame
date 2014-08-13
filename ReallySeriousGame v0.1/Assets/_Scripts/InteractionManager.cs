using UnityEngine;
using System.Collections;

public class InteractionManager : MonoBehaviour 
{
	Vector3 itemOriginalPos;
	public float itemDistanceFromCamera = 2f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	public float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;

    public delegate void DialogEvent(string Data);
    public static event DialogEvent OnTalking;
    public static event DialogEvent OnLeaving;
	
	/// <summary>
	/// Pull object into camera center.
	/// </summary>
	
	public void Inspect(GameObject item)
	{
		currentItem = item;
		itemOriginalPos = currentItem.transform.position;
		transform.LookAt(currentItem.transform);
		currentItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * itemDistanceFromCamera;
	}
	
	/// <summary>
	/// Quit Inspection and return item to its original position
	/// </summary>
	
	public void StopInspection()
	{
		currentItem.transform.position = itemOriginalPos;
	}
	
	/// <summary>
	/// Move Player towards suspect.
	/// </summary>
	
	public void Interrogate(GameObject suspect)
	{
		currentSuspect = suspect;
		playerOriginalPos = transform.position;
		Vector3 suspectPos = new Vector3(currentSuspect.transform.position.x, transform.position.y, currentSuspect.transform.position.z); //Lock Y-Axis
		transform.LookAt(suspectPos);
		transform.position = Vector3.Lerp(transform.position, currentSuspect.transform.position, suspectDistanceFromPlayer);
        //if (OnTalking != null)
        //{
            Debug.Log("Test Event");
            OnTalking("Hi");
        //}
	}
	
	/// <summary>
	/// Quit Interrogation and return player to his original location
	/// </summary>
	
	public void StopInterrogation()
	{
		transform.position = playerOriginalPos;
	}
	
	/// <summary>
	/// Transition to next level
	/// </summary>
	
	public void EnterDoor()
	{
		Application.LoadLevel("Scene_2");
		Debug.Log ("Entered door");

	}
	
	public void RotateItemLeft(GameObject interactable)
	{
		interactable.transform.Rotate(Vector3.up * 50 * Time.deltaTime,Space.World);
	}
	
	public void RotateItemRight(GameObject interactable)
	{
		interactable.transform.Rotate(Vector3.down * 50 * Time.deltaTime,Space.World);
	}
}
