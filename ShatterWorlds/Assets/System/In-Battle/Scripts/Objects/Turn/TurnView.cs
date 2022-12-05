using System;
using InBattle;
using UnityEngine;
using UnityEngine.UI;
public class TurnView : MonoBehaviour
{
    public Canvas TurnCanvas;
    public Text CurrentLabel;
    public Button MoveButton;
    public Button AttackButton;
    public Button SpellButton;
    public Button EndTurnButton;

    public Action<Agent> OnEndTurnClicked;

    private Agent _isPlaying;

    public void Awake()
    {
        EndTurnButton.onClick.AddListener(EndTurn);
        TurnCanvas.enabled = false;
    }

    public void EnableTurn(Agent nextToPlay)
    {
        _isPlaying = nextToPlay;
        Character c = (Character)nextToPlay;
        CurrentLabel.text = c.GetCharacterName();
        TurnCanvas.enabled = true;
    }



    private void EndTurn()
    {
        TurnCanvas.enabled = false;
        OnEndTurnClicked?.Invoke(_isPlaying);
    }
}
