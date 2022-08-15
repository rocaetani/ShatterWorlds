using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIManager : MonoBehaviour
{

    public static PlayerAPIHandler PlayerAPIHandler;
    public static CharacterAPIHandler CharacterAPIHandler;
    public static LoginAPIHandler LoginApiHandler;
    
    void Awake()
    {
        PlayerAPIHandler = gameObject.AddComponent<PlayerAPIHandler>();
        CharacterAPIHandler = gameObject.AddComponent<CharacterAPIHandler>();
        LoginApiHandler = gameObject.AddComponent<LoginAPIHandler>();
    }
}
