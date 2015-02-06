using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public static int currentLevel = 0;
    private static int levelCount = 0;
    public static List<GameObject> goldCubes = new List<GameObject>();

    void Start()
    {
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
            Debug.Log("Load Level (" + level + ")");
            Application.LoadLevel(level); 
        }
        else
        {
            Debug.Log("Could not load level (" + level + "); collect all gold cubes first!");
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
