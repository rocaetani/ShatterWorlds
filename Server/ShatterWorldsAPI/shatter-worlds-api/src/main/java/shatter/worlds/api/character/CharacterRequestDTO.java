package shatter.worlds.api.character;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.attributes.AttributesDTO;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class CharacterRequestDTO {

    private Long id;

    private Long playerOwnerId;

    private String name;

    private String race;

    private Long basicClassId;

    private Long prestigeClassId;

    private int level;

    private int experiencePoints;

    private AttributesDTO attributesDTO;

}
