using UnityEngine;
using System.Collections;

public class DestroySpeedBoost : MonoBehaviour {

	public float boostAmount = 5.0f;
    public float boostTimeSeconds = 5;

    static private float boostTimeLeft = 0;
    static private System.Timers.Timer aTimer = new System.Timers.Timer();

    void Awake()
    {
        PlayerMovement.boostTimeSeconds = boostTimeSeconds;
    }

    void Start()
    {
        PlayerMovement.boostAmount = boostAmount;
    }

	void OnCollisionEnter(Collision hit)
	{
		Destroy (gameObject);
	}

    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        if (boostTimeLeft > 0)
            boostTimeLeft--;
        else
            aTimer.Enabled = false;
    }
}
