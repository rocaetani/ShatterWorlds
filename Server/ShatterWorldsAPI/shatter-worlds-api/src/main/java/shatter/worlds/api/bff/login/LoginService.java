package shatter.worlds.api.bff.login;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import shatter.worlds.api.character.Character;
import shatter.worlds.api.character.CharacterService;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.character.classes.basic.BasicClassService;
import shatter.worlds.api.player.Player;
import shatter.worlds.api.player.PlayerService;

import java.util.List;

@Service
public class LoginService {

    @Autowired
    private PlayerService playerService;

    @Autowired
    private CharacterService characterService;

    @Autowired
    private BasicClassService basicClassService;

    public LoginResponseDTO login(String username,    String password){
        Player player = playerService.find(username, password);
        List<Character> characterList = characterService.findAllCharactersOfPlayer(player.getPlayerId());
        List<BasicClass> basicClasses = basicClassService.findAll();
        return new LoginResponseDTO(player,  characterList, basicClasses);
    }
}
