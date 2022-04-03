using UnityEngine;
using UnityEngine.UI;

public class SelecterItem : MonoBehaviour
{
    /// <summary>
    /// 表示するラベル文字
    /// </summary>
    [SerializeField] private string label = default;

    /// <summary>
    /// 表示するラベルオブジェクト
    /// </summary>
    [SerializeField] private Text labelText = default;

    /// <summary>
    /// ドロップダウンオブジェクト
    /// </summary>
    [SerializeField] private Dropdown dropdown = default;

    /// <summary>
    /// 入力値
    /// </summary>
    public int selected = default;

    /// <summary>
    /// 選択イベント
    /// </summary>
    public void onSelectorChanged()
    {
        selected = dropdown.value;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        labelText.text = label;
    }
}
