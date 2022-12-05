using System;
using UnityEngine;
using UnityEngine.UI;
public class AgentView : MonoBehaviour
{
    private Transform _parent;

    public Text FakeTurnBar;

    private void Awake()
    {
        _parent = gameObject.GetComponentInParent<Transform>();
        SetupCamera();
    }

    private void Update()
    {
        //transform.position = _parent.position;
    }

    public void UpdateTurnBar(int currentPoints)
    {
        FakeTurnBar.text = "" + currentPoints;

    }

    private void SetupCamera()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.current;
    }
}
