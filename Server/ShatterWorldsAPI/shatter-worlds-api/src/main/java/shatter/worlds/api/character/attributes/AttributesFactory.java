package shatter.worlds.api.character.attributes;

import org.springframework.stereotype.Component;
import shatter.worlds.api.player.Player;
import shatter.worlds.api.player.PlayerRequestDTO;

@Component
public class AttributesFactory {

    public Attributes createWithoutId(AttributesDTO attributesDTO) {
        return new Attributes(
                attributesDTO.getStrength(),
                attributesDTO.getTechnique(),
                attributesDTO.getDexterity(),
                attributesDTO.getVelocity(),
                attributesDTO.getIntelligence(),
                attributesDTO.getKnowledge(),
                attributesDTO.getSpirituality(),
                attributesDTO.getWill());
    }

}
