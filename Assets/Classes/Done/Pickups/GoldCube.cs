using UnityEngine;

public class GoldCube : MonoBehaviour
{
    public GameObject GoldExplosion;
    public float duration = 1.0f;
    private Vector3 goldCubeStartPos;

    void Start()
    {
        Manager.goldCubes.Add(gameObject);
        goldCubeStartPos = transform.position;
    }

    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 2f;
        GetComponentInChildren<Light>().intensity = amplitude;
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
