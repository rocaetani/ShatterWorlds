package shatter.worlds.api.player;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface PlayerRepository extends JpaRepository<Player, Long> {

    Optional<Player> findByUsernameAndPassword(String username, String password);
    boolean existsByUsername(String username);
}
