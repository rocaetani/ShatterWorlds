using System;
using System.Collections;
using System.Collections.Generic;
using RiptideNetworking;
using UnityEngine;

public class BattleNetwork 
{
    
    public BattleNetwork()
    {
        NetworkManager.Singleton.Connect();
    }


    public void LoginOnServer(String username, String password)
    {
        Message message = Message.Create(MessageSendMode.reliable, (ushort) ClientToServerId.name);
        message.AddString(username);
        message.AddString(password);
        NetworkManager.Singleton.Client.Send(message);
    }
}
