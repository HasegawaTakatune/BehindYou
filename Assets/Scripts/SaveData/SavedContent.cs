using System;
using UnityEngine;
using UnityEngine.UI;

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
    /// 初期化
    /// </summary>
    /// <param name="key">セーブデータの取得キー</param>
    /// <returns>true：成功 false：失敗</returns>
    public bool Init(string key, SavedStatus.CONTROL ctrl)
    {
        string chapter, savedAt;
        int scenario;

        control = ctrl;
        try
        {
            chapter = PlayerPrefs.GetString($"{key}-chapter", null);
            scenario = PlayerPrefs.GetInt($"{key}-scenario", -1);
            savedAt = PlayerPrefs.GetString($"{key}-saved-at", null);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }

        InitSavedContent(chapter, scenario, savedAt);
        if (chapter == null || scenario == -1) return false;

        return true;
    }

    /// <summary>
    /// セーブした進行状況を表示する
    /// </summary>
    /// <param name="chapter">チャプター</param>
    /// <param name="scenario">シナリオ</param>
    /// <param name="savedAt">セーブ日付</param>
    private bool InitSavedContent(string chapter, int scenario, string savedAt)
    {
        if (chapter == null || scenario == -1 || savedAt == null)
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
    /// <param name="key">セーブデータのキー</param>
    /// <param name="saveChapter">現在のチャプター</param>
    /// <param name="saveScenario">現在のシナリオ</param>
    /// <returns>true：成功 false：失敗</returns>
    public bool SaveGame(string key, string saveChapter, int saveScenario)
    {
        if (String.IsNullOrEmpty(saveChapter)) return false;

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
            PlayerPrefs.SetString($"{key}-chapter", saveChapter);
            PlayerPrefs.SetInt($"{key}-scenario", saveScenario);
            PlayerPrefs.SetString($"{key}-saved-at", savedAt);

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
    public void OnClickSaveData()
    {
        switch (control)
        {
            case SavedStatus.CONTROL.LOAD:

                break;

            case SavedStatus.CONTROL.SAVE:

                break;

            default: break;
        }
    }
}
