using UnityEngine;
using System.Collections;
using iViewX;

public class InteractionManager : MonoBehaviour 
{
	public float turnSpeed = 66f;
	private bool isInteracting = false;

	Vector3 itemOriginalPos;
    Quaternion itemOriginalRot;
	public float itemDistanceFromCamera = 2f;
    public float smoothing = 10f;
	GameObject currentItem;
	
	Vector3 playerOriginalPos;
	public float suspectDistanceFromPlayer = 0.5f;
	GameObject currentSuspect;
	
    private bool inspecting = false;
    private bool interrogating = false;
    
    //mock
    public bool hasClues = false;
    public int accusations = 0;
    
	
	public void StartAccusationOn(GameObject selection)
	{
		if(GameState.IsInteracting && selection != null)
		{
			#region trigger dialog
			DialogManager.OnAccusation += SoundManager.instance.PlayAccusation;
			
			if(GameState.IsState(GameState.States.Interrogating))
			{
				if(selection.tag != "Box")
				{
					DialogManager.OnAccusation += GameController.instance.GetCurrentSuspect().GetComponent<VerbalResponse>().VoiceOverOnBeingAccused;
				}
			}
			gameObject.SendMessage("AccusationOn", selection);
			#endregion
			
			if(selection.tag == "Clue")
			{
				selection.transform.parent.GetComponent<Interactable>().SetAccused();
			}
			else if(selection.GetComponent<Interactable>() as Interactable != null)
			{
				selection.GetComponent<Interactable>().SetAccused();
				if(selection.tag == "Box")
				{
					selection.GetComponent<Box>().SetAlert();
				}
			}
		}
		gameObject.SendMessage("ClearOnAccusation");
	}
	
	/// <summary>
	/// Starts interaction with selected object.
	/// </summary>
	public void StartInteraction(GameObject selection)
	{
		if(selection.tag != "Clue")
		{
			ClueManager.instance.ActivateCluesOn(selection);
		}
		else
		{
			ClueManager.instance.FoundClue(selection);
		}
		
		if(!isInteracting)
		{
			switch(selection.tag)
			{
			case "Interactable": 
				Inspect(selection);
				break;
				
			case "Suspect":
				Interrogate(selection);
				break;
			
			case "Box":
				Interrogate(selection);
				break;
				
			case "Door":
				EnterDoor(); 
				break;
                
            case "MenuItem":
                SelectMenuItem(selection);
                break;
				
			default: break;
			}
			isInteracting = true;
		}
		else
		{
			return;
		}
	}

    private void SelectMenuItem(GameObject selection)
    {
        switch (selection.name)
        {
            case "StartGame":
                Application.LoadLevel("BarScene");
                break;

            case "LoadSave":
                Debug.Log("LoadSave");
                break;

            case "SetControls":
                Debug.Log("SetControls");
                break;

            case "StartCalibration":
                Debug.Log("StartCalibration");
                GazeControlComponent.Instance.StartCalibration();
                break;

            case "QuitGame":
                Debug.Log("QuitGame");
                Application.Quit();
                break;

            default:
                break;
        }
    }
	
	/// <summary>
	/// Stops interaction with selected object.
	/// </summary>
	public void StopInteraction()
	{
		if(GameState.IsInteracting)
		{
			if(GameController.instance.GetSelectedObject().tag == "Clue")
			{
				ClueManager.instance.DeactivateCluesOn(GameController.instance.GetSelectedObject().transform.parent.gameObject);
			}
			else
			{
				ClueManager.instance.DeactivateCluesOn(GameController.instance.GetSelectedObject());
			}
			
			switch(GameState.gameState)
			{
			case GameState.States.Inspecting:
				StopInspection();
				break;
				
			case GameState.States.Interrogating:
				StopInterrogation();
				break;
				
			default: break;
			}
			isInteracting = false;
		}
		else
		{
			return;
		}
	}
	
	/// <summary>
	/// Pull object into camera center.
	/// </summary>
	public void Inspect(GameObject item)
	{
        inspecting = true;
		currentItem = item;
		#region position item
		itemOriginalPos = currentItem.transform.position;
        itemOriginalRot = currentItem.transform.rotation;
		//transform.LookAt(currentItem.transform);
        StartCoroutine(MoveToObject(item));
		#endregion
	}

