using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour 
{

	public int fart = 0;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.localScale -= new Vector3(0.1F, 0f, 0.1f) * fart * Time.deltaTime;
	}
}
