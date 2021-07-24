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
    /// 名前パネル
    /// </summary>
    [SerializeField]
    private GameObject namePanel = default;

    /// <summary>
    /// メッセージウィンドウ
    /// </summary>
    [SerializeField]
    private Text messageWindow = default;

    /// <summary>
    /// メッセージパネル
    /// </summary>
    [SerializeField]
    private GameObject messagePanel = default;

    /// <summary>
    /// コンテンツインデックス
    /// </summary>
    private int index = 0;

    /// <summary>
    /// 章の保存
    /// </summary>
    private Chapter chapter = default;

    /// <summary>
    /// シナリオの保存
    /// </summary>
    private Scenario scenario = default;

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

        string json = Resources.Load<TextAsset>("Json/HelloScenario").ToString();
        chapter = JsonUtility.FromJson<Chapter>(json);
        scenario = chapter.scenario[0];

        SetContent();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(0 < charQueue.Count) OutputAllChar();
            else
            {
                index++;
                SetContent();
            }
        }
    }

    /// <summary>
    /// コンテンツ設定
    /// </summary>
    private void SetContent()
    {
        messageWindow.text = "";
        nameWindow.text = "";

        Content content = scenario.content[index];

        if (content.IsSetCharacterName())
        {
            nameWindow.text = content.characterName;
            namePanel.SetActive(true);
        }
        else
        {
            namePanel.SetActive(false);
        }

        if (content.IsSetMessage())
        {
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
    private IEnumerator ShowMessage(float wait)
    {
        while (OutputChar()) yield return new WaitForSeconds(wait);
        yield break;
    }

    /// <summary>
    /// 1文字ずつ表示する
    /// </summary>
    private bool OutputChar()
    {
        if (charQueue.Count <= 0) return false;
        messageWindow.text += charQueue.Dequeue();
        return true;
    }

    /// <summary>
    /// 全文表示する
    /// </summary>
    private void OutputAllChar()
    {
        StopCoroutine(ShowMessage(captionSpeed));
        while (OutputChar()) ;
    }
}
