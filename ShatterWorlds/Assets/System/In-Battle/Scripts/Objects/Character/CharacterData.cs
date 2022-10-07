using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InBattle
{
    public class CharacterData
    {
        public outBattle.Character Character;

        public Vector2Int CurrentPosition;

        public CharacterData(outBattle.Character character, Vector2Int currentPosition)
        {
            Character = character;
            CurrentPosition = currentPosition;
        }
    }
}
