using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    SoundManager sound;

    void awake()
    {
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        Debug.Log(sound);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        EventManager.OnClicked += PlayMusic;
    }


    void OnDisable()
    {
        EventManager.OnClicked -= PlayMusic;
    }


    void PlayMusic()
    {
        Debug.Log("Play Sound Event Received");
        //sound.PlayVoiceOver("Barkeeper");
    }
}
