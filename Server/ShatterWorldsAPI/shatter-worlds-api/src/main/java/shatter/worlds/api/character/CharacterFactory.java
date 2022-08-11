package shatter.worlds.api.character;

import org.springframework.stereotype.Component;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.attributes.AttributesDTO;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.character.classes.prestige.PrestigeClass;
import shatter.worlds.api.player.Player;

@Component
public class CharacterFactory {


    public Character createWithoutId(CharacterRequestDTO characterRequestDTO, BasicClass basicClass,  Attributes attributes) {
        return new Character(
                characterRequestDTO.getPlayer(),
                characterRequestDTO.getName(),
                characterRequestDTO.getRace(),
                basicClass,
                characterRequestDTO.getLevel(),
                characterRequestDTO.getExperiencePoints(),
                attributes);
    }
    public Character createWithoutId(CharacterRequestDTO characterRequestDTO, Player player, BasicClass basicClass,  Attributes attributes) {
        return new Character(
                player,
                characterRequestDTO.getName(),
                characterRequestDTO.getRace(),
                basicClass,
                characterRequestDTO.getLevel(),
                characterRequestDTO.getExperiencePoints(),
                attributes);
    }

    public Character create(CharacterRequestDTO characterRequestDTO, BasicClass basicClass,  Attributes attributes){
        return new Character(
                characterRequestDTO.getId(),
                characterRequestDTO.getPlayer(),
                characterRequestDTO.getName(),
                characterRequestDTO.getRace(),
                basicClass,
                characterRequestDTO.getLevel(),
                characterRequestDTO.getExperiencePoints(),
                attributes);
    }
}
