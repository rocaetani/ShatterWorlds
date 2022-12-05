using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;

public class StartBattleMenu : MenuTemplate
{
    private GameObject _characterComponent;
    private Dictionary<int, CharacterComponent> CharacterComponents;
    private Vector2 _initialComponentPosition;
    private Vector2 _nextIteration;
    private Vector2 _nextLineIteration;
    private Vector2 _componentPosition;



    public override void InitMenu()
    {
        _characterComponent = Resources.Load<GameObject>("UI/Components/CharacterComponent");
        InitComponentsPositionsConfig();
        InitComponents(OutBattleManager.instance.Characters);

    }

    private void InitComponents(List<Character> characters)
    {
        CharacterComponents = new Dictionary<int, CharacterComponent>();
        int lineCounter = 0;
        foreach (Character character in characters)
        {
            GameObject characterComponentGameObject = Instantiate(
                _characterComponent,
                new Vector3(0, 0, 0),
                Quaternion.identity,
                gameObject.transform);

            CharacterComponent characterComponent = characterComponentGameObject.GetComponent<CharacterComponent>();
            CharacterComponents.Add(character.characterId, characterComponent);
            characterComponent.SetComponent(character, _componentPosition);
            _componentPosition += _nextIteration;
            if (lineCounter == 3)
            {
                lineCounter = -1;
                _initialComponentPosition += _nextLineIteration;
                _componentPosition = _initialComponentPosition;
            }
            lineCounter++;


        }
    }

    private void InitComponentsPositionsConfig()
    {
        _initialComponentPosition = new Vector2(-Screen.width / 2, Screen.height / 2);
        Vector2 componentSize = _characterComponent.GetComponent<RectTransform>().sizeDelta;
        _initialComponentPosition += new Vector2(componentSize.x / 2, -componentSize.y / 2);
        _nextIteration = new Vector2(componentSize.x, 0);
        _nextLineIteration = new Vector2(0, -componentSize.y);
        _componentPosition = _initialComponentPosition;
    }

    public void ReturnToMainMenu()
    {
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }

    public List<Character> GetChosenList()
    {
        List<Character> chosenList = new List<Character>();
        foreach (CharacterComponent characterComponent in CharacterComponents.Values)
        {
            if (characterComponent.IsChosen)
            {
                chosenList.Add(characterComponent.Character);
            }
        }
        return chosenList;
    }

    public void StartBattle()
    {
        List<Character> chosenList = GetChosenList();
        //TODO - Enter Battle Rules
        if (chosenList.Count >= 1)
        {
            SceneTransactional.instance.ChangeToBattleScene(OutBattleManager.instance.Player, GetChosenList());
        }
    }
}
