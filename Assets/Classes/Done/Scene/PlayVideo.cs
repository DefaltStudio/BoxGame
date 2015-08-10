using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;
	void Start () {
        GetComponent<Renderer>().material.mainTexture = movie as MovieTexture;
        movie.Play();
	}
}
