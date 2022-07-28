package shatter.worlds.api.character.classes.prestige;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import shatter.worlds.api.character.Character;
import shatter.worlds.api.character.CharacterRequestDTO;
import shatter.worlds.api.character.CharacterService;

import java.util.List;

@RestController
@RequestMapping("/prestigeClass")
public class PrestigeClassController {

    @Autowired
    private PrestigeClassService prestigeClassService;

    @GetMapping(path = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<PrestigeClass> find(@PathVariable Long id){
        return ResponseEntity.ok(prestigeClassService.find(id));
    }



    @GetMapping(path = "/", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<PrestigeClass>> findAll(){
        return ResponseEntity.ok(prestigeClassService.findAll());
    }

}
