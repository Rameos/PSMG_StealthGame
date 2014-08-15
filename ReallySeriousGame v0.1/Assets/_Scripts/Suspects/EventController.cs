using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

    SoundManager sound;

    void Awake()
    {
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    void OnEnable()
    {
        DialogManager.PlayVoice += PlayDialog;
    }

    void OnDisable()
    {
        DialogManager.PlayVoice -= PlayDialog;
    }

    void PlayDialog(object obj, string data)
    {
        sound.PlayVoiceOver(data);
    }
}
