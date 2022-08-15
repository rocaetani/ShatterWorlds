package shatter.worlds.api.character.attributes;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DuplicateKeyException;
import org.springframework.stereotype.Service;
import org.w3c.dom.Attr;
import shatter.worlds.api.character.Character;
import shatter.worlds.api.player.Player;

@Service
public class AttributesService {

    @Autowired
    private IAttributesRepository attributesRepository;

    @Autowired
    private AttributesFactory attributesFactory;

    public Attributes create(AttributesDTO attributesDTO, Character character){
        Attributes attributes = attributesFactory.createWithoutId(attributesDTO, character);
        attributes = attributesRepository.save(attributes);
        return attributes;
    }
}

