using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace outBattle
{
    public class Player
    {
        //Attributes must be like JAVA
        public String username;
        public String password;

        public Player(String _username, String _password)
        {
            username = _username;
            password = _password;
        }
    }
}

