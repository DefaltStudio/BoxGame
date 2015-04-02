using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    float currentMusicTime;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        currentMusicTime = GetComponent<AudioSource>().time;
    }

    void OnLevelWasLoaded(int lvl)
    {
        GetComponent<AudioSource>().time = currentMusicTime;
    }
}
