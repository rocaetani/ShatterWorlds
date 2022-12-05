using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InBattle
{
    public class Character : Agent, Attachable
    {
        private CharacterData _characterData;
        private CharacterView _characterView;
        //public TurnObject CharacterTurn { get; private set; }
        public Character(CharacterData characterData, CharacterView characterView)
            : base(characterView.gameObject, characterData.Character.attributes.velocity, AgentType.PlayerAgent)
        {
            _characterData = characterData;
            _characterView = characterView;
        }

        public void MarkCharacterInRed()
        {
            _characterView.MarkRed();
        }

        public void MarkCharacterInGreen()
        {
            _characterView.MarkGreen();
        }

        public string GetCharacterName()
        {
            return _characterData.Character.name;
        }


        public override int GetAgentId()
        {
            return _characterData.Character.characterId;
        }
    }
}
