using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 200, 90), "Klick Button to open Box");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 100, 20), "Examine Box"))
        {
            animation.Play();
        }
    }


}
