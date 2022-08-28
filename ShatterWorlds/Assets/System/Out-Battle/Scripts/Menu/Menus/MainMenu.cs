using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuTemplate
{
    public void StartBattle()
    {
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.StartBattle);
        //SceneTransactional.instance.ChangeToBattleScene(OutBattleManager.instance.Player, OutBattleManager.instance.Characters);
    }

    public void CreateCharacter()
    {
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.CreateCharacter);
    }

    public override void InitMenu()
    {
        Debug.Log("Main Menu");
    }
}
