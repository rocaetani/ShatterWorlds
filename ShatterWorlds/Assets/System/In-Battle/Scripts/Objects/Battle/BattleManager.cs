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

        public CharacterManager CharacterManager;

        public TurnManager TurnManager;





        private void Awake()
        {
            _battleNetwork = new BattleNetwork(this);
            TurnManager = new TurnManager();
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

        public void AfterValidateCharacters()
        {
            InitCharacters();
            InitTurn();
        }

        private void InitCharacters()
        {
            List<outBattle.Character> characters = SceneTransactional.instance.OutToInTransaction.Characters;
            CharacterManager = new CharacterManager(CreateBucket("Characters List"));
            SpawnCharacters(characters);
        }

        private void InitTurn()
        {
            TurnManager = new TurnManager();
            TurnManager.EndTurnAction += EndTurn;
            _battleNetwork.SendFirstTurn();
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
            Character character = CharacterManager.AddCharacter(characterBase, position);
            _boardManager.PutObjectInSquare(position, character);
        }

        public void ReceiveNextToPlay(int agentId, int agentType)
        {
            Agent nextToPlay = FindAgent(agentId, agentType);

            TurnManager.NextTurnLoop(nextToPlay, null);
        }

        private Agent FindAgent(int agentId, int agentType)
        {
            AgentType type = (AgentType)agentType;
            if (type == AgentType.PlayerAgent)
            {
                return CharacterManager.GetCharacter(agentId);
            }
            else if (type == AgentType.AIAgent)
            {
                //TODO
            }
            else if (type == AgentType.EnemyPlayerAgent)
            {
                //TODO
            }
            return null;
        }

        public void EndTurn(int characterId)
        {
            _battleNetwork.SendEndTurn(_battleData.Player.playerId, characterId);
        }
    }
}
