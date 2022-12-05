using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;


[Serializable]
public class LoginResponse
{
    public Player player;

    public List<outBattle.Character> characters;

    public List<BasicClass> basicClasses;

    public LoginResponse(Player player, List<outBattle.Character> characters, List<BasicClass> basicClasses)
    {
        this.player = player;
        this.characters = characters;
        this.basicClasses = basicClasses;
    }
}
