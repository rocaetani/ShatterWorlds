using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterMenu : MenuTemplate
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
        outBattle.Character character = CreateCharacter();
        string json = JsonUtility.ToJson(character);
        SendCharacterToServer(character);
    }

    private void SetBasicClass()
    {
        List<string> classesNames = OutBattleManager.instance.BasicClassManager.ReturnClassesNames();
        BasicClass.options.Clear();
        foreach (string className in classesNames)
        {
            Dropdown.OptionData od = new Dropdown.OptionData
            {
                text = className
            };
            BasicClass.options.Add(od);
        }
    }

    public void SendCharacterToServer(outBattle.Character character)
    {
        APIManager.CharacterAPIHandler.PostCharacter(character, AfterCharacterCreation);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Loading);
    }

    public void AfterCharacterCreation(string json)
    {
        outBattle.Character character = JsonUtility.FromJson<outBattle.Character>(json);
        OutBattleManager.instance.Characters.Add(character);
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }

    private outBattle.Character CreateCharacter()
    {
        Debug.Log($"Race: {Race.captionText.text}");
        Debug.Log($"Class: {BasicClass.value + 1}");

        return new outBattle.Character(OutBattleManager.instance.Player, Name.text, Race.captionText.text, OutBattleManager.instance.BasicClassManager.GetBasicClass(BasicClass.value + 1), 1, 0, CreateAttributes());

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

    public override void InitMenu()
    {
        Debug.Log("Create Character Menu");
        SetBasicClass();
    }

    public void ReturnToMainMenu()
    {
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }
}
