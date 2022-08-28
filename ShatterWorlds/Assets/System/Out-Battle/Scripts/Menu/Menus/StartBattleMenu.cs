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
            CharacterComponents.Add(character.id, characterComponent);
            characterComponent.SetComponent(character, _initialComponentPosition);
            _initialComponentPosition += _nextIteration;
            if (lineCounter == 3)
            {
                lineCounter = 0;
                _initialComponentPosition += _nextLineIteration;
            }
            lineCounter++;

        }
    }

    private void InitComponentsPositionsConfig()
    {
        _initialComponentPosition = new Vector2(-Screen.width/2,Screen.height/2);
        Vector2 componentSize = _characterComponent.GetComponent<RectTransform>().sizeDelta;
        _initialComponentPosition += new Vector2(componentSize.x / 2, -componentSize.y/2);
        _nextIteration = new Vector2(componentSize.x, 0);
        _nextLineIteration = new Vector2(-4*componentSize.x, -componentSize.y);
    }

    public void ReturnToMainMenu()
    {
        MenuController.instance.ChangeMenu(MenuController.MenuItemCategory.Main);
    }
}
