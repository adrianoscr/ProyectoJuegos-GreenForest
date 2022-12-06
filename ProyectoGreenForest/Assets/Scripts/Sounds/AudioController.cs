using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{

    public AudioMixer Music, Effects;
    public AudioSource shot, bite, bgMusic, playSound,BossHit;

    public static AudioController instance;


    private void Awake()
    {
        if (instance==null) {

            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(bgMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio) {


        audio.Play();
    }
}
