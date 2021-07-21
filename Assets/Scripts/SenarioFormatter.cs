using System.Collections.Generic;

[System.Serializable]
public class Senario
{
    public string name;
    public Content[] content;
}

[System.Serializable]
public class Content
{
    public int id;
    public string characterName;
    public string message;
    public Choices[] choices;
    public string background;
    public Character character;
    public string BGM;
    public string SE;
    public string scenario;
    public string scene;
}

[System.Serializable]
public class Choices
{
    public string name;
    public string scenario;
    public int parameter;
}

[System.Serializable]
public class Character
{
    public string image;
    public string position;
    public string rotate;
    public string size;
    public string color;
    public string animation;
}

