package shatter.worlds.api.character.classes.prestige;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import shatter.worlds.api.character.classes.basic.BasicClass;

import javax.persistence.EntityNotFoundException;
import java.util.List;
import java.util.Optional;

@Service
public class PrestigeClassService {

    @Autowired
    private PrestigeClassRepository prestigeClassRepository;

    public PrestigeClass find(Long id){
        Optional<PrestigeClass> prestigeClass = prestigeClassRepository.findById(id);
        if(prestigeClass.isPresent()){
            return prestigeClass.get();
        }
        throw new EntityNotFoundException("Basic Class " + id +" not found");
    }

    public List<PrestigeClass> findAll(){
        return prestigeClassRepository.findAll();
    }
}
