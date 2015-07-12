using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRandomMovement : MonoBehaviour {

    public List<GameObject> bounderies;
    public static GameObject newPointObj;
    public float moveSpeed = 5f;
    public GameObject newPoint;

    void Start()
    {
        Instantiate(newPoint, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
         if (transform.position == newPointObj.transform.position)
         {
            Destroy(newPointObj); // Destroy old point
            GenerateNewPoint();    // Generate new point
         }

         transform.position = Vector3.MoveTowards(transform.position, newPointObj.transform.position, moveSpeed * Time.deltaTime);
    }

    private static bool isWithinBounderie(GameObject checkPoint)
    {
        return false;
    }

    private void GenerateNewPoint()
    {
        int randomDir = Mathf.FloorToInt(Random.Range(0f, 4f));

        //Debug.Log("Test1: " + test);

        if (randomDir == 0) // Left
        {
            
            Vector3 left = transform.TransformDirection(Vector3.left);
            RaycastHit hit;
            Ray leftRay = new Ray(transform.position, Vector3.left);
            Physics.Raycast(leftRay, out hit);
            int distance = Mathf.FloorToInt(Random.Range(1f, hit.distance));

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.green, 1);
            Debug.Log("Left Ray Distance: " + hit.distance);
        
            Instantiate(newPoint, transform.position + new Vector3(-distance, 0, 0), Quaternion.identity);
        }
        else if (randomDir == 1) // Right
        {
            
            Vector3 right = transform.TransformDirection(-Vector3.left);
            RaycastHit hit;
            Ray rightRay = new Ray(transform.position, -Vector3.left);
            Physics.Raycast(rightRay, out hit);
            int distance = Mathf.FloorToInt(Random.Range(1f, hit.distance));

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.left) * hit.distance, Color.red, 1);
            Debug.Log("Right Ray Distance: " + hit.distance);

            Instantiate(newPoint, transform.position + new Vector3(distance, 0, 0), Quaternion.identity);
        }
        else if (randomDir == 2) // Forward
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            Ray fwdRay = new Ray(transform.position, Vector3.forward);
            Physics.Raycast(fwdRay, out hit);
            int distance = Mathf.FloorToInt(Random.Range(1f, hit.distance));

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue, 1);
            Debug.Log("Forward Ray Distance: " + hit.distance);

            Instantiate(newPoint, transform.position + new Vector3(0, 0, distance), Quaternion.identity);
        }
        else if (randomDir == 3) // Backwards
        {
            Vector3 back = transform.TransformDirection(-Vector3.forward);
            RaycastHit hit;
            Ray backRay = new Ray(transform.position, -Vector3.forward);
            Physics.Raycast(backRay, out hit);
            int distance = Mathf.FloorToInt(Random.Range(1f, hit.distance));

            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * hit.distance, Color.magenta, 1);
            Debug.Log("Backwards Ray Distance: " + hit.distance);

            Instantiate(newPoint, transform.position + new Vector3(0, 0, -distance), Quaternion.identity);
        }

    }
}
