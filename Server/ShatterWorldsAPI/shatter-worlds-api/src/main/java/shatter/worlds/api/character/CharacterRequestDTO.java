package shatter.worlds.api.character;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.attributes.AttributesDTO;
import shatter.worlds.api.player.Player;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class CharacterRequestDTO {

    private Long id;

    private Player player;

    private String name;

    private String race;

    private Long basicClassId;

    private int level;

    private int experiencePoints;

    private AttributesDTO attributes;

}
