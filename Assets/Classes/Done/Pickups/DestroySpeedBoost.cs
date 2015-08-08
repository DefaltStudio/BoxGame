using UnityEngine;
using System.Collections;

public class DestroySpeedBoost : MonoBehaviour {

	public float boostAmount = 5.0f;
    public float boostTimeSeconds = 5;

    static private System.Timers.Timer aTimer = new System.Timers.Timer();

    public GameObject SoundPlayer;
    private Vector3 boostStartPos;

    void Start()
    {
        boostStartPos = transform.position;
    }

    void Update()
    {
        //BoostTime();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.player)
        {
            if (PlayerMovementNew.moveSpeed == PlayerMovementNew.initMoveSpeed)
            {
                PlayerMovementNew.moveSpeed += boostAmount;
                Instantiate(SoundPlayer, transform.position, Quaternion.identity);
                Manager.speedBoostStartLocations.Add(boostStartPos);
                StartCoroutine(Wait(5f));
            }
        }
	}

    IEnumerator Wait(float time)
    {
        GetComponentInChildren<Renderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        GetComponentInChildren<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(time);
        ResetSpeed();
    }

    private void ResetSpeed()
    {
        PlayerMovementNew.moveSpeed -= boostAmount;
        Destroy(gameObject);
    }
}
