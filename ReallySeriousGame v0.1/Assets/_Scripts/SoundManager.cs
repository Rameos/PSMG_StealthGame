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
	public AudioClip[] voiceClip;
	
	
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
                voiceOverSound = voiceClip[0];
                break;
            case Constants.EventBarkeeperMixexperte:
                voiceOverSound = voiceClip[1];
                break;
            case Constants.EventBarkeeperFleck:
                voiceOverSound = voiceClip[2];
                break;            
            case Constants.EventBarkeeperMischung:
                voiceOverSound = voiceClip[3];
                break;
            case Constants.EventBarkeeperErfolgsgeheimnis:
                voiceOverSound = voiceClip[4];
                break;
            case Constants.EventBarkeeperKillerdrink:
                voiceOverSound = voiceClip[5];
                break;
            case Constants.EventBarkeeperRatten:
                voiceOverSound = voiceClip[6];
                break;
            case Constants.EventBarkeeperDrogen:
                voiceOverSound = voiceClip[7];
                break;
            case Constants.EventBarkeeperRattengift:
                voiceOverSound = voiceClip[8];
                break;
            case Constants.EventBarkeeperBesterDrink:
                voiceOverSound = voiceClip[9];
                break;
            case Constants.EventBarkeeperAllesMischen:
                voiceOverSound = voiceClip[10];
                break;
                //Events Detektiv
            case Constants.EventDetektivBesserNicht:
                voiceOverSound = voiceClip[11];
                break;
            case Constants.EventDetektivZimmerUntersuchen:
                voiceOverSound = voiceClip[12];
                break;
            case Constants.EventDetektivVersuchZuMischen:
                voiceOverSound = voiceClip[13];
                break;
            case Constants.EventDetektivInteressant:
                voiceOverSound = voiceClip[14];
                break;
            case Constants.EventDetektivNichtGut:
                voiceOverSound = voiceClip[15];
                break;
            case Constants.EventDetektivBuchUntersuchen:
                voiceOverSound = voiceClip[16];
                break;
            case Constants.EventDetektivWlanAusschalten:
                voiceOverSound = voiceClip[17];
                break;
            case Constants.EventDetektivSchlossKnacken:
                voiceOverSound = voiceClip[18];
                break;
            case Constants.EventDetektivBesserLassen:
                voiceOverSound = voiceClip[19];
                break;
            case Constants.EventDetektivFallGeloest:
                voiceOverSound = voiceClip[20];
                break;
                //Events Junkie
            case Constants.EventJunkieMedizin:
                voiceOverSound = voiceClip[21];
                break;
            case Constants.EventJunkieWasIsLos:
                voiceOverSound = voiceClip[22];
                break;
            case Constants.EventJunkieCharly:
                voiceOverSound = voiceClip[23];
                break;
            case Constants.EventJunkieHoseGeklaut:
                voiceOverSound = voiceClip[24];
                break;
            case Constants.EventJunkieSchaefchen:
                voiceOverSound = voiceClip[25];
                break;
            case Constants.EventJunkieVomBarmann:
                voiceOverSound = voiceClip[26];
                break;
            case Constants.EventJunkieMalen:
                voiceOverSound = voiceClip[27];
                break;
            case Constants.EventJunkieKurzNippen:
                voiceOverSound = voiceClip[28];
                break;
            case Constants.EventJunkieBraucheStoff:
                voiceOverSound = voiceClip[29];
                break;
            case Constants.EventJunkieMalenDiesUndDas:
                voiceOverSound = voiceClip[30];
                break;
            case Constants.EventJunkieCharlyNein:
                voiceOverSound = voiceClip[31];
                break;
            case Constants.EventJunkieNachschub:
                voiceOverSound = voiceClip[32];
                break;
            case Constants.EventJunkieHirte:
                voiceOverSound = voiceClip[33];
                break;
                //Events Doctor
            case Constants.EventDoctorDummeMenschen:
                voiceOverSound = voiceClip[34];
                break;
            case Constants.EventDoctorBinBeschaeftigt:
                voiceOverSound = voiceClip[35];
                break;
            case Constants.EventDoctorNochDa:
                voiceOverSound = voiceClip[36];
                break;
            case Constants.EventDoctorPflanzen:
                voiceOverSound = voiceClip[37];
                break;
            case Constants.EventDoctorFingerWeg:
                voiceOverSound = voiceClip[38];
                break;
            case Constants.EventDoctorIstAerztin:
                voiceOverSound = voiceClip[39];
                break;
            case Constants.EventDoctorKeinAlkohol:
                voiceOverSound = voiceClip[40];
                break;
            case Constants.EventDoctorZuTun:
                voiceOverSound = voiceClip[41];
                break;
            case Constants.EventDoctorFaszinationPflanzen:
                voiceOverSound = voiceClip[42];
                break;
            case Constants.EventDoctorMedikament:
                voiceOverSound = voiceClip[43];
                break;
            case Constants.EventDoctorKrebsHeilen:
                voiceOverSound = voiceClip[44];
                break;
            case Constants.EventDoctorZeitVerschwenden:
                voiceOverSound = voiceClip[45];
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
