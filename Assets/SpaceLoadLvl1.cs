using UnityEngine;
using System.Collections;

public class SpaceLoadLvl1 : MonoBehaviour {

	void Update () {
        if (Input.GetButtonDown("StartGame"))
            Application.LoadLevel(2);
	}
}
