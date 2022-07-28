package shatter.worlds.api.character.classes.basic;

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
@RequestMapping("/basicClass")
public class BasicClassController {

    @Autowired
    private BasicClassService basicClassService;

    @GetMapping(path = "/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<BasicClass> find(@PathVariable Long id){
        return ResponseEntity.ok(basicClassService.find(id));
    }

    @GetMapping(path = "/", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<List<BasicClass>> findAll(){
        return ResponseEntity.ok(basicClassService.findAll());
    }

}
