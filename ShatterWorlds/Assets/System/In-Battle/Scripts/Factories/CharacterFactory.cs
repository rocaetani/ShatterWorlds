using InBattle;
using UnityEngine;
public class CharacterFactory
{
    public static Character SpawnCharacter(outBattle.Character character, Vector2Int position, GameObject parent)
    {
        CharacterData characterData = SpawnCharacterData(character, position);

        CharacterView characterView = SpawnCharacterGameObject(position, parent);

        return new Character(characterData, characterView);
    }

    private static CharacterView SpawnCharacterGameObject(Vector2Int position, GameObject parent)
    {
        GameObject characterPrefab = Resources.Load<GameObject>("InBattle/Prefabs/Character");
        GameObject characterSpawned = Object.Instantiate(characterPrefab, new Vector3(position.x + 0.5f, 1, position.y + 0.5f), Quaternion.identity, parent.transform);
        CharacterView characterView = characterSpawned.GetComponent<CharacterView>();
        return characterView;
    }

    private static CharacterData SpawnCharacterData(outBattle.Character character, Vector2Int position)
    {
        return new CharacterData(character, position);
    }
}
