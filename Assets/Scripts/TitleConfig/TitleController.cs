using UnityEngine;

public class TitleController : MonoBehaviour
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
    /// ゲームスタートイベント
    /// </summary>
    public void onStartGame()
    {
        Debug.Log("Game start");
    }

    /// <summary>
    /// ゲームロードイベント
    /// </summary>
    public void onLoadGame()
    {
        Debug.Log("Game load");
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
}
