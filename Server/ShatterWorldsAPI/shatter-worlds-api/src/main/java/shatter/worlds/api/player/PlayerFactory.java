package shatter.worlds.api.player;

import org.springframework.stereotype.Component;

import java.util.List;
@Component
public class PlayerFactory {

    public Player createWithoutId(PlayerRequestDTO playerRequestDTO) {
        return new Player(
                playerRequestDTO.getUsername(),
                playerRequestDTO.getPassword());
    }

    public Player create(PlayerRequestDTO playerRequestDTO){
        return new Player(
                //playerRequestDTO.getId(),
                1L,
                playerRequestDTO.getUsername(),
                playerRequestDTO.getPassword());
    }
}
