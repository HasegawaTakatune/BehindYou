using UnityEngine;
using UnityEngine.UI;

public class RadioItem : ConfigBase
{
    /// <summary>
    /// ラジオボタン
    /// </summary>
    [SerializeField] private Button[] radioButtons = default;

    /// <summary>
    /// ラジオボタンイベント
    /// </summary>
    /// <param name="index"></param>
    public void onClickedRadio(int index)
    {
        for (int i = 0; i < radioButtons.Length; i++)
        {
            radioButtons[i].interactable = (i != index);
        }
        inputValue = index;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private new void Start()
    {
        base.Start();
        for (int i = 0; i < radioButtons.Length; i++)
        {
            if (radioButtons[i].interactable == false) inputValue = i;
        }
    }

    /// <summary>
    /// 活性化イベント
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        for (int i = 0; i < radioButtons.Length; i++)
        {
            radioButtons[i].interactable = (i != inputValue);
        }
    }
}
