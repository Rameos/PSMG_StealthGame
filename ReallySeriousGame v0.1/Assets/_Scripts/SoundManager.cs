using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public static SoundManager soundManager;
	
	private AudioSource musicSource;
	private AudioSource ambientSource;
	private AudioSource voiceOverSource;
	private AudioSource[] soundEffectSource;
	
	public AudioClip[] musicClip;
	public AudioClip[] ambientClip;
	public AudioClip[] noiseClip;
    public AudioClip[] voiceClipBarkeeper;
    public AudioClip[] voiceClipDetective;
    public AudioClip[] voiceClipJunkie;
    public AudioClip[] voiceClipDoctor;
	
	
	private AudioClip backgroundSound;
    private AudioClip voiceOverSound;
	
	void Awake () 
	{
		#region singleton
		if(soundManager == null) 
		{
			DontDestroyOnLoad(gameObject);
			soundManager = this;
		} 
		else if(soundManager != this) 
		{
			Destroy(gameObject);
		}
		#endregion
		
        voiceOverSource = gameObject.AddComponent<AudioSource>();
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource.loop = true;
		
		ambientSource = gameObject.AddComponent<AudioSource>();
		ambientSource.loop = true;
	}
	
	public void PlayBGMusic(string level)
	{
		musicSource.Stop();
		switch(level)
		{
			case "MainMenu":
				backgroundSound = musicClip[Random.Range(0, musicClip.Length)];
				break;
			default: break;
		}
		musicSource.clip = backgroundSound;
		musicSource.Play();
	}
	
	public void StopBGMusic()
	{
		musicSource.Stop();
		musicSource.clip = null;
	}
	
	public void PlayAmbientSound(string level) 
	{
		ambientSource.Stop();
		switch (level)
		{
		case "BarScene":
			backgroundSound = ambientClip[Random.Range(0, 1)];
			break;
		case "Scene_2":
			backgroundSound = ambientClip[Random.Range(2, ambientClip.Length)];
			break;
		default:
			break;
		}
		ambientSource.clip = backgroundSound;
		ambientSource.Play();
	}
	
	public void StopAmbientSound()
	{
		ambientSource.Stop();
		ambientSource.clip = null;
	}
	
	public void PlayVoiceOver(string track)
	{
        voiceOverSource.Stop();
        switch (track)
        {
                //Events Barkeeper
            case Constants.EventBarkeeperDrink:
                voiceOverSound = voiceClipBarkeeper[0];
                break;
            case Constants.EventBarkeeperMixexperte:
                voiceOverSound = voiceClipBarkeeper[1];
                break;
            case Constants.EventBarkeeperFleck:
                voiceOverSound = voiceClipBarkeeper[2];
                break;            
            case Constants.EventBarkeeperMischung:
                voiceOverSound = voiceClipBarkeeper[3];
                break;
            case Constants.EventBarkeeperErfolgsgeheimnis:
                voiceOverSound = voiceClipBarkeeper[4];
                break;
            case Constants.EventBarkeeperKillerdrink:
                voiceOverSound = voiceClipBarkeeper[5];
                break;
            case Constants.EventBarkeeperRatten:
                voiceOverSound = voiceClipBarkeeper[6];
                break;
            case Constants.EventBarkeeperDrogen:
                voiceOverSound = voiceClipBarkeeper[7];
                break;
            case Constants.EventBarkeeperRattengift:
                voiceOverSound = voiceClipBarkeeper[8];
                break;
            case Constants.EventBarkeeperBesterDrink:
                voiceOverSound = voiceClipBarkeeper[9];
                break;
            case Constants.EventBarkeeperAllesMischen:
                voiceOverSound = voiceClipBarkeeper[10];
                break;
                //Events Detektiv
            case Constants.EventDetektivBesserNicht:
                voiceOverSound = voiceClipDetective[0];
                break;
            case Constants.EventDetektivZimmerUntersuchen:
                voiceOverSound = voiceClipDetective[1];
                break;
            case Constants.EventDetektivVersuchZuMischen:
                voiceOverSound = voiceClipDetective[2];
                break;
            case Constants.EventDetektivInteressant:
                voiceOverSound = voiceClipDetective[3];
                break;
            case Constants.EventDetektivNichtGut:
                voiceOverSound = voiceClipDetective[4];
                break;
            case Constants.EventDetektivBuchUntersuchen:
                voiceOverSound = voiceClipDetective[5];
                break;
            case Constants.EventDetektivWlanAusschalten:
                voiceOverSound = voiceClipDetective[6];
                break;
            case Constants.EventDetektivSchlossKnacken:
                voiceOverSound = voiceClipDetective[7];
                break;
            case Constants.EventDetektivBesserLassen:
                voiceOverSound = voiceClipDetective[8];
                break;
            case Constants.EventDetektivFallGeloest:
                voiceOverSound = voiceClipDetective[9];
                break;
                //Events Junkie
            case Constants.EventJunkieMedizin:
                voiceOverSound = voiceClipJunkie[0];
                break;
            case Constants.EventJunkieWasIsLos:
                voiceOverSound = voiceClipJunkie[1];
                break;
            case Constants.EventJunkieCharly:
                voiceOverSound = voiceClipJunkie[2];
                break;
            case Constants.EventJunkieHoseGeklaut:
                voiceOverSound = voiceClipJunkie[3];
                break;
            case Constants.EventJunkieSchaefchen:
                voiceOverSound = voiceClipJunkie[4];
                break;
            case Constants.EventJunkieVomBarmann:
                voiceOverSound = voiceClipJunkie[5];
                break;
            case Constants.EventJunkieMalen:
                voiceOverSound = voiceClipJunkie[6];
                break;
            case Constants.EventJunkieKurzNippen:
                voiceOverSound = voiceClipJunkie[7];
                break;
            case Constants.EventJunkieBraucheStoff:
                voiceOverSound = voiceClipJunkie[8];
                break;
            case Constants.EventJunkieMalenDiesUndDas:
                voiceOverSound = voiceClipJunkie[9];
                break;
            case Constants.EventJunkieCharlyNein:
                voiceOverSound = voiceClipJunkie[10];
                break;
            case Constants.EventJunkieNachschub:
                voiceOverSound = voiceClipJunkie[11];
                break;
            case Constants.EventJunkieHirte:
                voiceOverSound = voiceClipJunkie[12];
                break;
                //Events Doctor
            case Constants.EventDoctorDummeMenschen:
                voiceOverSound = voiceClipDoctor[0];
                break;
            case Constants.EventDoctorBinBeschaeftigt:
                voiceOverSound = voiceClipDoctor[1];
                break;
            case Constants.EventDoctorNochDa:
                voiceOverSound = voiceClipDoctor[2];
                break;
            case Constants.EventDoctorPflanzen:
                voiceOverSound = voiceClipDoctor[3];
                break;
            case Constants.EventDoctorFingerWeg:
                voiceOverSound = voiceClipDoctor[4];
                break;
            case Constants.EventDoctorIstAerztin:
                voiceOverSound = voiceClipDoctor[5];
                break;
            case Constants.EventDoctorKeinAlkohol:
                voiceOverSound = voiceClipDoctor[6];
                break;
            case Constants.EventDoctorZuTun:
                voiceOverSound = voiceClipDoctor[7];
                break;
            case Constants.EventDoctorFaszinationPflanzen:
                voiceOverSound = voiceClipDoctor[8];
                break;
            case Constants.EventDoctorMedikament:
                voiceOverSound = voiceClipDoctor[9];
                break;
            case Constants.EventDoctorKrebsHeilen:
                voiceOverSound = voiceClipDoctor[10];
                break;
            case Constants.EventDoctorZeitVerschwenden:
                voiceOverSound = voiceClipDoctor[11];
                break;
            default:
                break;
        }
        voiceOverSource.clip = voiceOverSound;
        voiceOverSource.Play();
	}
	
	public void StopVoiceOver()
	{
        voiceOverSource.Stop();
        voiceOverSource.clip = null;
	}
	
	public void PlaySoundEffect()
	{
	
	}
	
	public void StopSoundEffect()
	{
	
	}
}
