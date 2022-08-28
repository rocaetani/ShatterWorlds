package shatter.worlds.api.bff.login;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import shatter.worlds.api.character.classes.basic.BasicClass;
import shatter.worlds.api.player.Player;
import shatter.worlds.api.character.Character;
import java.util.List;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class LoginResponseDTO {

    private Player player;
    private List<Character> characters;
    private List<BasicClass> basicClasses;
}
