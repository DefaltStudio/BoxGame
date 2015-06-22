using UnityEngine;
using System.Collections;

public class DestroySpeedBoost : MonoBehaviour {

	public float boostAmount = 5.0f;
    public float boostTimeSeconds = 5;

    static private float boostTimeLeft = 0;
    static private System.Timers.Timer aTimer = new System.Timers.Timer();

    public GameObject SoundPlayer;
    private static Vector3 boostStartPos;

    // NYT PROBLEM!!!
    // Når den bliver instantiated igen, så er den ikke attacted til soundplayer.
    // Find ny måde at spille lyden på.

    void Awake()
    {
        PlayerMovement.boostTimeSeconds = boostTimeSeconds;
    }

    void Start()
    {
        PlayerMovement.boostAmount = boostAmount;
        boostStartPos = transform.position;
    }

	void OnCollisionEnter(Collision hit)
    {
        Instantiate(SoundPlayer, transform.position, Quaternion.identity);
        Manager.speedBoostStartLocations.Add(boostStartPos);
        Destroy(gameObject);
	}

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        if (boostTimeLeft > 0)
            boostTimeLeft--;
        else
            aTimer.Enabled = false;
    }
}
