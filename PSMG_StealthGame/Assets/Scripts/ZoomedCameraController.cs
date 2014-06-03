using UnityEngine;
using System.Collections;
using iViewX;

public class ZoomedCameraController : MonoBehaviourWithGazeComponent
{

    Rect upperArea, lowerArea;

    // Use this for initialization
    void Start()
    {
        upperArea = new Rect(0, 0, Screen.width, Screen.height/6);
        lowerArea = new Rect(0, Screen.height - Screen.height / 6, Screen.width, Screen.height / 6);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraWithMouse();
        Debug.Log("Cameraposition in space");
        MoveCameraWithEyes();

    }

    private void MoveCameraWithMouse()
    {
        if (upperArea.Contains(Input.mousePosition))
            transform.Translate(Vector3.down * 3 * Time.deltaTime);
        if (lowerArea.Contains(Input.mousePosition))
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
    }

    private void MoveCameraWithEyes()
    {
        if (gazeModel.isEyeTrackerRunning)
        {
            if (upperArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                transform.Translate(Vector3.down * 3 * Time.deltaTime);
            if (lowerArea.Contains((gazeModel.posGazeLeft + gazeModel.posGazeRight) / 2))
                transform.Translate(Vector3.up * 3 * Time.deltaTime);
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
