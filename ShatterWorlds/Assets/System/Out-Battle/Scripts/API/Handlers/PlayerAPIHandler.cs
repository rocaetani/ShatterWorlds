using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAPIHandler : MonoBehaviour
{
    
    private String _baseURL;
    private String _pathURL;
    
    void Awake()
    {
        _baseURL = "http://localhost:8080";
        _pathURL = "/player/";
    }

    public void GetPlayer(String playerId, Action<String> actionCallback)
    {
        StartCoroutine(GetPlayerCoroutine(playerId, actionCallback));
    }
    private IEnumerator GetPlayerCoroutine(String playerId, Action<String>  actionCallback)
    {
        String uri = _baseURL + _pathURL + playerId; 
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
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
                ErrorLogger.instance.LogAPIError(webRequest.error, this, uri);
            }
        }
    }
    
    
    public void GetUsernameValidation(String username, Action<String> actionCallback)
    {
        StartCoroutine(GetUsernameValidationCoroutine(username, actionCallback));
    }
    private IEnumerator GetUsernameValidationCoroutine(String username, Action<String> actionCallback)
    {
        String uri = _baseURL + _pathURL + "validate/" +  username; 
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
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
                ErrorLogger.instance.LogAPIError(webRequest.error, this, uri);
            }
        }
    }
    
    
    public void PostPlayer(Player player, Action<String> actionCallback)
    {
        StartCoroutine(PostPlayerCoroutine(player, actionCallback));
    }

    private IEnumerator PostPlayerCoroutine(Player player, Action<String>  actionCallback)
    {
        String json = JsonUtility.ToJson(player);
        
        String uri = _baseURL + _pathURL;
        using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
        {   
            webRequest.SetRequestHeader("Content-Type", "application/json");

            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            
            yield return webRequest.SendWebRequest();
            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                String jsonResponse = webRequest.downloadHandler.text;
                actionCallback?.Invoke(jsonResponse);
            }
            else
            {
                ErrorLogger.instance.LogAPIError(webRequest.error, this, uri);
            }
        }
    }
}
