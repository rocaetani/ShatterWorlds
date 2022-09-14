using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoginAPIHandler : MonoBehaviour
{
    private String _baseURL;
    private String _pathURL;
    
    void Awake()
    {
        _baseURL = "http://localhost:8080";
        _pathURL = "/login";
    }

    public void GetLogin(String username, String password, Action<String> actionCallback)
    {
        StartCoroutine(GetLoginCoroutine(username, password, actionCallback));
    }
    
    private IEnumerator GetLoginCoroutine(String username, String password, Action<String>  actionCallback)
    {
        URLFormatter url = new URLFormatter(_baseURL, _pathURL);
        url.AddRequestParameters("username", username);
        url.AddRequestParameters("password", password);
        
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url.GetURL()))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            
            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                String jsonResponse = webRequest.downloadHandler.text;
                actionCallback?.Invoke(jsonResponse);
            }
            else
            {
                ErrorLogger.instance.LogAPIError(webRequest.error, this, url.GetURL());
            }
        }
    }        
}
