using UnityEngine;
using System.Collections;
using iViewX;

public class KellnerStift : MonoBehaviourWithGazeComponent
{
    GameObject Kellner;

    void Start()
    {
        Kellner = GameObject.FindGameObjectWithTag("waiter");
    }

    void Update()
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
        if (Input.GetKeyDown("space"))
        {
            Kellner.GetComponent<KellnerTalk>().dealWithMessage("Stift");
        }
    }

}
