using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLFormatter
{
    public String BaseUrl;
    public String PathUrl;
    private static Dictionary<String, String> RequestParameters;

    public URLFormatter(string baseUrl, string pathUrl)
    {
        BaseUrl = baseUrl;
        PathUrl = pathUrl;
        RequestParameters = new Dictionary<string, string>();
    }

    public String GetURL()
    {
        if(String.IsNullOrWhiteSpace(BaseUrl) | String.IsNullOrWhiteSpace(PathUrl))
        {
            ErrorLogger.instance.LogError("URL Base or Path are not setup", this);
            return null;
        }
        String resultURL = $"{BaseUrl}{PathUrl}";
        if (RequestParameters.Count > 0)
        {
            resultURL += "?";
            foreach (String requestParametersName in RequestParameters.Keys)
            {
                resultURL += $"{requestParametersName}={RequestParameters[requestParametersName]}&";
            }
            Debug.Log(resultURL);
            resultURL = resultURL.Remove(resultURL.Length - 1);
        }
        Debug.Log(resultURL);
        return resultURL;
    }

    public void AddRequestParameters(String name, String value)
    {
        RequestParameters.Add(name, value);
    }

}
