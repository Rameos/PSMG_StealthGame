using UnityEngine;
using System.Collections;

public class Outro : MonoBehaviour 
{
	private string outroText = "";
	private string outroLine1 = "Durch die grandiose Arbeit des charismatischen Detektivs\nwurde wieder ein schwieriger Fall zu den Akten gelegt.";
	private string outroLine2 = "Wir hoffen euch hat diese kurze Live-Demo gefallen!";
	private string outroLine3 = "Vielen Danke für eure Aufmerksamkeit!";
	
	private int linesDisplayed = 0;
	private int totalLines = 3;
	
	void Start()
	{
		guiText.anchor = TextAnchor.MiddleCenter;
		guiText.alignment = TextAlignment.Center;
		guiText.fontSize = 25;
		
		StartCoroutine("OutroPopUp");
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}
	
	IEnumerator OutroPopUp()
	{
		while(linesDisplayed != totalLines)
		{
			switch(linesDisplayed)
			{
			case 0: outroText = outroLine1; break;
			case 1: outroText = outroLine2; break;
			case 2: outroText = outroLine3; break;
			default:
				break;
			}
			guiText.text = outroText;
			yield return new WaitForSeconds(4f);
			linesDisplayed++;
		}
	}
}
