using System.Collections;
using System.Collections.Generic;
using outBattle;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransactional : MonoBehaviour
{

    public static SceneTransactional instance;

    public OutToInTransaction OutToInTransaction;

    public InToOutTransaction InToOutTransaction;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            Destroy(gameObject);
            return;
        }

        instance = this;
        OutToInTransaction = new OutToInTransaction();
        InToOutTransaction = new InToOutTransaction();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeToBattleScene(Player player, List<outBattle.Character> characters)
    {
        OutToInTransaction.Characters = characters;
        OutToInTransaction.Player = player;
        SceneManager.LoadScene("BattleScene");
    }

    public void ChangeToMainMenu(Player player)
    {
        InToOutTransaction.Player = player;
        InToOutTransaction.comebackMenu = MenuController.MenuItemCategory.Main;
        SceneManager.LoadScene("APITest");
    }



}
