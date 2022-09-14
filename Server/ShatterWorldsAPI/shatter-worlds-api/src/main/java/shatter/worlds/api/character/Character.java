package shatter.worlds.api.character;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.character.classes.prestige.PrestigeClass;
import shatter.worlds.api.player.Player;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity(name = "CHARACTER")
@Getter
@Setter
public class Character {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequenceCharacterId")
    @SequenceGenerator(name = "SequenceCharacterId", sequenceName = "CHARACTER_SEQ", allocationSize = 1)
    private Long characterId;

    @ManyToOne
    @JoinColumn( name = "player_owner_id" )
    private Player playerOwner;

    private String name;

    private String race;

    @ManyToOne
    @JoinColumn( name = "basic_class_id" )
    private BasicClass basicClass;

    private int level;

    private int experiencePoints;


    public Character(Player playerOwner, String name, String race, BasicClass basicClass,  int level, int experiencePoints) {
        this.playerOwner = playerOwner;
        this.name = name;
        this.race = race;
        this.basicClass = basicClass;
        this.level = level;
        this.experiencePoints = experiencePoints;
    }
}
