using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public static int currentLevel = 0;
    private static int levelCount = 0;
    public static List<GameObject> goldCubes = new List<GameObject>();
    public static List<Vector3> goldCubeStartLocations = new List<Vector3>();
    public static List<Vector3> speedBoostStartLocations = new List<Vector3>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F13)) { DebugLoadLevel(Application.loadedLevel - 1); }
        if (Input.GetKeyDown(KeyCode.F14)) { DebugLoadLevel(Application.loadedLevel + 1); }
    }

    void Awake()
    {
        levelCount = Application.levelCount - 1;
        currentLevel = Application.loadedLevel;   
    }

    private static void LoadLevel(int level)
    {
        if (goldCubes.Count == 0)
        {
            Debug.Log("Clearing goldCubes, goldCubeStartLocations and speedBoostStartLocations lists");
            goldCubes.Clear();
            goldCubeStartLocations.Clear();
            speedBoostStartLocations.Clear();
            Debug.Log("Load Level (" + level + ")");
            Application.LoadLevel(level);
        }
        else
        {
            Debug.Log("Could not load level (" + level + "); collect all gold cubes first!");
        }
    }

    private static void DebugLoadLevel(int level)
    {
        if (level > 0 && level < Application.levelCount)
        {
            Debug.Log("Clearing goldCubes, goldCubeStartLocations and speedBoostStartLocations lists");
            goldCubes.Clear();
            goldCubeStartLocations.Clear();
            speedBoostStartLocations.Clear();
            Debug.Log("Load Level (" + level + ")");
            Application.LoadLevel(level);
        }
    }

    public static void LevelUp()
    {
        bool tmp = currentLevel < levelCount;
        Debug.Log("Level Up: " + tmp);
        if (currentLevel < levelCount)
                LoadLevel(currentLevel + 1);
        
    }

    public static void LevelDown()
    {
        if (currentLevel > 1)
            LoadLevel(currentLevel - 1);
    }
}
