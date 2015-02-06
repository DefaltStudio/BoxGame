using UnityEngine;
using System.Collections;

public class GoldCube : MonoBehaviour {

    void Start()
    {
        Manager.goldCubes.Add(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Gold cube collected!");
            Manager.goldCubes.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
