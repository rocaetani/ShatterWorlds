using System;
using outBattle;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class SignInMenu : MenuTemplate
{

    [Header("Sign In Form Fields")]
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
            if (!string.IsNullOrWhiteSpace(Password.text))
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
        var player = new Player(Username.text, Password.text);
        APIManager.PlayerAPIHandler.PostPlayer(player, AfterSignInResponse);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Loading);
    }

    public void AfterSignInResponse(string json)
    {
        OutBattleManager.instance.Player = JsonUtility.FromJson<Player>(json);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.CreateFirstCharacter);
        Debug.Log(OutBattleManager.instance.Player.playerId);

    }

    public void CheckValidateUsername()
    {
        if (!string.IsNullOrWhiteSpace(Username.text))
        {
            ChangeInputColor(Username, Color.yellow); //TODO change this to loading animation
            APIManager.PlayerAPIHandler.GetUsernameValidation(Username.text, UseUsernameValidation);
        }
    }

    public void UseUsernameValidation(string json)
    {
        Debug.Log(json);
        bool isValid = bool.Parse(json);
        if (isValid)
        {
            ChangeInputColor(Username, Color.green); //TODO change this to green on the box
            _usernameIsValid = true;
        }
        else
        {
            ChangeInputColor(Username, Color.red); //TODO change this to red on the box 
            _usernameIsValid = false;
        }
    }

    public void ChangeInputColor(InputField field, Color color)
    {
        var block = field.colors;
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

    public override void InitMenu()
    {
        Debug.Log("SignIn Menu");
    }
}
