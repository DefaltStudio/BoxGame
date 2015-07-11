using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MostBeautifulGirlInTheWorld : MonoBehaviour {
    public float moveSpeed = 5f;
    public float maxSpeed = 5f;
    public GameObject explosion;
    
    private float initialMoveSpeed;
    private Vector3 moveDirection;

    private static Vector3 spawnPosition;
    private GameObject SweetBeautifulGirl;
    private string BeautifulGirl = "Player";

    void Awake()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        moveDirection = Vector3.zero;
        initialMoveSpeed = moveSpeed;
    }

    void Start()
    {
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T)) // Forward
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.F)) // Left
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.H)) // Right
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.G)) // Down
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void Die()
    {
        moveSpeed = initialMoveSpeed;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Enemy")
            Die();
        if (hit.transform.tag == BeautifulGirl)
            Love.Kiss(SweetBeautifulGirl);
    }
}
