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
        //DialogManager.PlayVoice += PlayDialog;
        InteractionManager.PlayVoice += PlayDialog;
        Interactable.PlayVoice += PlayDialog;
    }

    void OnDisable()
    {
        //DialogManager.PlayVoice -= PlayDialog;
        InteractionManager.PlayVoice -= PlayDialog;
        Interactable.PlayVoice -= PlayDialog;

    }

    void PlayDialog(object obj, string name, int index)
    {
        switch (name)
        {
            case "Barkeeper":
                playDialogBarkeeper(index);
                break;
            case "Doctor":
                playDialogDoctor(index);
                break;
            case "Junkie": 
                playDialogJunkie(index);
                break;
            case "Detective":
                playDialogDetective(index);
                break;
            default:
                break;
        }
    }

    private void playDialogBarkeeper(int index)
    {
        switch (index)
        {
            case 0:
                sound.PlayVoiceOver(Constants.EventBarkeeperDrink);
                break;
            case 1:
                sound.PlayVoiceOver(Constants.EventBarkeeperMixexperte);
                break;
            default:
                break;
        }
    }

    private void playDialogDoctor(int index)
    {

    }

    private void playDialogJunkie(int index)
    {

    }

    private void playDialogDetective(int index)
    {

    }
}
