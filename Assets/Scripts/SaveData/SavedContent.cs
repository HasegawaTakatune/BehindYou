using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Configs;

public class SavedContent : MonoBehaviour
{
    /// <summary>
    /// クリック時の制御
    /// </summary>
    private SavedStatus.CONTROL control = default;

    /// <summary>
    /// チャプター表示
    /// </summary>
    [SerializeField] private Text chapterText = default;

    /// <summary>
    /// セーブした日付表示
    /// </summary>
    [SerializeField] private Text savedAtText = default;

    /// <summary>
    /// チャプター
    /// </summary>
    private string chapter = null;

    /// <summary>
    /// シナリオ
    /// </summary>
    private int scenario = -1;

    /// <summary>
    /// コンテンツID
    /// </summary>
    private int contentId = -1;

    /// <summary>
    /// 一覧の要素番号
    /// </summary>
    private string index = "";


    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="idx">セーブデータの取得キー</param>
    /// <returns>true：成功 false：失敗</returns>
    public bool Init(string idx, SavedStatus.CONTROL ctrl)
    {
        string savedAt;
        control = ctrl;
        index = idx;
        try
        {
            chapter = PlayerPrefs.GetString($"{index}-chapter", null);
            scenario = PlayerPrefs.GetInt($"{index}-scenario", -1);
            contentId = PlayerPrefs.GetInt($"{index}-content-id", -1);
            savedAt = PlayerPrefs.GetString($"{index}-saved-at", null);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }

        InitSavedContent(savedAt);
        if (chapter == null || scenario == -1 || contentId == -1) return false;

        return true;
    }

    /// <summary>
    /// セーブした進行状況を表示する
    /// </summary>
    /// <param name="savedAt">セーブ日付</param>
    private bool InitSavedContent(string savedAt)
    {
        if (chapter == null || scenario == -1 || contentId == -1 || savedAt == null)
        {
            chapterText.text = "- BLANK -";
            savedAtText.text = "プレイ時間：000:000:000";
            return false;
        }
        else
        {
            chapterText.text = chapter + " - " + scenario.ToString();
            savedAtText.text = "プレイ時間：" + savedAt;
            return true;
        }
    }

    /// <summary>
    /// ゲーム進行のセーブ
    /// </summary>
    /// <returns>true：成功 false：失敗</returns>
    public bool SaveGame()
    {
        if (String.IsNullOrEmpty(chapter)) return false;

        string savedAt = "";
        try
        {
            DateTime dt = DateTime.Now;
            savedAt = dt.ToString();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }

        try
        {
            PlayerPrefs.SetString($"{index}-chapter", chapter);
            PlayerPrefs.SetInt($"{index}-scenario", scenario);
            PlayerPrefs.SetInt($"{index}-content-id", contentId);
            PlayerPrefs.SetString($"{index}-saved-at", savedAt);

            PlayerPrefs.Save();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
        return true;
    }

    /// <summary>
    /// コンテントクリックイベント
    /// </summary>
    public void OnSaveData()
    {
        switch (control)
        {
            case SavedStatus.CONTROL.LOAD:
                GameManager.chapter = chapter;
                GameManager.scenario = scenario;
                GameManager.contentId = contentId;
                SceneManager.LoadScene("SampleScene");
                break;

            case SavedStatus.CONTROL.SAVE:
                chapter = GameManager.chapter;
                scenario = GameManager.scenario;
                contentId = GameManager.contentId;
                SaveGame();
                break;

            default: break;
        }
    }
}
