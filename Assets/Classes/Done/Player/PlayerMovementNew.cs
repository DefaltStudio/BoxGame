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

    public static float boostAmount;
    public static float boostTimeSeconds;
    public static float boostTimeLeft = 0f;

    private static Vector3 spawnPosition;
    //private Quaternion targetRotation;
    public static float initMoveSpeed;
    #endregion


    void Awake()
    {
        Cursor.visible = false; // Move this to another script.

        EnemyShooting.FPC = transform;
        spawnPosition = transform.position;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | 
                                                RigidbodyConstraints.FreezeRotationY | 
                                                RigidbodyConstraints.FreezeRotationZ; // Is this even needed?
        CameraTurn.player = gameObject; // Try disabling this
        initMoveSpeed = playerMoveSpeed;   // this should not be needed
    }

    void Start()
    {
        //targetRotation = GetComponent<Rigidbody>().rotation;
        //Debug.Log("Target Rotation, Start: " + targetRotation);
    }

    void FixedUpdate() // Movement in here
    {
        float h = Input.GetAxis(Controls.horizontal); float v = Input.GetAxis(Controls.vertical);
        MovementManagement(h, v);

        //GetComponent<Rigidbody>().MoveRotation(Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, Time.deltaTime * turnSmoothing));
    }

    void Update()
    {
        if (Input.GetButtonDown(Controls.resetPlayer))
            PlayerDie();
        //if (Input.GetButtonDown(Controls.camLeft))
        //    RotatePlayer("left");
        //if (Input.GetButtonDown(Controls.camRight))
        //    RotatePlayer("right");
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == Tags.enemy)
        {
            PlayerDie();
        }
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
            AlignPlayer();
        }
    }

    private void RotatePlayer (string direction)
    {
        //Debug.Log("Target Rotation, RotatePlayer" + targetRotation);
        direction.Trim().ToLower();

        if (direction == "left" && CameraTurn.playerCanRotate)
        {
            CameraTurn.playerCanRotate = false;
            // targetRotation ...
        }
        if (direction == "right" && CameraTurn.playerCanRotate)
        {
<<<<<<< HEAD
            //float lerpT = Time.deltaTime * moveSpeed * 2;
            if (horizontal != 0f || vertical != 0f)
            {
                Vector3 camDirection = Camera.main.transform.forward;
                camDirection.y = transform.position.y;
                camDirection.Normalize();

                Vector3 movement = new Vector3(horizontal, 0f, vertical);
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * Time.deltaTime * moveSpeed);
=======
            CameraTurn.playerCanRotate = false;
            // targetRotation ...
        }
    }

    private void AlignPlayer()
    {
        float roundX = Mathf.RoundToInt(GetComponent<Rigidbody>().position.x),
                    roundZ = Mathf.RoundToInt(GetComponent<Rigidbody>().position.z);

        float lerpedX = Mathf.Lerp(GetComponent<Rigidbody>().position.x, roundX, Time.deltaTime * snapSmoothing),
                lerpedZ = Mathf.Lerp(GetComponent<Rigidbody>().position.z, roundZ, Time.deltaTime * snapSmoothing);
>>>>>>> Features

        Vector3 newRoundedPos = new Vector3(lerpedX, 0.5f, lerpedZ);
        GetComponent<Rigidbody>().MovePosition(newRoundedPos);
    }

    private void PlayerDie()
    {
        Debug.Log(spawnPosition);
        Instantiate(prefabs.explosion, transform.position, Quaternion.identity);
        GetComponent<Rigidbody>().velocity = new Vector3(0f, -0.1f, 0f);
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