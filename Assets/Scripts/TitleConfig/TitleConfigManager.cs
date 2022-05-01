using System;
using UnityEngine;
using UnityEngine.SceneManagement;

using Configs;

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
    public void onStartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// ゲームロードイベント
    /// </summary>
    public void onLoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    /// <summary>
    /// 設定表示イベント
    /// </summary>
    public void onConfigOpen()
    {
        configPanel.SetActive(true);
        titlePanel.SetActive(false);
    }

    /// <summary>
    /// 設定とじるイベント
    /// </summary>
    public void onConfigClose()
    {
        titlePanel.SetActive(true);
        configPanel.SetActive(false);
    }

    /// <summary>
    /// ゲーム終了イベント
    /// </summary>
    public void onExitGame()
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
    public void onClickSaveConfig()
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
}