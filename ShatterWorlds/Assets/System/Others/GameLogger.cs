using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameLogger : MonoBehaviour
{
    public static GameLogger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Logger singleton already instantiated.");
            Destroy(this);
        }

        instance = this;
    }
    
    public void Log(String message, System.Object loggerObject)
    {
        Debug.Log($"{loggerObject}: {message}");
    }

}
