using System;

[Serializable]
public class BasicClass
{
    public int basicClassId;

    public string name;

    public BasicClass(int basicClassId, string name)
    {
        this.basicClassId = basicClassId;
        this.name = name;
    }
}
