using UnityEngine;
using System.Collections;

public class MenuItems : MonoBehaviour {

	public void PlayCampaign()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL("http://www.defalt.net");
        #else
            Application.Quit();
        #endif
    }
}
