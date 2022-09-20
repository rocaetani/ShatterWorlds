using System;
using System.Collections.Generic;
using System.Linq;
using outBattle;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private BattleData _battleData;

    private BattleNetwork _battleNetwork;

    private CharacterManager _characterManager;

    private void Start()
    {
        _battleNetwork = new BattleNetwork(this);
    }

    public void InitBattle(int seed)
    {
        _battleData = new BattleData(SceneTransactional.instance.OutToInTransaction.Player, seed);
    }

    public void SendChosenCharactersToServer()
    {
        List<Character> characters = SceneTransactional.instance.OutToInTransaction.Characters;
        _battleNetwork.SendChosenCharacters(_battleData.Player.playerId, GetCharacterIds(characters));
    }

    public void InitCharacters()
    {
        List<Character> characters = SceneTransactional.instance.OutToInTransaction.Characters;
        _characterManager = new CharacterManager(characters, new Vector2Int(0, 0), CreateCharacterBucket());
    }

    private List<int> GetCharacterIds(List<Character> characters)
    {
        return characters.Select((character) => character.characterId).ToList();
    }

    public void EndBattle()
    {
        SceneTransactional.instance.ChangeToMainMenu(_battleData.Player);
    }

    private GameObject CreateCharacterBucket()
    {
        GameObject characterBucket = new GameObject();
        characterBucket.transform.parent = gameObject.transform;
        characterBucket.transform.name = "Character Bucket";
        return characterBucket;
    }



}
