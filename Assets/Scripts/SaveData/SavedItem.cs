using System;
using UnityEngine;

public class SavedItem : MonoBehaviour
{
    /// <summary>
    /// チャプター
    /// </summary>
    [SerializeField] private string chapter = default;

    /// <summary>
    /// シナリオ
    /// </summary>
    [SerializeField] private int scenario = default;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="key">セーブデータの取得キー</param>
    /// <returns>true：成功 false：失敗</returns>
    public bool Init(string key)
    {
        try
        {
            chapter = PlayerPrefs.GetString($"{key}-chapter", null);
            scenario = PlayerPrefs.GetInt($"{key}-scenario", -1);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
        if (chapter == null || scenario == -1) return false;
        return true;
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
        chapter = saveChapter;
        scenario = saveScenario;

        try
        {
            PlayerPrefs.SetString($"{key}-chapter", chapter);
            PlayerPrefs.SetInt($"{key}-scenario", scenario);

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
    /// チャプター名取得（画面表示用）
    /// </summary>
    /// <return>チャプター名</returns>
    public string GetChapter()
    {
        return (chapter == null) ? "- BLANK -" : chapter;
    }

    /// <summary>
    /// シナリオ番号取得（画面表示用）
    /// </summary>
    /// <returns>シナリオ番号</returns>
    public int GetScenario()
    {
        return (scenario == -1) ? 0 : scenario;
    }
}
