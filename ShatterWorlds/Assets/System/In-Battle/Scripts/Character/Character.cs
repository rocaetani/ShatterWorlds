using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InBattle
{
    public class Character
    {
        private CharacterData _characterData;
        private CharacterView _characterView;
        public Character(CharacterData characterData, CharacterView characterView)
        {
            _characterData = characterData;
            _characterView = characterView;
        }
    }
}
