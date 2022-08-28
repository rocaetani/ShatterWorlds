using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.UI;

public class CharacterComponent : MonoBehaviour
{
    public Text Name;
    public Text BasicClass;
    public Text Race;
    public Text Level;
    public Image CharacterImage;

    private RectTransform _rectTransform;

    public void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetComponent(Character character, Vector2 position)
    {
        Name.text = character.name;
        BasicClass.text = character.basicClass.name;
        Race.text = character.race;
        Level.text = character.level.ToString();
        _rectTransform.anchoredPosition = position;

    }

    public void OnClick()
    {
        
    }

    public void Highlight()
    {
        
    }

}
