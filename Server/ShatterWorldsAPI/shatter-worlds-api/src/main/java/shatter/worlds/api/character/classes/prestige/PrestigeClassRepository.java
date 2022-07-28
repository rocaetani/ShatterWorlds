package shatter.worlds.api.character.classes.prestige;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import shatter.worlds.api.character.classes.basic.BasicClass;

@Repository
public interface PrestigeClassRepository extends JpaRepository<PrestigeClass, Long> {
}
