package shatter.worlds.api.player;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import shatter.worlds.api.character.Character;
import shatter.worlds.api.character.CharacterService;

import java.util.List;

@RestController
@RequestMapping("/player")
public class PlayerController {

    @Autowired
    private PlayerService playerService;

    @Autowired
    private CharacterService characterService;

    @GetMapping(path = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Player> find(@PathVariable Long id){
        return ResponseEntity.ok(playerService.find(id));
    }

    @GetMapping(path = "/characters/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<Character>> findAllCharacters(@PathVariable Long id){
        return ResponseEntity.ok(characterService.findAllCharactersOfPlayer(id));
    }

    @PostMapping(consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Player> create(@RequestBody PlayerRequestDTO playerRequestDTO){
        return ResponseEntity.status(HttpStatus.CREATED).body(playerService.create(playerRequestDTO));
    }

    @PatchMapping(consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Player> update(@RequestBody PlayerRequestDTO playerRequestDTO){

        return ResponseEntity.status(HttpStatus.OK).body(playerService.update(playerRequestDTO));

    }

    @GetMapping(path = "/validate/{username}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Boolean> validateUsername(@PathVariable String username){
        return ResponseEntity.ok(playerService.newPlayerUsernameIsValid(username));
    }

    @DeleteMapping(path = "/{id}")
    public void delete(@PathVariable Long id){
        playerService.delete(id);
    }
}
