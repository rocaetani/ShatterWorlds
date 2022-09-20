using System.Collections.Generic;
using System.Linq;
using InBattle;
using UnityEngine;
public class CharacterManager
{
    private Dictionary<int, Character> _characters;

    public CharacterManager(List<outBattle.Character> outCharacters, Vector2Int initPosition, GameObject characterBucket)
    {
        mapCharacterList(outCharacters, initPosition, characterBucket);
    }

    private void mapCharacterList(List<outBattle.Character> outCharacters, Vector2Int initPosition, GameObject characterBucket)
    {
        _characters = new Dictionary<int, Character>();
        foreach (outBattle.Character outCharacter in outCharacters)
        {
            Character character = CharacterFactory.SpawnCharacter(outCharacter, initPosition, characterBucket);
            _characters.Add(outCharacter.characterId, character);
        }
    }

}
