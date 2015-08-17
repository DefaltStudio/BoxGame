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

	void Update () 
	{
        if (Input.GetButtonDown(Controls.camLeft))
        {
            TurnCamLeft();
        }

        else if (Input.GetButton(Controls.camRight))
        {
            TurnCamRight();
        }
	}

    void playForward(string Animation)
    {
        GetComponent<Animation>()[Animation].speed = 2.0f;
        GetComponent<Animation>().Play(Animation);
        camLocation++;
        if (camLocation == 4)
            camLocation = 0;
    }

    void playReverse(string Animation)
    {
        GetComponent<Animation>()[Animation].speed = -2.0f;
        GetComponent<Animation>()[Animation].time = GetComponent<Animation>()[Animation].length;
        GetComponent<Animation>().Play(Animation);
        camLocation--;
        if (camLocation == -1)
            camLocation = 3;
    }

    void TurnCamLeft()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            if (camLocation == 0)
            {
                //playForward("CameraLeft1");
                //player.transform.Rotate(0, 90, 0);
            }
            else if (camLocation == 1)
            {
                //playForward("CameraLeft2");
                //player.transform.Rotate(0, 90, 0);
            }

            else if (camLocation == 2)
            {
                //playForward("CameraLeft3");
                //player.transform.Rotate(0, 90, 0);
            }

            else if (camLocation == 3)
            {
                //playForward("CameraLeft4");
                //player.transform.Rotate(0, 90, 0);
            }
        }
    }

    void TurnCamRight()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            if (camLocation == 1)
            {
                //playReverse("CameraLeft1");
                //player.transform.Rotate(0, -90, 0);
            }
            else if (camLocation == 2)
            {
                //playReverse("CameraLeft2");
                //player.transform.Rotate(0, -90, 0);
            }
            else if (camLocation == 3)
            {
                //playReverse("CameraLeft3");
                //player.transform.Rotate(0, -90, 0);
            }
            else if (camLocation == 0)
            {
                //playReverse("CameraLeft4");
                //player.transform.Rotate(0, -90, 0);
            }
        }
    }
}
