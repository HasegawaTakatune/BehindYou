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
    public Character[] characteres;
    public string BGM;
    public string SE;
    public string scenario;
    public string scene;

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
    public bool IsSetCharacter() { return (characteres != null) ? characteres.Length != 0 : false; }
    public bool IsSetBGM() { return !string.IsNullOrEmpty(BGM); }
    public bool IsSetSE() { return !string.IsNullOrEmpty(SE); }
    public bool IsSetScenario() { return !string.IsNullOrEmpty(scenario); }
    public bool IsSetScene() { return !string.IsNullOrEmpty(scene); }
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
    public string delete;

    // メンバ関数
    public bool IsSetCharacter() { return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(image); }
    public bool IsSetPosition(){return !string.IsNullOrEmpty(position);}
    public bool IsSetRotate(){return !string.IsNullOrEmpty(rotate);}
    public bool IsSetSize(){return !string.IsNullOrEmpty(size);}
    public bool IsSetColor(){return !string.IsNullOrEmpty(color);}
    public bool IsSetAnimation(){return false;}
    public bool IsDelete(){ 
        bool result;
        bool.TryParse(delete, out result);
        if(result) return bool.Parse(delete); 
        return false; 
    }
}

[System.Serializable]
public class GameAudio
{
    public string name;
    public string audio;
    public string play;
    public string pause;
    public string unpause;
    public string pitch;
}