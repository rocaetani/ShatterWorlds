package shatter.worlds.api.character.attributes;

import org.springframework.stereotype.Component;
import shatter.worlds.api.character.Character;

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

    public Attributes createWithoutId(AttributesDTO attributesDTO, Character character) {
        return new Attributes(
                attributesDTO.getStrength(),
                attributesDTO.getTechnique(),
                attributesDTO.getDexterity(),
                attributesDTO.getVelocity(),
                attributesDTO.getIntelligence(),
                attributesDTO.getKnowledge(),
                attributesDTO.getSpirituality(),
                attributesDTO.getWill(),
                character);

    }

}
