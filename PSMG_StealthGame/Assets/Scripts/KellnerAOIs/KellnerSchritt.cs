﻿using UnityEngine;
using System.Collections;
using iViewX;

public class KellnerSchritt : MonoBehaviourWithGazeComponent
{
    GameObject Kellner;
    float waitForIt = 2f;
    bool stillLooking = false;

    void Start()
    {
        Kellner = GameObject.FindGameObjectWithTag("waiter");
    }

    void Update()
    {

    }

    public override void OnGazeEnter(RaycastHit hit)
    {
        stillLooking = true;
        Kellner.GetComponent<KellnerTalk>().dealWithMessage("Schritt");

        StartCoroutine(callLater(waitForIt));
    }

    public override void OnGazeExit()
    {
        stillLooking = false;
    }

    public override void OnGazeStay(RaycastHit hit)
    {

    }

    IEnumerator callLater(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (stillLooking)
        {
            Kellner.GetComponent<KellnerTalk>().dealWithMessage("SchrittLong");
        }

    }
}
