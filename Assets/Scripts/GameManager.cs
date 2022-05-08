using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ゲームステータス
    /// </summary>
    public enum GAME_STATE
    {
        TITLE = 0,
        PLAY,
        STOP,
        END,
        CONFIG,
        MAX,
    }

    /// <summary>
    /// ゲームステータス
    /// </summary>
    public static GAME_STATE gameState;

    public const string FIRST_CHAPTER = "HelloScenario";
    /// <summary>
    /// インスタンス
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// チャプター
    /// </summary>
    public static string chapter;

    /// <summary>
    /// シナリオ
    /// </summary>
    public static int scenario;

    /// <summary>
    /// シナリオID
    /// </summary>
    public static int contentId;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
