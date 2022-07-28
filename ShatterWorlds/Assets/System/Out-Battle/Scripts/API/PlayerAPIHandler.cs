using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAPIHandler : MonoBehaviour
{

    public static PlayerAPIHandler instance;
    
    private String baseUrl;
    private String playerUrl;
    
    //public delegate void PlayerGetRequestCallback(String apiResponseJson);
    //public static PlayerGetRequestCallback playerGetRequestCallback;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("PlayerAPIHandler singleton already instantiated.");
            Destroy(this);
        }

        instance = this;
        baseUrl = "http://localhost:8080";
        playerUrl = "/player/";
    }

    public void GetPlayer(String playerId, Action<String> actionCallback)
    {
        StartCoroutine(GetPlayerCoroutine(playerId, actionCallback));
    }
    private IEnumerator GetPlayerCoroutine(String playerId, Action<String>  actionCallback)
    {
        String uri = baseUrl + playerUrl + playerId; 
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
        String uri = baseUrl + playerUrl + "validate/" +  username; 
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
        
        WWWForm form = new WWWForm();

        String json = JsonUtility.ToJson(player);
        
        Debug.Log(json);
        form.AddField("",json );
        
        String uri = baseUrl + playerUrl;
        using (UnityWebRequest webRequest = new UnityWebRequest(uri, "POST"))
        {   
            webRequest.SetRequestHeader("Content-Type", "application/json");

            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
            
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
