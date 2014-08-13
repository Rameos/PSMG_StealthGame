using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour {

    public delegate void DialogEvent(string Data);
    public static event DialogEvent OnTalking;
    public static event DialogEvent OnLeaving;
    private bool active = true;
    private Suspect suspect;

	// Use this for initialization
	void Awake () {
        suspect = GameObject.FindGameObjectWithTag("Suspect").GetComponent<Suspect>();
        Debug.Log("Number of Conversations: " + suspect.numberOfConversations);
        if (OnTalking != null && active == true)
        {
            OnTalking("Gruener Fleck");
            active = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (OnLeaving != null && active == false)
        {
            suspect.numberOfConversations++;
            OnLeaving("Bye");
        }

	}
}
