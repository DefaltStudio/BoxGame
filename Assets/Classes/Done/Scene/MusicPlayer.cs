using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    public AudioClip spilmusik;
    public AudioClip spilmusikWaiting;

    private float currentMusicTime;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        currentMusicTime = GetComponent<AudioSource>().time;
    }

    void OnLevelWasLoaded(int lvl)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (lvl == 6)
        { audio.clip = spilmusikWaiting; currentMusicTime = 0.0f; audio.Play(); }
        else if (lvl == 7)
        { audio.clip = spilmusik; currentMusicTime = 0.0f; audio.Play(); }
        GetComponent<AudioSource>().time = currentMusicTime;
    }
}
