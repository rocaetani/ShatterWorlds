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
        ReceiveSeedAction?.Invoke(message.GetInt());
    }
}
