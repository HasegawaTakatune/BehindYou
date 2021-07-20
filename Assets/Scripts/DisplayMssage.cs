using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMssage : MonoBehaviour
{
    /// <summary>
    /// メッセージウィンドウ
    /// </summary>
    [SerializeField]
    private Text messageWindow = default;

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
        messageWindow.text = "";

        string jsonMessage = "ハロー　RerykA";
        charQueue = SeparateString(jsonMessage);

        // 文字表示のテスト
        StartCoroutine(ShowMessage(captionSpeed));
    }

    void Update()
    {

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
    /// 1文字ずつ表示する
    /// </summary>
    private bool OutputChar(){
        if(charQueue.Count <= 0)return false;
        messageWindow.text += charQueue.Dequeue();
        return true;
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


}
