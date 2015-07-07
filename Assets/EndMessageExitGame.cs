using UnityEngine;
using System.Collections;

public class EndMessageExitGame : MonoBehaviour {
    IEnumerator Start()
    {
        yield return new WaitForSeconds(240);
        if (!Application.isEditor)
        {
            Application.OpenURL("http://www.defalt.net/");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Application.isEditor)
            {
                Application.OpenURL("http://www.defalt.net/");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
