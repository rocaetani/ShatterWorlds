package shatter.worlds.api.character.attributes;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import org.springframework.beans.factory.annotation.Autowired;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class AttributesDTO {

    private int strength;

    private int technique;

    private int dexterity;

    private int velocity;

    private int intelligence;

    private int knowledge;

    private int spirituality;

    private int Will;
}
