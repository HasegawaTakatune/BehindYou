using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMssage : MonoBehaviour
{
    /// <summary>
    /// 名前ウィンドウ
    /// </summary>
    [SerializeField]
    private Text nameWindow = default;

    /// <summary>
    /// メッセージウィンドウ
    /// </summary>
    [SerializeField]
    private Text messageWindow = default;

    private int index = 0;
    private Senario senario = default;

    /// <summary>
    /// 文字表示速度
    /// </summary>
    [SerializeField]
    private float captionSpeed = 0.2f;

    /// <summary>
    /// 文字をキュー保存
    /// </summary>
    private Queue<char> charQueue;

    void Start()
    {

        string json = Resources.Load<TextAsset>("Json/HelloSenario").ToString();
        senario = JsonUtility.FromJson<Senario>(json);
        
        messageWindow.text = "";
        nameWindow.text = "";

        // Content content = senario.content[0];

        // nameWindow.text = content.characterName;

        SetContent();

        // string jsonMessage = content.message;
        // charQueue = SeparateString(jsonMessage);

        // // 文字表示のテスト
        // StartCoroutine(ShowMessage(captionSpeed));
    }

    void Update()
    {
        
    }

    private void SetContent()
    {
        Content content = senario.content[index];

        if(!string.IsNullOrEmpty(content.characterName)){
            nameWindow.text = content.characterName;
        }

        if(!string.IsNullOrEmpty(content.message)){
            charQueue = SeparateString(content.message);

            // 文字表示のテスト
            StartCoroutine(ShowMessage(captionSpeed));
        }
    }

    /// <summary>
    /// 文字列をキューにして返す
    /// </summary>
    /// <param name="msg">文字列</param>
    /// <returns>文字列のキュー</returns>
    private Queue<char> SeparateString(string msg)
    {
        char[] chars = msg.ToCharArray();
        Queue<char> respQue = new Queue<char>();

        // 一つずつキューに加える
        foreach (char c in chars) respQue.Enqueue(c);
        return respQue;
    }

    /// <summary>
    /// メッセージ表示
    /// </summary>
    /// <param name="wait">待機時間</param>
    /// <returns>遅延</returns>
    private IEnumerator ShowMessage(float wait){
        while(OutputChar())yield return new WaitForSeconds(wait);
        yield break;
    }

    /// <summary>
    /// 1文字ずつ表示する
    /// </summary>
    private bool OutputChar(){
        if(charQueue.Count <= 0)return false;
        messageWindow.text += charQueue.Dequeue();
        return true;
    }
}
