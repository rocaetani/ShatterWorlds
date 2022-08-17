using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutBattleManager : MonoBehaviour
{
    public static OutBattleManager instance;
    public Player Player;
    public List<Character> Characters;    


    public void Awake()
    {
        if (instance != null)
        {
            ErrorLogger.instance.LogError("OutBattleManager singleton already instantiated.", this);
            Destroy(this);
        }

        instance = this;
        if (SceneTransactional.instance.InToOutTransaction.comebackMenu == MenuController.MenuItemCategory.Main)
        {
            MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
            LoadPlayerData();
        }
    }

    public void LoadPlayerData()
    {
        Player player = SceneTransactional.instance.InToOutTransaction.Player;
        LogIn(player.username,player.password);
    }

    public void LogIn(String username, String password)
    {
        APIManager.LoginApiHandler.GetLogin(username, password, AfterLoginResponse);
        
    }

    public void AfterLoginResponse(String json)
    {
        
        LoginResponse loginResponse = JsonUtility.FromJson<LoginResponse>(json);
        Player = loginResponse.player;
        Characters = loginResponse.characters;
        
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }
    
    public void OnDestroy()
    {
        instance = null;
    }
}
