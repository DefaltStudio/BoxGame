using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    IEnumerator Start () {
        Manager.menuIsLoaded = true;

        yield return new WaitForSeconds(5);
        Manager.menuIsLoaded = false;
        Destroy(gameObject);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Application.isEditor)
                System.Diagnostics.Process.GetCurrentProcess().Kill();      // Disable when exporting for web!
        }
    }
}
