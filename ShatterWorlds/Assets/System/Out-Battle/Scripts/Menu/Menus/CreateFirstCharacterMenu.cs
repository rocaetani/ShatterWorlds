using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using outBattle;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateFirstCharacterMenu : MenuTemplate
{


    public void CreateWarrior()
    {
        CreateCharacter(OutBattleManager.instance.BasicClassManager.GetBasicClass(1));
    }


    public void CreateArcher()
    {
        CreateCharacter(OutBattleManager.instance.BasicClassManager.GetBasicClass(2));
    }


    public void CreateMage()
    {
        CreateCharacter(OutBattleManager.instance.BasicClassManager.GetBasicClass(3));
    }


    public void CreateCharacter(BasicClass basicClass)
    {
        var character = new Character(OutBattleManager.instance.Player, "ciclano", "Humano", basicClass, 1, 0, CreateBasicAttributes());
        string json = JsonUtility.ToJson(character);


        SendCharacterToServer(character);
    }

    public void SendCharacterToServer(Character character)
    {
        APIManager.CharacterAPIHandler.PostCharacter(character, AfterCharacterCreation);
    }

    public void AfterCharacterCreation(string json)
    {
        var character = JsonUtility.FromJson<Character>(json);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }

    public Attributes CreateBasicAttributes()
    {
        return new Attributes(10, 10, 10, 10, 10, 10, 10, 10);
    }

    public override void InitMenu()
    {
        Debug.Log("Create First Character Menu");

    }
}
