using UnityEngine;
using System.Collections;

public class KellnerTalk : MonoBehaviour {
    public GUIText kellnerText;
	// Use this for initialization
	void Start () {
        setText("Kellner Blabla");
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

    public void dealWithMessage(string message)
    {

        switch (message)
        {
            case "Eye":
                setText("Was ist los?");
                break;
            case "EyeLong":
                setText("Oida! WAS KUGGST DU SO DUMM??");
                break;
            case "Tablet":
                setText("Verpiss dich, kriegst nix");
                break;
            case "Handtuch":
                setText("Ja das ist ein Handtuch. Na UND?!");
                break;
            case "Schachtel":
                setText("Kriegst keine Zigarette, sind alle.");
                break;
            case "Stift":
                setText("Brauchste was zum schreiben? Nö."); 
                break;
            case "Schritt":
                setText("Kuggst du gerade meinen Schritt an??");
                break;
            case "SchrittLong":
                setText("Biste SCHWUL oder was?!");
                break; 
            default:
                //default stuff
                break;
        }
    }

    private void setText(string bla)
    {

        kellnerText.text = bla;
    }
}
