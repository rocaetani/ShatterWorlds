using System;

[Serializable]
public class BasicClass
{
    public int id;

    public string name;

    public BasicClass(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
