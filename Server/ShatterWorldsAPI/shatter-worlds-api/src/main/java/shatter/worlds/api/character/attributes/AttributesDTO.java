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

    private int Strength;

    private int Technique;

    private int Dexterity;

    private int Velocity;

    private int Intelligence;

    private int Knowledge;

    private int Spirituality;

    private int Will;
}
