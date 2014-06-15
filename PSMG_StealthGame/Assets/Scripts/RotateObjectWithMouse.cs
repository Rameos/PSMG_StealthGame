using UnityEngine;
using System.Collections;

public class RotateObjectWithMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 30 * Input.GetAxis("Mouse X"), 0);	
	}
}
