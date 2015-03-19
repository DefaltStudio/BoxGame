using UnityEngine;
using System.Collections;

public class DestroySpeedBoost : MonoBehaviour {

	public float Boostamount = 5.0f;

	// Use this for initialization
	void Start () 
	{
		PlayerMovement.BoostAmount = Boostamount;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision hit)

	{
		Destroy (gameObject);
	}
}
