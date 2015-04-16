using UnityEngine;
using System.Collections;

public class DestroySpeedBoost : MonoBehaviour {

	public float boostAmount = 5.0f;
    public int boostSeconds = 5;

    static private int boostTimeLeft = 0;
    static private System.Timers.Timer aTimer = new System.Timers.Timer();

    void Awake()
    {
        aTimer.Interval = boostSeconds * 1000;
    }

    //void Start () 
    //{
    //    PlayerMovement.BoostAmount = boostAmount;
    //}

    void Update ()
    {
        if (boostTimeLeft != 0)
            PlayerMovement.BoostAmount = boostAmount;
        else
            PlayerMovement.BoostAmount = 0;
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

        Debug.Log("Tick!");
    }
}
