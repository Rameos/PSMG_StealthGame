using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour 
{
	private string introText = "";
	private string introLine1 = "Danke dass ihr so zahlreich zu unserer Präsentation erschienen seid!";
	private string introLine2 = "\nAber wo ist denn der Präsentator?";
	private string introLine3 = "\nAnscheinend alkoholisiert und ist jetzt außer Gefecht gesetzt.";
	private string introLine4 = "\nWie uncharakteristische denn er trinkt doch gar kein Alkohol!";
	private string introLine5 = "\nWer war der Übeltäter der ihm was verabreicht hat?!";
	private string introLine6 = "\nKann nur der tollpatschiger Barmann gewesen sein!";
	private string introLine7 = "\nDas muss jetzt nur noch bewiesen werden.";
	private string introLine8 = "\nGanz klar ein Fall für unseren Super Detektiv!";
	
	private int linesDisplayed = 0;
	private int totalLines = 8;

	void Start()
	{	
		guiText.anchor = TextAnchor.MiddleCenter;
		guiText.alignment = TextAlignment.Center;
		guiText.fontSize = 25;
		
		StartCoroutine("IntroPopUp");
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("BarScene");
		}
	}
	
	IEnumerator IntroPopUp()
	{
		while(linesDisplayed != totalLines)
		{
			switch(linesDisplayed)
			{
				case 0: introText = introLine1; break;
				case 1: introText = introLine2; break;
				case 2: introText = introLine3; break;
				case 3: introText = introLine4; break;
				case 4: introText = introLine5; break;
				case 5: introText = introLine6; break;
				case 6: introText = introLine7; break;
				case 7: introText = introLine8; break;
				default:
					break;
			}
			guiText.text = introText;
			yield return new WaitForSeconds(4f);
			linesDisplayed++;
		}
		Application.LoadLevel("BarScene");
	}
}
