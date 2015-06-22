using UnityEngine;
using System.Collections;

public class GoldCube : MonoBehaviour 
{
	public GameObject GoldExplosion;
    private Vector3 goldCubeStartPos;

    void Start()
    {
        Manager.goldCubes.Add(gameObject);
        goldCubeStartPos = transform.position;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Manager.goldCubeStartLocations.Add(goldCubeStartPos);
            Debug.Log("Gold cube collected!");
            Manager.goldCubes.Remove(gameObject);
			Instantiate(GoldExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
