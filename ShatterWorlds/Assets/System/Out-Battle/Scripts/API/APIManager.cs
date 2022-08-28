using UnityEngine;

public class APIManager : MonoBehaviour
{
    public static PlayerAPIHandler PlayerAPIHandler;
    public static CharacterAPIHandler CharacterAPIHandler;
    public static LoginAPIHandler LoginApiHandler;
    public static BasicClassHandler BasicClassHandler;

    private void Awake()
    {
        PlayerAPIHandler = gameObject.AddComponent<PlayerAPIHandler>();
        CharacterAPIHandler = gameObject.AddComponent<CharacterAPIHandler>();
        LoginApiHandler = gameObject.AddComponent<LoginAPIHandler>();
        BasicClassHandler = gameObject.AddComponent<BasicClassHandler>();
    }
}