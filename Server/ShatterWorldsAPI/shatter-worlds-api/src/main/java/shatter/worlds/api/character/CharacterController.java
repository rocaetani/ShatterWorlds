package shatter.worlds.api.character;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;
import java.util.Collections;
import java.util.List;

@RestController
@RequestMapping("/character")
public class CharacterController {
    @Autowired
    private CharacterService characterService;

    @GetMapping(path = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Character> find(@PathVariable Long id){
        return ResponseEntity.ok(characterService.find(id));
    }


    @PostMapping(consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Character> create(@RequestBody CharacterRequestDTO characterRequestDTO){
        return ResponseEntity.status(HttpStatus.CREATED).body(characterService.create(characterRequestDTO));
    }

    @PatchMapping(consumes = MediaType.APPLICATION_JSON_VALUE,
            produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<Character> update(@RequestBody CharacterRequestDTO characterRequestDTO){

        return ResponseEntity.status(HttpStatus.OK).body(characterService.update(characterRequestDTO));

    }

    @DeleteMapping(path = "/{id}")
    public void delete(@PathVariable Long id){
        characterService.delete(id);
    }
}
