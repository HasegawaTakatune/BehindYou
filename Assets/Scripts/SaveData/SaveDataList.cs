using UnityEngine;

using Configs;

public class SaveDataList : MonoBehaviour
{
    /// <summary>
    /// セーブデータの要素数
    /// </summary>
    const int LENGTH = 8;

    /// <summary>
    /// セーブ制御
    /// </summary>
    [SerializeField] private SavedStatus.CONTROL control = default;

    /// <summary>
    /// セーブデータのプレファブ
    /// </summary>
    [SerializeField] private GameObject prefab = default;

    /// <summary>
    /// セーブデータコンテンツ
    /// </summary>
    [SerializeField] private Transform contents = default;

    /// <summary>
    /// セーブデータがない場合のテキスト表示
    /// </summary>
    [SerializeField] private GameObject NotSaveDataText = default;

    /// <summary>
    /// オブジェクト活性イベント
    /// </summary>
    private void OnEnable()
    {
        GameManager.gameState = GameManager.GAME_STATE.CONFIG;
        foreach (Transform child in contents)
        {
            GameObject.Destroy(child.gameObject);
        }

        bool exists = false;
        for (int i = 0; i < LENGTH; i++)
        {
            GameObject obj = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, contents);
            SavedContent sc = obj.GetComponent<SavedContent>();
            bool result = sc.Init(i.ToString(), control);
            if (control == SavedStatus.CONTROL.LOAD && !result)
            {
                obj.SetActive(false);
            }
            else exists = true;
        }

        NotSaveDataText.SetActive(control == SavedStatus.CONTROL.LOAD && !exists);
    }

    /// <summary>
    /// オブジェクト非活性イベント
    /// </summary>
    private void OnDisable()
    {
        GameManager.gameState = GameManager.GAME_STATE.PLAY;
        Invoke("CallbackDisable", 2.0f);
    }

    /// <summary>
    /// ゲームステートをプレイに更新
    /// </summary>
    private void CallbackDisable()
    {
        GameManager.gameState = GameManager.GAME_STATE.PLAY;
    }

    /// <summary>
    /// ゲームデータロード
    /// </summary>
    public void OnLoad()
    {
        control = SavedStatus.CONTROL.LOAD;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// ゲームデータセーブ
    /// </summary>
    public void OnSave()
    {
        control = SavedStatus.CONTROL.SAVE;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// キャンセル
    /// </summary>
    public void OnCancel()
    {
        gameObject.SetActive(false);
    }
}
