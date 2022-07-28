package shatter.worlds.api.character;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import shatter.worlds.api.player.Player;

import java.util.List;

@Repository
public interface CharacterRepository extends JpaRepository<Character, Long> {
    List<Character> findAllByPlayerOwner(Player playerOwner);
}
