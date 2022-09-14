using System;
using System.Collections;
using System.Collections.Generic;
using RiptideNetworking;
using UnityEngine;

public class BattleNetwork
{

    private BattleManager _battleManager;
    public BattleNetwork(BattleManager battleManager)
    {
        _battleManager = battleManager;
        NetworkManager.Singleton.SignBattleManager(_battleManager);
        MessageReceiver.ReceiveSeedAction += ReceiveSeed;

        NetworkManager.Singleton.Connect();
    }

    //SENDERS
    public void LoginOnServer(int id, string username, string password)
    {
        MessageSender.SendLoginInfo(id, username, password);
    }

    public void SendChosenCharacters(int playerId, List<int> chosenCharacters)
    {
        MessageSender.SendChosenCharacters(playerId, chosenCharacters);
    }

    //RECEIVERS

    public void ReceiveSeed(int seed)
    {
        _battleManager.SetBattleSeed(seed);
        _battleManager.InitBoardController();
        _battleManager.SendChosenCharactersToServer();
    }
}
