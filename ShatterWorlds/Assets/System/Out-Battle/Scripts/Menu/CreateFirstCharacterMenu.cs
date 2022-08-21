using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using outBattle;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateFirstCharacterMenu : MonoBehaviour
{


    public void CreateWarrior()
    {
        CreateCharacter(1);
    }
    

    public void CreateArcher()
    {
        CreateCharacter(2);
    }

    
    public void CreateMage()
    {
        CreateCharacter(3);
    }
    

    public void CreateCharacter(int basicClassId)
    {
        Character character = new Character(OutBattleManager.instance.Player, "ciclano", "Humano", basicClassId, 1, 0, CreateBasicAttributes());
        String json = JsonUtility.ToJson(character);

        
        SendCharacterToServer(character);
    }

    public void SendCharacterToServer(Character character)
    {
        APIManager.CharacterAPIHandler.PostCharacter(character,  AfterCharacterCreation);
    }

    public void AfterCharacterCreation(String json)
    {
        Character character = JsonUtility.FromJson<Character>(json);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }

    public Attributes CreateBasicAttributes()
    {
        return new Attributes(10,10,10,10,10,10,10,10);
    }
}
