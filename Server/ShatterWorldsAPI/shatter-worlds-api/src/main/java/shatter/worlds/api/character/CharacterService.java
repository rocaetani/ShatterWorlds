package shatter.worlds.api.character;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import shatter.worlds.api.character.attributes.Attributes;
import shatter.worlds.api.character.attributes.AttributesFactory;
import shatter.worlds.api.character.attributes.AttributesService;
import shatter.worlds.api.character.classes.basic.BasicClassService;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.character.classes.prestige.PrestigeClass;
import shatter.worlds.api.character.classes.prestige.PrestigeClassService;
import shatter.worlds.api.player.Player;
import shatter.worlds.api.player.PlayerService;

import javax.persistence.EntityNotFoundException;
import java.util.List;
import java.util.Optional;

@Service
public class CharacterService {

    @Autowired
    private CharacterRepository characterRepository;

    @Autowired
    private CharacterFactory characterFactory;

    @Autowired
    private PlayerService playerService;

    @Autowired
    private BasicClassService basicClassService;

    @Autowired
    private AttributesService attributesService;

    public Character find(Long id){
        Optional<Character> character = characterRepository.findById(id);
        if(character.isPresent()){
            return character.get();
        }
        throw new EntityNotFoundException("Character " + id +" not found");
    }

    public List<Character> findAllCharactersOfPlayer(Long playerId){
        Player player = playerService.find(playerId);
        return characterRepository.findAllByPlayerOwner(player);
    }

    @Transactional
    public Character create(CharacterRequestDTO characterRequestDTO) {
        BasicClass basicClass = basicClassService.find(characterRequestDTO.getBasicClass().getId());
        Character character = characterFactory.createWithoutIdAndAttributes(characterRequestDTO, basicClass);
        character = characterRepository.save(character);
        attributesService.create(characterRequestDTO.getAttributes(), character);
        return character;
    }


    public Character update(CharacterRequestDTO characterRequestDTO) {
        //TODO deal with Attributes
        if(characterIdExists(characterRequestDTO.getId())){
            BasicClass basicClass = basicClassService.find(characterRequestDTO.getBasicClass().getId());
            Character character = characterFactory.create(characterRequestDTO, basicClass);
            characterRepository.save(character);
            return character;
        }
        else{
            throw new EntityNotFoundException();
        }
    }

    public void delete(Long id) {
        if(characterIdExists(id)){
            characterRepository.deleteById(id);
        }
        else{
            throw new EntityNotFoundException();
        }
    }

    private boolean characterIdExists(Long id){
        return characterRepository.existsById(id);
    }
}
