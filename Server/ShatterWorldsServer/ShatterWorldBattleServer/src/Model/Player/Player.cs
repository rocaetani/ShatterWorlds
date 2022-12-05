using System;
public class Player
{
    //Attributes must be like JAVA

        public int playerId;
        public String username;
        public String password;

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

