using UnityEngine;
using System.Collections;
using iViewX;

public class CameraController : MonoBehaviourWithGazeComponent{
    public Transform target;

    Rect leftArea, rightArea;
    Vector3 screenPos;

	// Use this for initialization
	void Start () {
        leftArea = new Rect(0, 0, Screen.width / 5, Screen.height);
        rightArea = new Rect(Screen.width - Screen.width / 5, 0, Screen.width / 5, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
        MoveCameraWithMouse();
        
        MoveCameraWithEyes();

        screenPos = camera.WorldToScreenPoint(target.position);
        
	}

    private void MoveCameraWithMouse()
    {
        if (leftArea.Contains(Input.mousePosition))
            moveCameraToLeft();
        if (rightArea.Contains(Input.mousePosition))
            moveCameraToRight();
    }


    private void MoveCameraWithEyes()
    {
        if (gazeModel.isEyeTrackerRunning) 
        {
            if (leftArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                moveCameraToLeft();
            if (rightArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                moveCameraToRight();
        }
    }

    private void moveCameraToLeft()
    {
        if (screenPos.x < 2130)
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
    }

    private void moveCameraToRight()
    {
        if (screenPos.x > 1080)
        {
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
