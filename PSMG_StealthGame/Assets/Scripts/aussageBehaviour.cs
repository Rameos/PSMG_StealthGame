using UnityEngine;
using System.Collections;

public class aussageBehaviour : MonoBehaviour {

    public GameObject GUItext;

	// Use this for initialization
	void Start () {
        GUItext = GameObject.FindGameObjectWithTag("KellnerSagt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setText(string bla)
    {

    //    GUItext.text = bla;
    }
}
