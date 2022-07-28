package shatter.worlds.api.character;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.character.classes.prestige.PrestigeClass;
import shatter.worlds.api.player.Player;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity(name = "CHARACTER")
@Getter
public class Character {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequenceCharacterId")
    @SequenceGenerator(name = "SequenceCharacterId", sequenceName = "CHARACTER_SEQ", allocationSize = 1)
    private Long id;

    @ManyToOne
    private Player playerOwner;

    private String name;

    private String race;

    @ManyToOne
    private BasicClass basicClass;

    @ManyToOne
    private PrestigeClass prestigeClass;

    private int level;

    private int experiencePoints;

    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn( name = "attributes_id" )
    private Attributes attributes;

    public Character(Player playerOwner, String name, String race, BasicClass basicClass, PrestigeClass prestigeClass, int level, int experiencePoints, Attributes attributes) {
        this.playerOwner = playerOwner;
        this.name = name;
        this.race = race;
        this.basicClass = basicClass;
        this.prestigeClass = prestigeClass;
        this.level = level;
        this.experiencePoints = experiencePoints;
        this.attributes = attributes;
    }
}
