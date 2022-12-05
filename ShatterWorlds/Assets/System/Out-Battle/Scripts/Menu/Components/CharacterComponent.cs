using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class CharacterComponent : MonoBehaviour
{
    [HideInInspector]
    public outBattle.Character Character;

    public Text Name;
    public Text BasicClass;
    public Text Race;
    public Text Level;
    public Image CharacterImage;
    public Image Card;

    private RectTransform _rectTransform;

    [HideInInspector]
    public bool IsChosen { get; private set; }

    public void Awake()
    {
        IsChosen = false;
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetComponent(outBattle.Character character, Vector2 position)
    {
        Character = character;
        Name.text = character.name;
        BasicClass.text = character.basicClass.name;
        Race.text = character.race;
        Level.text = character.level.ToString();
        _rectTransform.anchoredPosition = position;

    }

    public void OnClick()
    {

        if (!IsChosen)
        {
            Highlight();
            IsChosen = true;
        }
        else
        {
            Unhighlight();
            IsChosen = false;
        }
    }

    private void Highlight()
    {
        Card.color = Color.green;
    }
    private void Unhighlight()
    {
        Card.color = Color.white;
    }

}
