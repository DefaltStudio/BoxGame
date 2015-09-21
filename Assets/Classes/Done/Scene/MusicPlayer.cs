using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    public AudioClip spilmusik;
    public AudioClip spilmusikWaiting;

    public AudioClip animMusic1;
    public AudioClip animMusic2_loop;
    public AudioClip animMusic3_continue;

    private float currentMusicTime;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        currentMusicTime = GetComponent<AudioSource>().time;

        if (!GetComponent<AudioSource>().isPlaying)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = animMusic2_loop; currentMusicTime = 0.0f; audio.Play();
            audio.loop = true;
        }
    }

    void OnLevelWasLoaded(int lvl)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (lvl == 1)
        {
            audio.clip = animMusic1; currentMusicTime = 0.0f; audio.Play();
            audio.loop = false;
        }
        else if (lvl == 6)
        { audio.clip = spilmusikWaiting; currentMusicTime = 0.0f; audio.Play(); }
        else if (lvl == 7)
        { audio.clip = spilmusik; currentMusicTime = 0.0f; audio.Play(); }
        GetComponent<AudioSource>().time = currentMusicTime;
    }
}
