package shatter.worlds.api.character.attributes;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import shatter.worlds.api.player.Player;

@Repository

public interface IAttributesRepository extends JpaRepository<Attributes, Long> {
}
