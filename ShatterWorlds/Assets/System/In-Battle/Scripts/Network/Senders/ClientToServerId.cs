using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClientToServerId : ushort
{
    loginInfo = 1,
    chosenCharacters = 2,
    firstTurn = 3,
    endTurn = 4,
    move = 5,
    attack = 6,
    spell = 7

}
