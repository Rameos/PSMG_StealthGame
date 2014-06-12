using UnityEngine;
using System.Collections;
using iViewX;

public class ZoomedCameraController : MonoBehaviourWithGazeComponent
{
    public Transform target;

    Rect upperArea, lowerArea;
    Vector3 screenPos;

    // Use this for initialization
    void Start()
    {
        upperArea = new Rect(0, 0, Screen.width, Screen.height/6);
        lowerArea = new Rect(0, Screen.height - Screen.height / 6, Screen.width, Screen.height / 6);
    }

    // Update is called once per frame
    void Update()
    {
        screenPos = camera.WorldToScreenPoint(target.position);
        print("target is " + screenPos.y + " pixels from the left");

        MoveCameraWithMouse();

        MoveCameraWithEyes();

    }

    private void MoveCameraWithMouse()
    {
        if (upperArea.Contains(Input.mousePosition))
            moveCameraDown();
        if (lowerArea.Contains(Input.mousePosition))
            moveCameraUp();
    }


    private void MoveCameraWithEyes()
    {
        if (gazeModel.isEyeTrackerRunning)
        {
            if (upperArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                moveCameraDown();
            if (lowerArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                moveCameraUp();
        }
    }


    private void moveCameraUp()
    {
        if (screenPos.y > 260)
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }
    }

    private void moveCameraDown()
    {
        if (screenPos.y < 685)
        {
            transform.Translate(Vector3.down * 3 * Time.deltaTime);
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
