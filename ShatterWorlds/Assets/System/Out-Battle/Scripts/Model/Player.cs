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

        public int id;
        public String username;
        public String password;

        public Player(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Player(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }
}

