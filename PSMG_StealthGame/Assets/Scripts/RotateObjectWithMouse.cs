using UnityEngine;
using System.Collections;

public class RotateObjectWithMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse X") > 0)
        {
            Debug.Log("Right");
            transform.Rotate(0, 3, 0, Space.World);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            Debug.Log("Left");
            transform.Rotate(0, -3, 0, Space.World);
        }
        else if (Input.GetAxis("Mouse Y") > 0)
        {
            Debug.Log("Up");
            transform.Rotate(3, 0, 0, Space.World);
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            Debug.Log("Down");
            transform.Rotate(-3, 0, 0, Space.World);
        }
	}
}
