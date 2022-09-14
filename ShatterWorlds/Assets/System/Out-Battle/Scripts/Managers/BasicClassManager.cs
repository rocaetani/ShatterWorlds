using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicClassManager
{
    private Dictionary<int, BasicClass> BasicClasses;

    public BasicClassManager()
    {
        BasicClasses = new Dictionary<int, BasicClass>();
        //RequestBasicClasses();
        LoadBasicClasses();
    }

    public void LoadBasicClasses()
    {
        APIManager.BasicClassHandler.GetBasicClasses(AfterLoadBasicClassesResponse);
    }

    public void AfterLoadBasicClassesResponse(string json)
    {
        //TODO - Refactor this to be an Helper
        json = "{\"basicClasses\": " + json + "}";

        BasicClassResponse response = JsonUtility.FromJson<BasicClassResponse>(json);
        PopulateBasicClasses(response.basicClasses);
    }

    public void PopulateBasicClasses(List<BasicClass> basicClasses)
    {
        foreach (BasicClass basicClass in basicClasses)
        {
            BasicClasses.Add(basicClass.basicClassId, basicClass);
        }
        Print();
    }

    public BasicClass GetBasicClass(int basicClassId)
    {
        return BasicClasses[basicClassId];
    }

    public List<string> ReturnClassesNames()
    {
        return BasicClasses.Values.Select(BasicClass => BasicClass.name).ToList();
    }

    public void Print()
    {
        foreach (int id in BasicClasses.Keys)
        {
            Debug.Log($"{BasicClasses[id].name}");
        }
    }
}
