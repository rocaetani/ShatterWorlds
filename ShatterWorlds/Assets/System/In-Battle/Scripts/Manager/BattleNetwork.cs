using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using RiptideNetworking;
using UnityEngine;

public class BattleNetwork
{

    private BattleManager _battleManager;
    public BattleNetwork(BattleManager battleManager)
    {
        _battleManager = battleManager;

        MessageReceiver.ReceiveSeedAction += ReceiveSeed;
        MessageReceiver.ReceiveCharacterValidAction += ReceiveCharacterIsValid;

        NetworkManager.Singleton.Connect(StartBattle, EndBattle, FailToConnect);
    }

    //HANDLE NETWORK STUFF

    public void StartBattle()
    {
        Player player = SceneTransactional.instance.OutToInTransaction.Player;
        LoginOnServer(player.playerId, player.username, player.password);
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
    public void LoginOnServer(int playerId, string username, string password)
    {
        MessageSender.SendLoginInfo(playerId, username, password);
    }

    public void SendChosenCharacters(int playerId, List<int> chosenCharacters)
    {
        MessageSender.SendChosenCharacters(playerId, chosenCharacters);
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
            _battleManager.InitCharacters();

        }
        else
        {
            ErrorLogger.instance.LogError("Failed to get the character information on server.", this);
        }
    }



}
