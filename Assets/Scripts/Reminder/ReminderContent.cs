using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReminderContent : MonoBehaviour
{
    [SerializeField] private Text date = default;
    [SerializeField] private Text message = default;
    private ReminderDetail detail = default;

    private string year = "";
    private string month = "";
    private string day = "";
    private string week = "";

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

    public void ShowDetail()
    {
        detail.Open(year + " / " + month + " / " + day + " (" + week + ")", message.text);
    }
}
