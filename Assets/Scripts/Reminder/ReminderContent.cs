using UnityEngine;
using UnityEngine.UI;

public class ReminderContent : MonoBehaviour
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
    /// 詳細
    /// </summary>
    private ReminderDetail detail = default;

    /// <summary>
    /// 年
    /// </summary>
    private string year = "";

    /// <summary>
    /// 月
    /// </summary>
    private string month = "";

    /// <summary>
    /// 日
    /// </summary>
    private string day = "";

    /// <summary>
    /// 曜日
    /// </summary>
    private string week = "";

    /// <summary>
    /// リマインダーの表示内容を設定していく
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="week"></param>
    /// <param name="message"></param>
    /// <param name="detail"></param>
    public void SetContents(string year, string month, string day, string week, string message, ReminderDetail detail)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.week = week;

        this.date.text = day + " (" + week + ")";
        this.message.text = message;
        this.detail = detail;
    }

    /// <summary>
    /// 詳細の設定
    /// </summary>
    public void ShowDetail()
    {
        detail.Open(year + " / " + month + " / " + day + " (" + week + ")", message.text);
    }
}
