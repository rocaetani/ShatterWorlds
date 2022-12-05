using System.Collections;
using System.Collections.Generic;
using RiptideNetworking;
using UnityEngine;

public static class MessageSender
{
    public static void SendLoginInfo(int playerId, string username, string password)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.loginInfo);

        message.AddInt(playerId);
        message.AddString(username);
        message.AddString(password);

        NetworkManager.Singleton.Client.Send(message);

        GameLogger.instance.Log("SendLoginInfo", typeof(MessageSender));
    }

    public static void SendChosenCharacters(int playerId, List<int> chosenCharacters)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.chosenCharacters);

        message.AddInt(playerId);
        message.AddInts(chosenCharacters.ToArray());

        NetworkManager.Singleton.Client.Send(message);
        GameLogger.instance.Log("SendChosenCharacters", typeof(MessageSender));
    }

    public static void SendEndTurn(int playerId, int characterId)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.endTurn);

        message.AddInt(playerId);

        message.AddInt(characterId);

        NetworkManager.Singleton.Client.Send(message);
        GameLogger.instance.Log("SendEndTurn", typeof(MessageSender));

    }

    public static void SendFirstTurn()
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.firstTurn);

        NetworkManager.Singleton.Client.Send(message);
        GameLogger.instance.Log("SendFirstTurn", typeof(MessageSender));

    }
}
