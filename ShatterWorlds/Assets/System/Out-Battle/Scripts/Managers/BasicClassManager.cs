using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicClassManager
{
    public Dictionary<int, BasicClass> BasicClasses;

    public BasicClassManager()
    {
        BasicClasses = new Dictionary<int, BasicClass>();
        //RequestBasicClasses();
    }


    public void PopulateBasicClasses(List<BasicClass> basicClasses)
    {
        foreach (var basicClass in basicClasses)
        {
            BasicClasses.Add(basicClass.id, basicClass);
        }
    }

    public void Print()
    {
        foreach (int id in BasicClasses.Keys)
        {
            Debug.Log($"{BasicClasses[id].name}");
        }
    }

    public BasicClass GetBasicClass(int basicClassId)
    {
        return BasicClasses[basicClassId];
    }

    public List<string> ReturnClassesNames()
    {
        return BasicClasses.Values.Select(BasicClass => BasicClass.name).ToList();
    }
}
