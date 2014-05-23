using UnityEngine;
using System.Collections;

public class KellnerTalk : MonoBehaviour {
    private GUIText KellnerSagt;
	// Use this for initialization
	void Start () {
        Debug.Log("war hier!");
        KellnerSagt = GUIElement.FindObjectOfType<GUIText>();
        KellnerSagt.GetComponent<aussageBehaviour>().setText("aussageBehaviouraussageBehaviouraussageBehaviouraussageBehaviouraussageBehaviouraussageBehaviour");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
