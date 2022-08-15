using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
   [Header("Configuration")] 
    public MenuController MenuController;
    
    [Header("Sign In Form Fields")]
    public InputField Username;
    public InputField Password;
    public Button LoginButton;
    
    private void Update()
    {
        if (AreFieldsValid())
        {
            LoginButton.interactable = true;
        }
        else
        {
            LoginButton.interactable = false;
        }
    }

    private bool AreFieldsValid()
    {
        if (String.IsNullOrWhiteSpace(Username.text) | String.IsNullOrWhiteSpace(Password.text))
        {
            return false;
        }
        return true;
    }

    public void LogIn()
    {
        APIManager.LoginApiHandler.GetLogin(Username.text, Password.text, AfterLoginResponse);
        
    }

    public void AfterLoginResponse(String json)
    {
        
        LoginResponse loginResponse = JsonUtility.FromJson<LoginResponse>(json);
        OutBattleManager.instance.player = loginResponse.player;
        Debug.Log(OutBattleManager.instance.player.username);
        Debug.Log(loginResponse.characters[0].name);
        

        MenuController.ChangeMenu(MenuController.MenuItemCategory.Main);
    }
    


}
