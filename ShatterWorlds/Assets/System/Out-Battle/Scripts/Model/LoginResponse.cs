using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;


[Serializable]
public class LoginResponse
{
    public Player player;

    public List<Character> characters;

    public LoginResponse(Player player, List<Character> characters)
    {
        this.player = player;
        this.characters = characters;
    }
}
