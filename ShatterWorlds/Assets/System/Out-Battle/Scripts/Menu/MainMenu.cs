using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartBattle()
    {
        SceneTransactional.instance.ChangeToBattleScene(OutBattleManager.instance.Player, OutBattleManager.instance.Characters);
    }
}
