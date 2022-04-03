using UnityEngine;
using UnityEngine.UI;

public class ReminderDetail : MonoBehaviour
{
    /// <summary>
    /// 日付
    /// </summary>
    [SerializeField] private Text date = default;

    /// <summary>
    /// メッセージ
    /// </summary>
    [SerializeField] private Text message = default;

    /// <summary>
    /// 詳細を表示
    /// </summary>
    /// <param name="date"></param>
    /// <param name="message"></param>
    public void Open(string date, string message)
    {
        this.date.text = date;
        this.message.text = message;
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 詳細をとじる
    /// </summary>
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
