using System.Collections;
using System.Collections.Generic;
using RiptideNetworking;
using UnityEngine;

public static class MessageSender
{
    public static void SendLoginInfo(int id, string username, string password)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.loginInfo);

        message.AddInt(id);
        message.AddString(username);
        message.AddString(password);

        NetworkManager.Singleton.Client.Send(message);
    }

    public static void SendChosenCharacters(int playerId, List<int> chosenCharacters)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort)ClientToServerId.chosenCharacters);

        message.AddInt(playerId);
        message.AddInts(chosenCharacters.ToArray());

        NetworkManager.Singleton.Client.Send(message);
    }
}
