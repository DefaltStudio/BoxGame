using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
    public float maxSpeed = 5f;
	static public float BoostAmount;

	public GameObject explosion;
    private static Vector3 spawnPosition;
	public Transform cam;

	public GameObject playerTransform;

    private Vector3 moveDirection;

    void Start()
    {
		spawnPosition = transform.position;   
        Cursor.visible = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		CameraTurn.player = this.gameObject;
        moveDirection = Vector3.zero;
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
        }

        if (Input.GetButtonDown("TurnLeft"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Rotate(0, 90f, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        if (Input.GetButtonDown("TurnRight"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Rotate(0, -90f, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        if(Input.GetButtonDown("Reset"))
            Die();
    }

	void OnCollisionEnter(Collision hit)

    {
        if(hit.transform.tag == "Enemy")
            Die();

        if(hit.transform.tag == "Ground" || hit.transform.tag == "Wall")
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
   
		if (hit.transform.tag == "PlusBoost") 
		{
			moveSpeed += BoostAmount;
		}
	}

 	void Die()
    {
        GetComponent<AudioSource>().Play();                             // Eksplosion (Lyd)
        Instantiate(explosion, transform.position, transform.rotation); // Eksplosion (Emitter)
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		GetComponent<Rigidbody>().velocity = new Vector3 (0, -.1f, 0);
		transform.position = spawnPosition;
	}
}
