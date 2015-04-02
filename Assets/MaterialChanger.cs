using UnityEngine;
using System.Collections;

public class MaterialChanger : MonoBehaviour {

    public Material defaultMaterial;
    public Material transparentMaterial;
    public float fadeDuration = 2.0F;

    void Start()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, fadeDuration) / fadeDuration;
        GetComponent<Renderer>().material.Lerp(defaultMaterial, transparentMaterial, lerp);
    }
    
}
