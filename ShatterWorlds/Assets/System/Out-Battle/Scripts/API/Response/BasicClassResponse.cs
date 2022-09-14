using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;



[Serializable]
public class BasicClassResponse
{
    public List<BasicClass> basicClasses;

    public BasicClassResponse(List<BasicClass> basicClasses)
    {
        this.basicClasses = basicClasses;
    }
}
