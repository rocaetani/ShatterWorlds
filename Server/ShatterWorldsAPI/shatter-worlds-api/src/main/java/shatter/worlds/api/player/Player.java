package shatter.worlds.api.player;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity(name = "PLAYER")
@Getter
public class Player {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequencePlayerId")
    @SequenceGenerator(name = "SequencePlayerId", sequenceName = "PLAYER_SEQ", allocationSize = 1)
    private Long id;

    private String username;

    private String password;

    public Player(String username, String password) {
        this.username = username;
        this.password = password;
    }
}
