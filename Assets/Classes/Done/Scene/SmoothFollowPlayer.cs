using UnityEngine;
using System.Collections;

public class SmoothFollowPlayer : MonoBehaviour {

	public static Transform target;
	public float distance = 20.0f;
	public float damping = 0.05f;
	public float rotationDamping = 6.0f;

	void Start() 
	{
		transform.position = target.position;
	}

	void LateUpdate() 
	{
		if (!target) return;

		float wantedPosX = target.position.x;
		float wantedPosZ = target.position.z;

		float lerpedPosX = Mathf.Lerp(transform.position.x, wantedPosX, damping * Time.deltaTime);
		float lerpedPosZ = Mathf.Lerp(transform.position.z, wantedPosZ, damping * Time.deltaTime);

		Vector3 wantedPos = new Vector3(lerpedPosX, 10.0f, lerpedPosZ);

		float wantedRotationAngle = target.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		Quaternion targetRotation = Quaternion.identity;
		targetRotation.eulerAngles = new Vector3(0.0f, currentRotationAngle, 0.0f);

		transform.rotation = targetRotation;
		transform.position = wantedPos;





		//transform.position = new Vector3(
			//Mathf.Lerp(transform.position.x, target.position.x, damping * Time.deltaTime),
			//10.0f,
			//Mathf.Lerp (transform.position.z, target.position.z, damping * Time.deltaTime));
	}
}
