using System;
using System.Collections.Generic;

[System.Serializable]
public class Chapter
{
    // メンバ変数
    public string title;

    public Scenario[] scenario;

    public int FindScenario2Index(string name)
    {
        for (int i = 0; i < scenario.Length; i++)
            if (string.Equals(name, scenario[i].name)) return i;

        return -1;
    }
}

[System.Serializable]
public class Scenario
{
    // メンバ変数
    private int length = -1;
    public string name;
    public Content[] content;

    // メンバ関数
    public int ContentLength()
    {
        if (length != -1) return length;

        length = 0;
        if (content != null)
        {
            Type type = content.GetType();
            length = (type.IsArray) ? content.Length : 0;
        }
        return length;
    }
}

[System.Serializable]
public class Content
{
    // メンバ変数
    public int id;
    public string characterName;
    public string message;
    public Choices[] choices;
    public string background;
    public Character[] characters;
    public Audio BGM;
    public Audio[] SE;
    public string scenario;
    public string nextScene;

    // メンバ関数
    public bool IsSetCharacterName() { return !string.IsNullOrEmpty(characterName); }
    public bool IsSetMessage() { return !string.IsNullOrEmpty(message); }
    public bool IsSetChoices()
    {
        if (choices != null)
        {
            Type type = choices.GetType();
            return type.IsArray;
        }
        return false;
    }
    public bool IsSetBackground() { return !string.IsNullOrEmpty(background); }
    public bool IsSetCharacter() { return (characters != null) ? characters.Length != 0 : false; }
    public bool IsSetBGM() { if (BGM != null) return BGM.IsSetAudio(); return false; }
    public bool IsSetSE() { return (SE != null) ? SE.Length != 0 : false; }
    public bool IsSetScenario() { return !string.IsNullOrEmpty(scenario); }
    public bool IsSetNextScene() { return !string.IsNullOrEmpty(nextScene); }
}

[System.Serializable]
public class Choices
{
    // メンバ変数
    public string name;
    public string scenario;
    public int parameter;

    // メンバ関数
    public bool IsSetChoices() { return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(scenario); }
}

[System.Serializable]
public class Character
{
    // メンバ変数
    public string name;
    public string image;
    public string position;
    public string rotate;
    public string size;
    public string color;
    public string animation;
    public bool delete;

    // メンバ関数
    public bool IsSetCharacter() { return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(image); }
    public bool IsSetPosition() { return !string.IsNullOrEmpty(position); }
    public bool IsSetRotate() { return !string.IsNullOrEmpty(rotate); }
    public bool IsSetSize() { return !string.IsNullOrEmpty(size); }
    public bool IsSetColor() { return !string.IsNullOrEmpty(color); }
    public bool IsSetAnimation() { return false; }
    public bool IsDelete()
    {
        return delete;
    }
}

[System.Serializable]
public class Audio
{
    public string name;
    public string audio;
    public bool play;
    public bool pause;
    public bool unpause;
    public float pitch;
    public bool delete;

    public bool IsSetAudio() { return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(audio); }
}