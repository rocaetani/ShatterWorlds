using System;
using System.Collections;
using System.Collections.Generic;
using System.Network.Scripts;
using RiptideNetworking;
using UnityEngine;

public static class MessageReceiver
{

    /*private static BattleManager _battleManager;

    public static void SignBattleManager(BattleManager battleManager)
    {
        _battleManager = battleManager;
    }
    */

    public static Action<int> ReceiveSeedAction;

    [MessageHandler((ushort)ServerToClientId.seed)]
    public static void ReceiveSeed(Message message)
    {
        GameLogger.instance.Log("ReceiveSeed", typeof(MessageReceiver));
        ReceiveSeedAction?.Invoke(message.GetInt());
    }


    public static Action<bool> ReceiveCharacterValidAction;

    [MessageHandler((ushort)ServerToClientId.charactersValid)]
    public static void ReceiveCharactersValid(Message message)
    {
        GameLogger.instance.Log("ReceiveCharactersValid", typeof(MessageReceiver));
        ReceiveCharacterValidAction?.Invoke(message.GetBool());
    }

    public static Action<int, int> ReceiveNextToPlayAction;

    [MessageHandler((ushort)ServerToClientId.nextToPlay)]
    public static void ReceiveNextToPlay(Message message)
    {
        GameLogger.instance.Log("ReceiveNextToPlay", typeof(MessageReceiver));
        ReceiveNextToPlayAction?.Invoke(message.GetInt(), message.GetInt());
    }

}
