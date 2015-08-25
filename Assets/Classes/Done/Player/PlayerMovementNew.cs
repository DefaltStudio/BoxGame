using System.Collections;
using UnityEngine;

[System.Serializable]
public class Prefabs
{
    public GameObject explosion;
    public GameObject goldCube;
    public GameObject speedBoost;
}

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementNew : MonoBehaviour
{
    #region Variables
    public static float playerMoveSpeed = 5f;
    public Prefabs prefabs;
    public float turnSmoothing = 2f;
    public float snapSmoothing = 8f;
    public float playerRotation = 0f;
	public float Jumphight = 50f;

    public static float boostAmount;
    public static float boostTimeSeconds;
    public static float boostTimeLeft = 0f;

    private static Vector3 spawnPosition;
    private static Quaternion spawnRotation;
    public static Quaternion targetRotation;
    public static float initMoveSpeed;
    #endregion


    void Awake()
    {
        Cursor.visible = false; // Move this to another script.

        EnemyShooting.playerSpawn = transform;
        ArrowEnemy.playerTransform = transform;

        spawnPosition = transform.position;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | 
                                                RigidbodyConstraints.FreezeRotationY | 
                                                RigidbodyConstraints.FreezeRotationZ; // Is this even needed?
        CameraTurn.player = gameObject; // Try disabling this
        initMoveSpeed = playerMoveSpeed;   // this should not be needed

		SmoothFollowPlayer.target = gameObject.transform;
    }

    void Start()
    {
        spawnRotation = GetComponent<Rigidbody>().rotation;
		targetRotation = GetComponent<Rigidbody>().rotation;
        //Debug.Log("Target Rotation, Start: " + targetRotation);
    }

    void FixedUpdate() // Movement in here
    {
        float h = Input.GetAxis(Controls.horizontal); float v = Input.GetAxis(Controls.vertical);
        MovementManagement(h, v);

		GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(
			GetComponent<Rigidbody>().rotation, targetRotation, Time.deltaTime * turnSmoothing));
    }

    void Update()
	{
		
        if (Input.GetButtonDown(Controls.resetPlayer))
            PlayerDie();
        if (Input.GetButtonDown(Controls.camLeft))
            RotatePlayer("left");
        if (Input.GetButtonDown(Controls.camRight))
           RotatePlayer("right");

		if (Input.GetButtonDown(Controls.jump)) 
		{
			GetComponent<Rigidbody>().AddForce(transform.up * Jumphight);
		}
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == Tags.enemy)
        {
            PlayerDie();

        }
    }

    private bool isOnGround()
    {
        RaycastHit rayHit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(downRay, out rayHit))
        {
            if (rayHit.distance == 0)
                return true;
        }

        return false;
    }

    private void MovementManagement (float horizontal, float vertical)
    {
        if (horizontal != 0f || vertical != 0f)
        {
            Vector3 movement = new Vector3(horizontal, 0f, vertical);
            movement = transform.TransformDirection(movement);
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * Time.deltaTime * playerMoveSpeed);
        }
        if (horizontal == 0f && vertical == 0f)
        {
            if (!isOnGround())
                AlignPlayer();
        }
    }

    private void RotatePlayer (string direction)
    {
        Debug.Log("Target Rotation, RotatePlayer" + targetRotation);
        direction.Trim().ToLower();

        if (direction == "left")
        {
			Debug.Log("left");
            targetRotation.eulerAngles += new Vector3(0f, 90f, 0f);
        }
        if (direction == "right")
        {
            targetRotation.eulerAngles -= new Vector3(0f, 90f, 0f);
        }
    }

  	 private void AlignPlayer()
    {
        float roundX = Mathf.RoundToInt(GetComponent<Rigidbody>().position.x),
                    roundZ = Mathf.RoundToInt(GetComponent<Rigidbody>().position.z);

        float lerpedX = Mathf.Lerp(GetComponent<Rigidbody>().position.x, roundX, Time.deltaTime * snapSmoothing),
                lerpedZ = Mathf.Lerp(GetComponent<Rigidbody>().position.z, roundZ, Time.deltaTime * snapSmoothing);

		float NewY = Mathf.Round(transform.position.y) + 0.5f;

       Vector3 newRoundedPos = new Vector3(lerpedX, transform.position.y , lerpedZ);

       GetComponent<Rigidbody>().MovePosition(newRoundedPos);
    }

    private void PlayerDie()
    {
        Instantiate(prefabs.explosion, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().velocity = new Vector3(0f, -0.1f, 0f);
        targetRotation = spawnRotation;
        GetComponent<Rigidbody>().rotation = spawnRotation;
        transform.position = spawnPosition;
        RespawnPickups();
        playerMoveSpeed = initMoveSpeed;
    }

    private void RespawnPickups()
    {
        foreach (Vector3 speedBoostStartLocation in Manager.speedBoostStartLocations)
        {
            Instantiate(prefabs.speedBoost, speedBoostStartLocation, Quaternion.identity);
        }

        foreach (Vector3 goldCubeStartLocation in Manager.goldCubeStartLocations)
        {
            Instantiate(prefabs.goldCube, goldCubeStartLocation, Quaternion.identity);
        }

        Manager.speedBoostStartLocations.Clear();
        Manager.goldCubeStartLocations.Clear();
    }
}