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
        outBattle.Character character = new outBattle.Character(OutBattleManager.instance.Player, "ciclano", "Humano", basicClass, 1, 0, CreateBasicAttributes());
        SendCharacterToServer(character);
    }

    public void SendCharacterToServer(outBattle.Character character)
    {
        APIManager.CharacterAPIHandler.PostCharacter(character, AfterCharacterCreation);
    }

    public void AfterCharacterCreation(string json)
    {
        outBattle.Character character = JsonUtility.FromJson<outBattle.Character>(json);
        OutBattleManager.instance.Characters.Add(character);
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
