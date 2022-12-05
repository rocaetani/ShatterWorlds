using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using RiptideNetworking;
using UnityEngine;

namespace InBattle
{
    public class BattleNetwork
    {

        private BattleManager _battleManager;
        public BattleNetwork(BattleManager battleManager)
        {
            _battleManager = battleManager;

            MessageReceiver.ReceiveSeedAction += ReceiveSeed;
            MessageReceiver.ReceiveCharacterValidAction += ReceiveCharacterIsValid;
            MessageReceiver.ReceiveNextToPlayAction += ReceiveNextToPlay;

            NetworkManager.Singleton.Connect(StartBattle, EndBattle, FailToConnect);
        }



        //HANDLE NETWORK STUFF

        public void StartBattle()
        {
            Player player = SceneTransactional.instance.OutToInTransaction.Player;
            SendLoginInfo(player.playerId, player.username, player.password);
        }

        public void FailToConnect()
        {
            Player player = SceneTransactional.instance.OutToInTransaction.Player;
            SceneTransactional.instance.ChangeToMainMenu(player);
        }

        public void EndBattle()
        {
            _battleManager.EndBattle();
        }

        //SENDERS
        public void SendLoginInfo(int playerId, string username, string password)
        {
            MessageSender.SendLoginInfo(playerId, username, password);
        }

        public void SendChosenCharacters(int playerId, List<int> chosenCharacters)
        {
            MessageSender.SendChosenCharacters(playerId, chosenCharacters);
        }

        public void SendFirstTurn()
        {
            MessageSender.SendFirstTurn();
        }

        public void SendEndTurn(int playerId, int characterId)
        {
            MessageSender.SendEndTurn(playerId, characterId);
        }

        //RECEIVERS
        public void ReceiveSeed(int seed)
        {
            _battleManager.InitBattle(seed);
            _battleManager.SendChosenCharactersToServer();
        }

        public void ReceiveCharacterIsValid(bool isValid)
        {
            if (isValid)
            {
                //ErrorLogger.instance.LogError("Still on TODO", this);
                _battleManager.AfterValidateCharacters();
            }
            else
            {
                ErrorLogger.instance.LogError("Failed to get the character information on server.", this);
            }
        }

        public void ReceiveNextToPlay(int agentId, int agentType)
        {
            _battleManager.ReceiveNextToPlay(agentId, agentType);
        }
    }
}
