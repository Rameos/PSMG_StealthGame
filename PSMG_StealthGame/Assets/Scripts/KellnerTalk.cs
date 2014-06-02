using UnityEngine;
using System.Collections;

public class KellnerTalk : MonoBehaviour {
    public GUIText kellnerText;
	// Use this for initialization
	void Start () {
        setText("ulumulu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setText(string bla)
    {

        kellnerText.text = bla;
    }
}
