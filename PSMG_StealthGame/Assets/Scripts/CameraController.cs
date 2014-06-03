using UnityEngine;
using System.Collections;
using iViewX;

public class CameraController : MonoBehaviourWithGazeComponent{

    Rect leftArea, rightArea;

	// Use this for initialization
	void Start () {
        leftArea = new Rect(0, 0, Screen.width / 5, Screen.height);
        rightArea = new Rect(Screen.width - Screen.width / 5, 0, Screen.width / 5, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
        MoveCameraWithMouse();
        
        MoveCameraWithEyes();
        
	}

    private void MoveCameraWithMouse()
    {
        if (leftArea.Contains(Input.mousePosition))
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
        if (rightArea.Contains(Input.mousePosition))
            transform.Translate(-Vector3.left * 5 * Time.deltaTime);
    }

    private void MoveCameraWithEyes()
    {
        if (gazeModel.isEyeTrackerRunning) 
        {
            if (leftArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
            if (rightArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                transform.Translate(-Vector3.left * 5 * Time.deltaTime);
        }
        
    }

    void OnGUI()
    {

    }

    public override void OnGazeEnter(RaycastHit hit)
    {

    }

    public override void OnGazeExit()
    {

    }


    public override void OnGazeStay(RaycastHit hit)
    {

    }
}
