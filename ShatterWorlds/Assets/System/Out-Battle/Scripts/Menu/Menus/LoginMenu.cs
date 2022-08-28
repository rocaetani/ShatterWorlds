using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class LoginMenu : MenuTemplate
{
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
        if(String.IsNullOrWhiteSpace(Username.text) | String.IsNullOrWhiteSpace(Password.text))
        {
            return false;
        }
        return true;
    }

    public void LogIn()
    {
        OutBattleManager.instance.LogIn(Username.text, Password.text);
        
    }

    public override void InitMenu()
    {
        Debug.Log("Login Menu");

    }
}
