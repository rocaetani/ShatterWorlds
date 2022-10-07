using System.Collections.Generic;
using System.Linq;
using InBattle;
using UnityEngine;
public class CharacterManager
{
    private Dictionary<int, Character> _characters;
    private GameObject _characterBucket;

    public CharacterManager(GameObject characterBucket)
    {
        _characters = new Dictionary<int, Character>();
        _characterBucket = characterBucket;
    }

    public Character AddCharacter(outBattle.Character outCharacter, Vector2Int initPosition)
    {
        Character character = CharacterFactory.SpawnCharacter(outCharacter, initPosition, _characterBucket);
        _characters.Add(outCharacter.characterId, character);
        return character;
    }

}
