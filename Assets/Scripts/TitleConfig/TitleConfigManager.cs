using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleConfigManager : MonoBehaviour
{
    /// <summary>
    /// タイトルパネル
    /// </summary>
    [SerializeField] private GameObject titlePanel = default;

    /// <summary>
    /// 設定パネル
    /// </summary>
    [SerializeField] private GameObject configPanel = default;

    /// <summary>
    /// 設定リスト
    /// </summary>
    [SerializeField] ConfigBase[] configs = default;

    /// <summary>
    /// ゲームスタートイベント
    /// </summary>
    public void OnStartGame()
    {
        GameManager.chapter = GameManager.FIRST_CHAPTER;
        GameManager.scenario = 0;
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// ゲームロードイベント
    /// </summary>
    public void OnLoadGame()
    {
        titlePanel.SetActive(false);
    }

    /// <summary>
    /// 設定表示イベント
    /// </summary>
    public void OnConfigOpen()
    {
        configPanel.SetActive(true);
        titlePanel.SetActive(false);
    }

    /// <summary>
    /// 設定とじるイベント
    /// </summary>
    public void OnConfigClose()
    {
        titlePanel.SetActive(true);
        configPanel.SetActive(false);
    }

    /// <summary>
    /// ゲーム終了イベント
    /// </summary>
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// 設定の保存ボタン
    /// </summary>
    public void OnSaveConfig()
    {
        try
        {
            foreach (ConfigBase config in configs)
            {
                PlayerPrefs.SetInt(config.GetKey(), config.GetValue());
            }
            PlayerPrefs.Save();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    /// <summary>
    /// 戻るボタン
    /// </summary>
    public void OnReturn()
    {
        titlePanel.SetActive(true);
        configPanel.SetActive(false);
    }
}
