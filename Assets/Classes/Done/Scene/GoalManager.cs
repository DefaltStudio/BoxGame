using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
            Manager.LevelDown();
        else if (Input.GetKeyDown(KeyCode.F11))
            Manager.LevelUp();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (Manager.currentLevel == Application.levelCount - 1)
                Manager.LoadLevel(0);
            else
                Manager.LevelUp();
        }
    }
}
