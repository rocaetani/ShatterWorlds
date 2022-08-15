package shatter.worlds.api.bff.login;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import shatter.worlds.api.player.Player;
import shatter.worlds.api.player.PlayerService;

@RestController
@RequestMapping("/login")
public class LoginController {

    @Autowired
    private LoginService loginService;


    @GetMapping(path = "", produces = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<LoginResponseDTO> find(@RequestParam(name = "username") String username, @RequestParam(name = "password") String password){
        return ResponseEntity.ok(loginService.login(username, password));
    }


}
