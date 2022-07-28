package shatter.worlds.api.character.classes.prestige;

import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@NoArgsConstructor
@Entity(name = "PRESTIGE_CLASS")
@Getter
public class PrestigeClass {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequencePrestigeClassId")
    @SequenceGenerator(name = "SequencePrestigeClassId", sequenceName = "PRESTIGE_CLASS_SEQ", allocationSize = 1)
    private Long id;

    private String name;

}