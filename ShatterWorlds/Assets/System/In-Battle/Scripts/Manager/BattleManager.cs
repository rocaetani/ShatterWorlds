using System;
using System.Collections.Generic;
using System.Linq;
using outBattle;
using UnityEngine;
namespace InBattle
{
    public class BattleManager : MonoBehaviour
    {
        private BattleData _battleData;

        private BattleNetwork _battleNetwork;

        private BoardManager _boardManager;

        private CharacterManager _characterManager;

        private void Start()
        {
            _battleNetwork = new BattleNetwork(this);
        }

        public void InitBattle(int seed)
        {
            _battleData = new BattleData(SceneTransactional.instance.OutToInTransaction.Player, seed);
            InitBoard();
        }

        public void SendChosenCharactersToServer()
        {
            List<outBattle.Character> characters = SceneTransactional.instance.OutToInTransaction.Characters;
            _battleNetwork.SendChosenCharacters(_battleData.Player.playerId, GetCharacterIds(characters));
        }

        public void InitBoard()
        {
            if (_battleData != null)
            {
                _boardManager = new BoardManager(_battleData.GetRandomBoardSize(), CreateBucket("Board"));
            }
        }

        public void InitCharacters()
        {
            List<outBattle.Character> characters = SceneTransactional.instance.OutToInTransaction.Characters;
            _characterManager = new CharacterManager(CreateBucket("Characters List"));
            SpawnCharacters(characters);
        }

        private List<int> GetCharacterIds(List<outBattle.Character> characters)
        {
            return characters.Select((character) => character.characterId).ToList();
        }

        public void EndBattle()
        {
            SceneTransactional.instance.ChangeToMainMenu(_battleData.Player);
        }

        private GameObject CreateBucket(string bucketName)
        {
            GameObject characterBucket = new GameObject();
            characterBucket.transform.parent = gameObject.transform;
            characterBucket.transform.name = bucketName;
            return characterBucket;
        }


        private void SpawnCharacters(List<outBattle.Character> characters)
        {
            Vector2Int position = new Vector2Int(0, 0);
            foreach (outBattle.Character character in characters)
            {
                SpawnCharacter(character, position);
                position += new Vector2Int(1, 0);
            }
        }

        private void SpawnCharacter(outBattle.Character characterBase, Vector2Int position)
        {
            Character character = _characterManager.AddCharacter(characterBase, position);
            _boardManager.PutObjectInSquare(position, character);
        }
    }
}
