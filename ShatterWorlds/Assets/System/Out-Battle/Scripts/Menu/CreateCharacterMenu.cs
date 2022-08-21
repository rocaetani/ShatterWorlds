using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterMenu : MonoBehaviour
{
    public AttributeComponent Constitution;
    public AttributeComponent Technique;
   
    public AttributeComponent Dexterity;
    public AttributeComponent Velocity;
   
    public AttributeComponent Intelligence;
    public AttributeComponent Knowledge;
   
    public AttributeComponent Spirit;
    public AttributeComponent Will;

    public InputField Name;
    public Dropdown Race;
    public Dropdown BasicClass;

    public void Save()
    {
        Character character = CreateCharacter();
        String json = JsonUtility.ToJson(character);
        SendCharacterToServer(character);
    }
    
    public void SendCharacterToServer(Character character)
    {
        APIManager.CharacterAPIHandler.PostCharacter(character,  AfterCharacterCreation);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Loading);
    }

    public void AfterCharacterCreation(String json)
    {
        Character character = JsonUtility.FromJson<Character>(json);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }
    
    private Character CreateCharacter()
    {
        Debug.Log($"Race: {Race.captionText.text}");
        Debug.Log($"Class: {BasicClass.value}");

        return new Character(OutBattleManager.instance.Player,Name.text,Race.captionText.text, BasicClass.value, 1, 0, CreateAttributes());
        
    }


    private Attributes CreateAttributes()
    {
        return new Attributes(
            Constitution.GetValue(),
            Technique.GetValue(),
            Dexterity.GetValue(),
            Velocity.GetValue(),
            Intelligence.GetValue(),
            Knowledge.GetValue(),
            Spirit.GetValue(),
            Will.GetValue());
    }

}