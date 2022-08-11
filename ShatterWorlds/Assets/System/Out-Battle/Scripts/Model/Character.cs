
using System;

namespace outBattle
{    
    [Serializable]
    public class Character
    {
        public int id;

        public Player playerOwner;

        public String name;

        public String race;

        public int basicClassId;

        public int level;

        public int experiencePoints;

        public Attributes attributes;

        public Character(int id, Player playerOwner, string name, string race, int basicClassId, int level, int experiencePoints, Attributes attributes)
        {
            this.id = id;
            this.playerOwner = playerOwner;
            this.name = name;
            this.race = race;
            this.basicClassId = basicClassId;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }


        public Character(Player playerOwner, string name, string race, int basicClassId, int level, int experiencePoints, Attributes attributes)
        {
            this.playerOwner = playerOwner;
            this.name = name;
            this.race = race;
            this.basicClassId = basicClassId;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }
    }
}


