using UnityEngine;
using System.Collections;

public class HUDanim : MonoBehaviour 
{

	public Component[] childAnimations;


	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		childAnimations = GetComponentsInChildren<Animation>();

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
				foreach (Animation animation in childAnimations) 
				{
					animation.Play ();
				}
		}
	}

}
