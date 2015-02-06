using UnityEngine;
using System.Collections;

public class EnemyWanish : MonoBehaviour 
{
	public Transform Target;
	public Color StartColor;
	
	// Use this for initialization
	void Start () 
	{
		StartColor = Target.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter ()
	{
	
		Target.renderer.material.color = Color.green;

		
	}

	void OnCollisionExit()
	{
		Target.renderer.material.color = StartColor;
	}
}
		    