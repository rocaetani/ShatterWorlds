using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class SingIn : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public InputField ConfirmPassword;

    public Button SignInButton;
    
    private bool _usernameIsValid;

    private void Start()
    {
        _usernameIsValid = false;
    }

    private void Update()
    {
        if (AreFieldsValid())
        {
            SignInButton.interactable = true;
        }
        else
        {
            SignInButton.interactable = false;
        }
    }

    private bool AreFieldsValid()
    {
        if (_usernameIsValid)
        {
            if (!String.IsNullOrWhiteSpace(Password.text))
            {
                if (IsPasswordConfirmed())
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void SignIn()
    {
        Player player = new Player(Username.text, Password.text);
        PlayerAPIHandler.instance.PostPlayer(player,  PrintReturn);
    }

    public void PrintReturn(String json)
    {
        Player player = JsonUtility.FromJson<Player>(json);
        Debug.Log(json);
        Debug.Log(player.password);
    }

    public void CheckValidateUsername()
    {
        if (!String.IsNullOrWhiteSpace(Username.text))
        {
            ChangeInputColor(Username, Color.yellow); //TODO change this to loading animation
            PlayerAPIHandler.instance.GetUsernameValidation(Username.text, UseUsernameValidation);
        }
    }

    public void UseUsernameValidation(String json)
    {
        Debug.Log(json);
        bool isValid = Boolean.Parse(json);
        if (isValid)
        {
            ChangeInputColor(Username, Color.green); //TODO change this to green on the box
            _usernameIsValid = true;
        }
        else
        {
            ChangeInputColor(Username, Color.red);  //TODO change this to red on the box 
            _usernameIsValid = false;
        }
    }

    public void ChangeInputColor(InputField field, Color color)
    {
        ColorBlock block = field.colors;
        block.normalColor = color;
        field.colors = block;
    }

    public void UsernameFieldChanged()
    {
        _usernameIsValid = false;
        ChangeInputColor(Username, Color.white);
    }

    public bool IsPasswordConfirmed()
    {
        return Password.text == ConfirmPassword.text;
    }

}