    IEnumerator MoveToObject(GameObject item) {
        Vector3 origin = item.transform.position;
        Quaternion rotation = item.transform.rotation;
        Vector3 target = Camera.main.transform.position + Camera.main.transform.forward * itemDistanceFromCamera;
        while (Vector3.Distance(origin, Camera.main.transform.position) > itemDistanceFromCamera)
        {
            if (!inspecting)
            {
                //Debug.Log("Not inspecting");
                yield break;
            }
            //Debug.Log("Vector3.ToDistance(origin, target)= " + Vector3.Distance(origin, Camera.main.transform.position));
            Vector3 vector = Vector3.Lerp(origin, target, smoothing * Time.deltaTime);
            item.transform.position = vector;
            origin = vector;
            yield return null;            
        }
        yield break;
    }

    IEnumerator MoveFromObject(GameObject item)
    {
        Vector3 originPos = item.transform.position;
        Vector3 targetPos = itemOriginalPos;
        Quaternion originRot = item.transform.rotation;
        Quaternion targetRot = itemOriginalRot;
        //Debug.Log("origin= " + origin + "target= " + target);
        while (Vector3.Distance(originPos, Camera.main.transform.position) >= 0)
        {
            if (inspecting)
            {
                //Debug.Log("Is inspecting");
                item.transform.position = targetPos;
                item.transform.rotation = targetRot;
                yield break;
            }
            //Debug.Log("Vector3.FromDistance(origin, target)= " + Vector3.Distance(origin, Camera.main.transform.position));
            Vector3 vector = Vector3.Lerp(originPos, targetPos, smoothing * Time.deltaTime);
            item.transform.position = vector;
            originPos = vector;

            Quaternion rotation = Quaternion.Lerp(originRot, targetRot, smoothing * Time.deltaTime);
            item.transform.rotation = rotation;
            originRot = rotation;

            yield return null;
        }
    }
	
	/// <summary>
	/// Quit Inspection and return item to its original position
	/// </summary>
	public void StopInspection()
	{
        inspecting = false;
        StartCoroutine(MoveFromObject(currentItem));
	}
	
	/// <summary>
	/// Move Player towards suspect.
	/// </summary>
	public void Interrogate(GameObject suspect)
	{
        interrogating = true;
		currentSuspect = suspect;
		#region position player
		playerOriginalPos = transform.position;
		//transform.LookAt(currentSuspect.transform.position);
        StartCoroutine(MoveToSuspect(suspect));
		//transform.position = Vector3.Lerp(transform.position, currentSuspect.transform.position, suspectDistanceFromPlayer);
		#endregion
	}

    IEnumerator MoveToSuspect(GameObject item)
    {
        Vector3 target = item.transform.position;
        Vector3 origin = transform.position;
        while (Vector3.Distance(origin, target) > suspectDistanceFromPlayer)
        {
            if (!interrogating)
            {
                yield break;
            }
            //Debug.Log("Vector3.ToDistance(origin, target)= " + Vector3.Distance(origin, target));
            Vector3 vector = Vector3.Lerp(origin, target, 0.5f * smoothing * Time.deltaTime);
            transform.position = vector;
            origin = vector;
            yield return null;
        }
        yield break;
    }
	
	/// <summary>
	/// Quit Interrogation and return player to his original location
	/// </summary>
	public void StopInterrogation()
	{
        interrogating = false;
        StartCoroutine(MoveFromSuspect(currentSuspect));
	}

    IEnumerator MoveFromSuspect(GameObject item)
    {
        Vector3 target = playerOriginalPos;
        Vector3 origin = transform.position;
        while (Vector3.Distance(origin, target) >= 0)
        {
            if (interrogating)
            {
                transform.position = target;
                yield break;
            }
            //Debug.Log("Vector3.ToDistance(origin, target)= " + Vector3.Distance(origin, target));
            Vector3 vector = Vector3.Lerp(origin, target, 0.5f * smoothing * Time.deltaTime);
            transform.position = vector;
            origin = vector;
            yield return null;
        }
        yield break;
    }

	
	/// <summary>
	/// Transition to next level
	/// </summary>
	public void EnterDoor()
	{
		Application.LoadLevel("Scene_2");
	}
	
	public void RotateItemLeft(GameObject interactable)
	{	
		if(GameState.IsState(GameState.States.Inspecting))
			interactable.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime,Space.World);
	}
	
	public void RotateItemRight(GameObject interactable)
	{
		if(GameState.IsState(GameState.States.Inspecting))
			interactable.transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime,Space.World);
	}
}
