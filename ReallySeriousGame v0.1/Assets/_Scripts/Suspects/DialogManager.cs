using UnityEngine;
using System;

public class DialogManager : MonoBehaviour {

    public delegate void DialogEvent(object sender, string data, int index);
    public static event DialogEvent PlayVoice;

    //private bool active = true;
    private Suspect suspect;

	// Use this for initialization
	void Awake () {
        suspect = gameObject.GetComponent<Suspect>();
        Debug.Log("Number of Conversations with " + suspect.currentSuspect +": " + suspect.numberOfConversations);
        //if (PlayVoice != null)
        //{

        //    PlayVoice(this, Constants.EventBarkeeperFleck, -1);
        //}
	}
	
	// Update is called once per frame
	void Update () {
        //if (PlayRecord != null)
        //{
        //    suspect.numberOfConversations++;
        //}

	}
}
