using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

    SoundManager sound;

    void awake()
    {
        //sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        //Debug.Log(sound.GetInstanceID());
    }

    void OnEnable()
    {
        DialogManager.OnTalking += StartDialog;
        DialogManager.OnLeaving += EndDialog;
    }

    void OnDisable()
    {
        DialogManager.OnTalking -= StartDialog;
        DialogManager.OnLeaving -= EndDialog;
    }

    void StartDialog(string data)
    {
        switch (data)
        {
            case "Gruener Fleck":
                Debug.Log("Grüner Fleck - Weed Drink");
                break;
            case "Hello":
                Debug.Log("Hallo");
                break;
        }
        //sound.PlayVoiceOver("Barkeeper");
    }

    void EndDialog(string data)
    {
        Debug.Log(data);
    }
}
