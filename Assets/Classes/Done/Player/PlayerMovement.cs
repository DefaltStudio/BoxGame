using System.Collections;
using System.Timers;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
    private float initialMoveSpeed;
    public float maxSpeed = 5f;
	static public float boostAmount;

	public GameObject explosion;
    private static Vector3 spawnPosition;
	public Transform cam;

    public GameObject playerTransform;

    private Vector3 moveDirection;
    public static float boostTimeSeconds;
    private static float boostTimeLeft = 0;

    public GameObject goldCube;
    public GameObject speedBoost;

    void Awake()
    {
        EnemyShooting.FPC = transform;
    }

    void Start()
    {
		spawnPosition = transform.position;   
        Cursor.visible = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		CameraTurn.player = this.gameObject;
        moveDirection = Vector3.zero;
        initialMoveSpeed = moveSpeed;
    }

    void Update() 
	{
	    Vector3 cameraRelativeForward = cam.TransformDirection(Vector3.forward);
	    Vector3 cameraRelativeRight = cam.TransformDirection(Vector3.right);
	    Vector3 cameraRelativeLeft = cam.TransformDirection(Vector3.left);
	    Vector3 cameraRelativeBack = cam.TransformDirection(Vector3.back);

        float distanceToGround = 0f;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            distanceToGround = hit.distance;

        if (distanceToGround < .51)
        {
            if (Input.GetButton("Forward"))
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeForward * moveSpeed * Time.deltaTime);
            if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeLeft * moveSpeed * Time.deltaTime);
            if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeRight * moveSpeed * Time.deltaTime);
            if (Input.GetButton("Reverse"))
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeBack * moveSpeed * Time.deltaTime);

            // Joystick test
            if (Input.GetAxis("HorizontalJoystick") > 0 && !Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") == 0)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeLeft * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalJoystick"));
            if (Input.GetAxis("HorizontalJoystick") < 0 && !Input.GetButton ("Horizontal") && Input.GetAxisRaw("Horizontal") == 0)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeRight * moveSpeed * Time.deltaTime * -Input.GetAxis("HorizontalJoystick"));
            if (Input.GetAxis("Vertical") > 0 && !Input.GetButton("Forward"))
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeForward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
            if (Input.GetAxis("Vertical") < 0 && !Input.GetButton("Reverse"))
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + cameraRelativeBack * moveSpeed * Time.deltaTime * -Input.GetAxis("Vertical"));
        }

        if (Input.GetButtonDown("Reset") || Input.GetButtonDown("ResetPlayer"))
            Die();

        #region boostTimeSeconds

        boostTimeLeft -= Time.deltaTime;
        if (boostTimeLeft <= 0)
            moveSpeed = initialMoveSpeed;

        #endregion
    }

	void OnCollisionEnter(Collision hit)
    {
        if(hit.transform.tag == "Enemy")
            Die();

        if(hit.transform.tag == "Ground" || hit.transform.tag == "Wall")
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
   
		if (hit.transform.tag == "PlusBoost") 
		{
            moveSpeed += boostAmount;
            boostTimeLeft = boostTimeSeconds;
		}
	}

 	void Die()
    {
        moveSpeed = initialMoveSpeed;
        GetComponent<AudioSource>().Play();                             // Eksplosion (Lyd)
        Instantiate(explosion, transform.position, transform.rotation); // Eksplosion (Emitter)
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		GetComponent<Rigidbody>().velocity = new Vector3 (0, -.1f, 0);
		transform.position = spawnPosition;

        foreach (Vector3 speedBoostStartLocation in Manager.speedBoostStartLocations)
        {
            Debug.Log(speedBoostStartLocation.ToString());
        }

        foreach (Vector3 goldCubeStartLocation in Manager.goldCubeStartLocations)
        {
            Debug.Log(goldCubeStartLocation.ToString());

            Instantiate(goldCube, goldCubeStartLocation, Quaternion.identity);
        }
        foreach (Vector3 speedBoostStartLocation in Manager.speedBoostStartLocations)
        {
            Instantiate(speedBoost, speedBoostStartLocation, Quaternion.identity);
        }
        Manager.goldCubeStartLocations.Clear();
        Manager.speedBoostStartLocations.Clear();
	}
}
