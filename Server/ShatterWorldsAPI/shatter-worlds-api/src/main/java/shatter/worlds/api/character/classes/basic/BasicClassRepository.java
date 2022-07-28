package shatter.worlds.api.character.classes.basic;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface BasicClassRepository extends JpaRepository<BasicClass, Long> {
}
