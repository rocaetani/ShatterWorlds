package shatter.worlds.api.player;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DuplicateKeyException;
import org.springframework.stereotype.Service;
import shatter.worlds.api.character.Character;
import shatter.worlds.api.character.CharacterFactory;
import shatter.worlds.api.character.CharacterService;

import javax.persistence.EntityNotFoundException;
import java.util.List;
import java.util.Optional;

@Service
public class PlayerService {

    @Autowired
    private PlayerRepository playerRepository;
    @Autowired
    private PlayerFactory playerFactory;



    public Player find(String username, String password){
        Optional<Player> player = playerRepository.findByUsernameAndPassword(username, password);
        if(player.isPresent()){
            return player.get();
        }
        throw new EntityNotFoundException("Player " + username +" not found");
    }


    public Player find(Long id){
        Optional<Player> player = playerRepository.findById(id);
        if(player.isPresent()){
            return player.get();
        }
        throw new EntityNotFoundException("Player " + id +" not found");
    }

    public Player create(PlayerRequestDTO playerRequestDTO) {
        if(playerUsernameExists(playerRequestDTO.getUsername())){
            throw new DuplicateKeyException("Player username already taken");
        }
        Player player = playerFactory.createWithoutId(playerRequestDTO);
        player = playerRepository.save(player);
        return player;
    }

    public Player update(PlayerRequestDTO playerRequestDTO) {
        if(playerIdExists(1L
                //playerRequestDTO.getId()
        )){
            Player player = playerFactory.create(playerRequestDTO);
            playerRepository.save(player);
            return player;
        }
        else{
            throw new EntityNotFoundException();
        }
    }

    public void delete(Long id) {
        if(playerIdExists(id)){
            playerRepository.deleteById(id);
        }
        else{
            throw new EntityNotFoundException();
        }
    }

    private boolean playerUsernameExists(String username){

        return playerRepository.existsByUsername(username);
    }

    private boolean playerIdExists(Long id){
        return playerRepository.existsById(id);
    }

    public boolean newPlayerUsernameIsValid(String username){

        return !playerUsernameExists(username);
    }
}
