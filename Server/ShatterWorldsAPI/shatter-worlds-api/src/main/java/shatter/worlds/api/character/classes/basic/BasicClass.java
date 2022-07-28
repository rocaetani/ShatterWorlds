package shatter.worlds.api.character.classes.basic;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@AllArgsConstructor
@NoArgsConstructor
@Entity(name = "BASIC_CLASS")
@Getter
public class BasicClass {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "SequenceBasicClassId")
    @SequenceGenerator(name = "SequenceBasicClassId", sequenceName = "BASIC_CLASS_SEQ", allocationSize = 1)

    private Long id;

    private String name;

}