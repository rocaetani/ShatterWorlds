package shatter.worlds.api.character.attributes;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import shatter.worlds.api.character.Character;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity(name = "ATTRIBUTES")
@Getter
public class Attributes {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequenceAttributesId")
    @SequenceGenerator(name = "SequenceAttributesId", sequenceName = "ATTRIBUTES_SEQ", allocationSize = 1)
    private Long attributesId;

    private int strength;

    private int technique;

    private int dexterity;

    private int velocity;

    private int intelligence;

    private int knowledge;

    private int spirituality;

    private int will;

    @OneToOne
    @JoinColumn( name = "character_id" )
    private Character character;

    public Attributes(int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will) {
        this.strength = strength;
        this.technique = technique;
        this.dexterity = dexterity;
        this.velocity = velocity;
        this.intelligence = intelligence;
        this.knowledge = knowledge;
        this.spirituality = spirituality;
        this.will = will;
    }

    public Attributes(int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will, Character character) {
        this.strength = strength;
        this.technique = technique;
        this.dexterity = dexterity;
        this.velocity = velocity;
        this.intelligence = intelligence;
        this.knowledge = knowledge;
        this.spirituality = spirituality;
        this.will = will;
        this.character = character;
    }
}
