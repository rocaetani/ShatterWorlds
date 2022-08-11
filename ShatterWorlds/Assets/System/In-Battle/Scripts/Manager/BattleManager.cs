using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    public static BattleManager instance;

    public BoardController BoardController;

    private int _battleSeed;

    private System.Random _battleRandom;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Logger singleton already instantiated.");
            Destroy(this);
        }

        instance = this;
    }

    public void SetBattleSeed(int seed)
    {
        if (_battleRandom != null)
        {
            ErrorLogger.instance.LogError("Seed already populated", this);
        }
        else
        {
            _battleSeed = seed;
            _battleRandom = new System.Random(_battleSeed);
        }
    }

    public int GenerateRandInt(int min, int max)
    {
        return _battleRandom.Next(min, max);
    }

    public void InitBoardController()
    {
        BoardController = gameObject.AddComponent<BoardController>();
    }

}
