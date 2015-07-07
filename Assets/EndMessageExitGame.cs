using UnityEngine;
using System.Collections;

public class EndMessageExitGame : MonoBehaviour {
    IEnumerator Start()
    {
        yield return new WaitForSeconds(30);
        if (!Application.isEditor)
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
