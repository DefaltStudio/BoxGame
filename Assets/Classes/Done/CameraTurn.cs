using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraTurn : MonoBehaviour {

    public static int camLocation;
    public static GameObject player;

    void Start()
    {
        camLocation = 0;
    }

	void Update () {
        
		//Debug.Log (player.gameObject.name);
        if (Input.GetButtonDown("TurnLeft"))
        {

            player.transform.Rotate(90, 0, 0, Space.Self);

            if (!animation.isPlaying)
            {
                if (camLocation == 0)
                    playForward("CameraLeft1");
                else if (camLocation == 1)
                    playForward("CameraLeft2"); 
                else if (camLocation == 2)
                    playForward("CameraLeft3");
                else if (camLocation == 3)
                    playForward("CameraLeft4");
            }
        }
        else if (Input.GetButton("TurnRight"))
        {
            player.transform.Rotate(-90, 0, 0, Space.Self);

            if (!animation.isPlaying)
            {
                if (camLocation == 1)
                    playReverse("CameraLeft1");
                else if (camLocation == 2)
                    playReverse("CameraLeft2");
                else if (camLocation == 3)
                    playReverse("CameraLeft3");
                else if (camLocation == 0)
                    playReverse("CameraLeft4");
            }
        }
	}

    void playForward(string Animation)
    {
        animation[Animation].speed = 2.0f;
        animation.Play(Animation);
        camLocation++;
        if (camLocation == 4)
            camLocation = 0;
    }

    void playReverse(string Animation)
    {
        animation[Animation].speed = -2.0f;
        animation[Animation].time = animation[Animation].length;
        animation.Play(Animation);
        camLocation--;
        if (camLocation == -1)
            camLocation = 3;
    }
}
