using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace outBattle
{
    [Serializable]
    public class Player
    {
        //Attributes must be like JAVA

        public int playerId;
        public string username;
        public string password;

        public Player(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Player(int playerId, string username, string password)
        {
            this.playerId = playerId;
            this.username = username;
            this.password = password;
        }
    }
}
