using System;
using System.Collections.Generic;
using System.Linq;
using outBattle;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    //public static BattleManager instance;

    public BoardController BoardController;

    private int _battleSeed;

    private System.Random _battleRandom;

    private BattleNetwork _battleNetwork;

    public Player Player;

    public List<Character> Characters;


    private void Start()
    {
        _battleNetwork = new BattleNetwork(this);
        Player = SceneTransactional.instance.OutToInTransaction.Player;
        Characters = SceneTransactional.instance.OutToInTransaction.Characters;
    }

    public void StartBattle(int seed)
    {

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
        BoardController.InitBoard(GenerateRandInt(Macros.MIN_BOARD_SIZE, Macros.MAX_BOARD_SIZE));
    }

    public void SendLoginInfoToServer()
    {
        _battleNetwork.LoginOnServer(Player.playerId, Player.username, Player.password);
    }

    public void SendChosenCharactersToServer()
    {
        _battleNetwork.SendChosenCharacters(Player.playerId, GetCharacterIds(Characters));
    }

    public List<int> GetCharacterIds(List<Character> characters)
    {
        List<int> result = characters.Select((character) => character.characterId).ToList();
        return result;
    }

}
