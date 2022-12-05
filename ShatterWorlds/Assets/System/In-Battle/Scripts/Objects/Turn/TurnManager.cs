using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
namespace InBattle
{
    public class TurnManager
    {
        private TurnView _turnView;
        public Action<int> EndTurnAction;


        public TurnManager()
        {
            _turnView = GameObject.FindWithTag("TurnView").GetComponent<TurnView>();
            _turnView.OnEndTurnClicked += EndCurrentTurn;
        }

        public void EndCurrentTurn(Agent isPlaying)
        {
            Character c = (Character)isPlaying;
            c.MarkCharacterInRed();
            EndTurnAction?.Invoke(c.GetAgentId());
        }

        public void NextTurnLoop(Agent nextToPlay, AIActions aiActions)
        {
            if (nextToPlay.Type == AgentType.PlayerAgent)
            {
                EnablePlayerTurn(nextToPlay);
            }
            else if (nextToPlay.Type == AgentType.AIAgent)
            {
                PlayIATurn(nextToPlay, aiActions);
            }

        }

        private void EnablePlayerTurn(Agent nextToPlay)
        {
            //TODO Really Enable Player
            Character c = (Character)nextToPlay;
            c.MarkCharacterInGreen();
            _turnView.EnableTurn(nextToPlay);

        }

        private void PlayIATurn(Agent nextToPlay, AIActions turnActions)
        {
            //TODO
            //Make a step by step anim of what the server sent for the AI turn
        }

        private void EnableEnemyPlayerTurn(Agent playable)
        {
            //TODO
            //Fix Cam on the other player and expect to receive actions from server
        }

    }
}
