using UnityEngine;
using UnityEngine.UI;

public class RadioItem : MonoBehaviour
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
    /// ラジオボタン
    /// </summary>
    [SerializeField] private Button[] radioButtons = default;

    /// <summary>
    /// 入力値
    /// </summary>
    public int clicked = default;

    /// <summary>
    /// ラジオボタンイベント
    /// </summary>
    /// <param name="index"></param>
    public void onClickedRadio(int index)
    {
        for (int i = 0; i < radioButtons.Length; i++)
            radioButtons[i].interactable = (i != index);

        clicked = index;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        labelText.text = label;

        for (int i = 0; i < radioButtons.Length; i++)
            if (radioButtons[i].interactable == false) clicked = i;


    }
}
