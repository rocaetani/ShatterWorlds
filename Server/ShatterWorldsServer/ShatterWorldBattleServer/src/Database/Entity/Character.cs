using System;
public class Character
{
    private int characterId;

    private Player playerOwner;

    private String name;

    private String race;

    private BasicClass basicClass;

    private int level;

    private int experiencePoints;

    private Attributes attributes;

    public Character(int characterId, Player playerOwner, string name, string race, BasicClass basicClass, int level, int experiencePoints, Attributes attributes)
    {
        this.characterId = characterId;
        this.playerOwner = playerOwner;
        this.name = name;
        this.race = race;
        this.basicClass = basicClass;
        this.level = level;
        this.experiencePoints = experiencePoints;
        this.attributes = attributes;
    }

    public Character(int characterId, string name, string race, BasicClass basicClass, int level, int experiencePoints, Attributes attributes)
    {
        this.characterId = characterId;
        this.name = name;
        this.race = race;
        this.basicClass = basicClass;
        this.level = level;
        this.experiencePoints = experiencePoints;
        this.attributes = attributes;
    }

}

