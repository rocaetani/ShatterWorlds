using System;

namespace outBattle
{
    [Serializable]
    public class Character
    {
        public int characterId;

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

        public Character(int characterId, Player player, string name, string race, BasicClass basicClass, int level,
            int experiencePoints, Attributes attributes)
        {
            this.characterId = characterId;
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
