using System;

namespace outBattle
{
    [Serializable]
    public class Character
    {
        public int id;

        public Player player;

        public string name;

        public string race;

        public BasicClass basicClass;

        public int level;

        public int experiencePoints;

        public Attributes attributes;

        public Character(string name, string race, BasicClass basicClass, int level, int experiencePoints,
            Attributes attributes)
        {
            this.name = name;
            this.race = race;
            this.basicClass = basicClass;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }

        public Character(int id, Player player, string name, string race, BasicClass basicClass, int level,
            int experiencePoints, Attributes attributes)
        {
            this.id = id;
            this.player = player;
            this.name = name;
            this.race = race;
            this.basicClass = basicClass;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }


        public Character(Player player, string name, string race, BasicClass basicClass, int level, int experiencePoints,
            Attributes attributes)
        {
            this.player = player;
            this.name = name;
            this.race = race;
            this.basicClass = basicClass;
            this.level = level;
            this.experiencePoints = experiencePoints;
            this.attributes = attributes;
        }
    }
}
