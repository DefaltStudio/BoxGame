using UnityEngine;
using System.Collections;

public class SplashDelayed : MonoBehaviour {

    public float delayTime = 5f;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(1);
    }
}
