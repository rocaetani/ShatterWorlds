package shatter.worlds.api.character.classes.basic;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;


import javax.persistence.EntityNotFoundException;
import java.util.List;
import java.util.Optional;

@Service
public class BasicClassService {

    @Autowired
    private BasicClassRepository basicClassRepository;

    public BasicClass find(Long id){
        Optional<BasicClass> basicClass = basicClassRepository.findById(id);
        if(basicClass.isPresent()){
            return basicClass.get();
        }
        throw new EntityNotFoundException("Basic Class " + id +" not found");
    }

    public List<BasicClass> findAll() {
        return basicClassRepository.findAll();
    }
}
