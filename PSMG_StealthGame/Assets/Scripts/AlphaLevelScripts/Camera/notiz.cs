using UnityEngine;
using System.Collections;

public class notiz : MonoBehaviour {

	
	public Texture2D logo;
	public float sFactor = 6.0f;
	public float xPos = 0f;	
	public float yPos = 0f;
	private bool backwards = true;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {	
		yPos = Screen.height - logo.height/sFactor;
		Rect textureRect = new Rect(xPos,yPos,logo.width/sFactor,logo.height/sFactor);
		GUI.DrawTexture(textureRect, logo, ScaleMode.ScaleToFit, true, 0);
		if(xPos <= Screen.width-logo.width/sFactor && backwards==true){ 
			xPos += Time.deltaTime * 100;
			print("RIGHT");
			
		}
		else {
			xPos -= Time.deltaTime * 100;
			backwards = false;
			print("LEFT");
			
			if(xPos <= 0){ 
				backwards = true;
			} 
		}
		
	}
}
