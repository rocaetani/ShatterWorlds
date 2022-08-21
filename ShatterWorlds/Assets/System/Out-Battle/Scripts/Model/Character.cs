
using System;
using UnityEngine.Serialization;

namespace outBattle
{    
    [Serializable]
    public class Character
    {
        public int id;

        public Player player;

        public String name;

        public String race;

        public int basicClassId;

        public int level;

        public int experiencePoints;

        public Attributes attributes;

        public Character(string name, string race, int basicClassId, int level, int experiencePoints, Attributes attributes)
        {
            this.id = id;
            this.player = player;
            this.name = name;
            this.race = race;
            this.basicClassId = basicClassId;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }
        
        public Character(int id, Player player, string name, string race, int basicClassId, int level, int experiencePoints, Attributes attributes)
        {
            this.id = id;
            this.player = player;
            this.name = name;
            this.race = race;
            this.basicClassId = basicClassId;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }


        public Character(Player player, string name, string race, int basicClassId, int level, int experiencePoints, Attributes attributes)
        {
            this.player = player;
            this.name = name;
            this.race = race;
            this.basicClassId = basicClassId;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }
    }
}


