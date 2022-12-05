public class Attributes
{
    public int attributeId;

    public int technique;
    
    public int constitution;

    public int dexterity;

    public int speed;

    public int intelligence;

    public int knowledge;

    public int spirituality;

    public int will;

    public Attributes(int attributeId, int constitution, int technique, int dexterity, int speed, int intelligence, int knowledge, int spirituality, int will)
    {
        this.attributeId = attributeId;
        this.constitution = constitution;
        this.technique = technique;
        this.dexterity = dexterity;
        this.speed = speed;
        this.intelligence = intelligence;
        this.knowledge = knowledge;
        this.spirituality = spirituality;
        this.will = will;
    }
}

