using UnityEngine;
using UnityEngine.UI;

public class SelecterItem : ConfigBase
{
    /// <summary>
    /// ドロップダウンオブジェクト
    /// </summary>
    [SerializeField] private Dropdown dropdown = default;

    /// <summary>
    /// 選択イベント
    /// </summary>
    public void onSelectorChanged()
    {
        inputValue = dropdown.value;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private new void Start()
    {
        base.Start();
    }
}
