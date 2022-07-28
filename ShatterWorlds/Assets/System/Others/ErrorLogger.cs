using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using Object = System.Object;

public class ErrorLogger : MonoBehaviour
{
    public static ErrorLogger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("ErrorLogger singleton already instantiated.");
            Destroy(this);
        }

        instance = this;
    }

    public void LogError(String message, Object objectErrorHappen)
    {
        Debug.LogError($"Error in {objectErrorHappen.GetType()}: {message}");
    }

    public void LogAPIError(String message, Object objectErrorHappen, String apiPath)
    {
        Debug.LogError($"Error in {objectErrorHappen.GetType()}: {message} - PATH( {apiPath} )");
    }

}
