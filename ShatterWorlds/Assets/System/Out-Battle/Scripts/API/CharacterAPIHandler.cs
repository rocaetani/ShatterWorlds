using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterAPIHandler : MonoBehaviour
{
    
    
    private String _baseURL;
    private String _pathURL;
    
    void Awake()
    {
        _baseURL = "http://localhost:8080";
        _pathURL = "/character/";
    }
    
    
    public void PostCharacter(Character character, Action<String> actionCallback)
    {
        StartCoroutine(PostCharacterCoroutine(character, actionCallback));
    }

    private IEnumerator PostCharacterCoroutine(Character character, Action<String>  actionCallback)
    {
        String json = JsonUtility.ToJson(character);
        
        GameLogger.instance.Log(json, this);
        
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
