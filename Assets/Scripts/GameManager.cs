using UnityEngine;

public class GameManager : MonoBehaviour
{
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
