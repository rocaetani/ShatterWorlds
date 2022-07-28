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
    private Long id;

    private int Strength;

    private int Technique;

    private int Dexterity;

    private int Velocity;

    private int Intelligence;

    private int Knowledge;

    private int Spirituality;

    private int Will;

    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn( name = "character_id" )
    private Character character;

    public Attributes(int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will) {
        Strength = strength;
        Technique = technique;
        Dexterity = dexterity;
        Velocity = velocity;
        Intelligence = intelligence;
        Knowledge = knowledge;
        Spirituality = spirituality;
        Will = will;
    }
}
