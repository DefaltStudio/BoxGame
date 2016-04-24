using UnityEngine;
using System.Collections;

public class temporary_enter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            Manager.LoadLevel(1);
    }
}
