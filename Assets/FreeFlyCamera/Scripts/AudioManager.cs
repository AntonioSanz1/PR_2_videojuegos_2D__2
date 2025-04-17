using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip bandaSonora;
    public AudioClip fxButton;
    public AudioClip fxCoin;
    public AudioClip fxDead;
    public AudioClip fxFire;

    AudioSource _audioSource;

    AudioSource audioMusic;

    public static AudioManager Instance; 


    public GameObject musicObj;

    public AudioMixerSnapshot defaultSnapshot;
    public AudioMixerSnapshot tunelSnapshot;
    public AudioMixerSnapshot submarinoSnapshot;
    


    void Awake()
    {

        if(Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();

        
        audioMusic = musicObj.GetComponent<AudioSource>();
        _audioSource.clip = bandaSonora;
        _audioSource.loop = true;
        _audioSource.volume = 0.1f;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //método para hacer sonar clips de audio
    public void SonarClipUnaVez(AudioClip ac){

        _audioSource.PlayOneShot(ac);

    }


    public void IniciarEfectoTunel(){
        tunelSnapshot.TransitionTo(0.5f);
    }

    public void IniciarEfectoBurbuja(){
        submarinoSnapshot.TransitionTo(1f);
    }


    public void IniciarEfectoDefault(){
        defaultSnapshot.TransitionTo(0.05f);
    }


}
