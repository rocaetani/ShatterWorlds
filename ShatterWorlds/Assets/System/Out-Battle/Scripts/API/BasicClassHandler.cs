using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BasicClassHandler : MonoBehaviour
{
    private string _baseURL;
    private string _pathURL;

    private void Awake()
    {
        _baseURL = "http://localhost:8080";
        _pathURL = "/basicClass/";
    }

    public void GetBasicClasses(Action<string> actionCallback)
    {
        StartCoroutine(GetBasicClassesCoroutine(actionCallback));
    }

    private IEnumerator GetBasicClassesCoroutine(Action<string> actionCallback)
    {
        var uri = _baseURL + _pathURL;
        using (var webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                var jsonResponse = webRequest.downloadHandler.text;
                actionCallback?.Invoke(jsonResponse);
            }
            else
            {
                ErrorLogger.instance.LogAPIError(webRequest.error, this, uri);
            }
        }
    }
}