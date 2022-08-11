using System;
using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;

public class OutBattleManager : MonoBehaviour
{
    public static OutBattleManager instance;
    public Player player;


    public void Awake()
    {
        if (instance != null)
        {
            ErrorLogger.instance.LogError("OutBattleManager singleton already instantiated.", this);
            Destroy(this);
        }

        instance = this;
    }
}
