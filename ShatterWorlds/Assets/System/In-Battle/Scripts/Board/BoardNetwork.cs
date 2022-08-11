using System.Collections;
using System.Collections.Generic;
using System.Network.Scripts;
using RiptideNetworking;
using UnityEngine;

public static class BoardNetwork
{
    public static BoardController BoardController; 
    
    [MessageHandler((ushort)ServerToClientId.seed)]
    public static void ReceiveSeed(Message message)
    {
        BattleManager.instance.SetBattleSeed(message.GetInt());
        BoardController.InitBoard(BattleManager.instance.GenerateRandInt(Macros.MIN_BOARD_SIZE,Macros.MAX_BOARD_SIZE));
    }
}
