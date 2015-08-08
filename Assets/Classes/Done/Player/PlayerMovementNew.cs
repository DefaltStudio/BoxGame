using System.Collections;
using UnityEngine;

namespace Assets.Classes.Done.Player
{
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
        public float moveSpeed = 5f;
        public Prefabs prefabs;
        public float turnSmoothing = 2f;

        public float playerRotation = 0;
        private static Vector3 spawnPosition;
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
            //initMoveSpeed = moveSpeed;   // this should not be needed
        }

        void FixedUpdate() // Movement in here
        {
            float h = Input.GetAxis(Controls.horizontal); float v = Input.GetAxis(Controls.vertical);
            MovementManagement(h, v);
        }

        void Update()
        {
            if (Input.GetButtonDown(Controls.resetPlayer))
                PlayerDie();
            if (Input.GetButtonDown(Controls.camLeft))
                RotateCam("left");
            if (Input.GetButtonDown(Controls.camRight))
                RotateCam("right");
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
            //float lerpT = Time.deltaTime * moveSpeed * 2;
            if (horizontal != 0f || vertical != 0f)
            {
                //Vector3 camDirection = Camera.main.transform.forward;
                //camDirection.y = transform.position.y;
                //camDirection.Normalize();


                Vector3 movement = new Vector3(horizontal, 0f, vertical);
                movement = transform.TransformDirection(movement);
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movement * Time.deltaTime * moveSpeed);

                //GetComponent<Rigidbody>().velocity = move * moveSpeed;
            }
        }

        public void RotateCam (string direction)
        {
            direction.Trim().ToLower();
            if (direction == "left" && CameraTurn.playerCanRotate)
            {
                CameraTurn.playerCanRotate = false;
                playerRotation += 90;
                if (playerRotation == 360)
                    playerRotation = 0;

                Quaternion targetRotation = GetComponent<Rigidbody>().rotation;
                targetRotation.eulerAngles = new Vector3(0, playerRotation, 0);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);

            }
            if (direction == "right" && CameraTurn.playerCanRotate)
            {
                CameraTurn.playerCanRotate = false;
                playerRotation -= 90;
                if (playerRotation == -360)
                    playerRotation = 0;

                Quaternion targetRotation = GetComponent<Rigidbody>().rotation;
                targetRotation.eulerAngles = new Vector3(0, playerRotation, 0);
                GetComponent<Rigidbody>().MoveRotation(targetRotation);
            }
        }

        public void PlayerDie()
        {
            Debug.Log(spawnPosition);
            Instantiate(prefabs.explosion, transform.position, Quaternion.identity);
            GetComponent<Rigidbody>().velocity = new Vector3(0f, -0.1f, 0f);
            transform.position = spawnPosition;
        }
    }
}
