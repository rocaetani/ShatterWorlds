using System;
using InBattle;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    private BattleManager _battleManager;

    private void Awake()
    {
        _battleManager = GetComponent<BattleManager>();
    }

}
