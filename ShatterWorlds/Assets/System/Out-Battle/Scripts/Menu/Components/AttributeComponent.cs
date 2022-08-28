using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class AttributeComponent : MonoBehaviour
{

    public Text Counter;

    private int _counter;

    private void Awake()
    {
        _counter = 0;
    }

    public void Add()
    {
        _counter += 1;
        Counter.text = (_counter + "").PadLeft(3, '0');
        
    }

    public void Subtract()
    {
        _counter -= 1;
        Counter.text = (_counter + "").PadLeft(3, '0');
    }

    public int GetValue()
    {
        return _counter;
    }

    

}
