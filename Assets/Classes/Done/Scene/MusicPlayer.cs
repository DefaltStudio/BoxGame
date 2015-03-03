using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    float currentMusicTime;

    void Start() {
        DontDestroyOnLoad(gameObject);
    }

    void Update() {
        currentMusicTime = audio.time;
    }

    void OnLevelWasLoaded(int lvl)
    {
        audio.time = currentMusicTime;
    }
}
