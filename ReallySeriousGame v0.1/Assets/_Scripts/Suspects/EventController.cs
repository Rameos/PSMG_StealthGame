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
        ClueManager.PlayVoice += PlayDialog;

    }

    void OnDisable()
    {
        //DialogManager.PlayVoice -= PlayDialog;
        InteractionManager.PlayVoice -= PlayDialog;
        Interactable.PlayVoice -= PlayDialog;
        ClueManager.PlayVoice -= PlayDialog;

    }

    void PlayDialog(object obj, string name, int index)
    {
        switch (name)
        {
            case "Barkeeper":
                playDialogBarkeeper(obj, index);
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
            case "Barkeep_Clue_1":
                playDialogBarkeeper(obj, -1);
                break;
            case "Barkeep_Clue_2":
                playDialogBarkeeper(obj, index);
                break;
            case "Barkeep_Clue_3":
                playDialogBarkeeper(obj, -3);
                break;
            default:
                break;
        }
    }

    private void playDialogBarkeeper(object obj, int index)
    {
        switch (index)
        {
            case 0:
                sound.PlayVoiceOver(Constants.EventBarkeeperDrink);
                break;
            case 1:
                sound.PlayVoiceOver(Constants.EventBarkeeperMixexperte);
                break;
            case 2:
                sound.PlayVoiceOver(Constants.EventBarkeeperDrogen);
                break;
            case -1:
                sound.PlayVoiceOver(Constants.EventBarkeeperFleck);
                break;
            case -3:
                sound.PlayVoiceOver(Constants.EventBarkeeperRatten);
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
        switch (index)
        {
            case 4:
                sound.PlayVoiceOver(Constants.EventDetektivInteressant);
                break;
            default:
                break;
        }
    }
}
