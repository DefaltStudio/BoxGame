using UnityEngine;
using System.Collections;

public class SpaceLoadLvl1 : MonoBehaviour {

	void Update () {
        if (Application.loadedLevel == 6)
            wait(11);
        
        if (Input.GetButtonDown("StartGame"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
	}

    private IEnumerator wait(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
