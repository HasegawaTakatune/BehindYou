using UnityEngine;
using UnityEngine.UI;
using System;

public class Reminder : MonoBehaviour
{

    [SerializeField] private Transform content = default;
    [SerializeField] private GameObject prefab = default;
    [SerializeField] private ReminderDetail detail;
    [SerializeField] private Text date;
    [SerializeField] private String[] messages = { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii", "jjj", "kkk" };

    void Start()
    {
        DateTime dt = DateTime.Now;

        date.text = dt.Year.ToString() + " / " + dt.Month.ToString();

        for (int i = 0; i < messages.Length; i++)
        {
            string dd = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString();
            GameObject obj = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity, content);
            ReminderContent rc = obj.GetComponent<ReminderContent>();
            rc.SetContents(dt.Year.ToString(), dt.Month.ToString(), dt.Day.ToString(), GetDate2Week(dt), messages[i], detail);
            dt.AddDays(1);
        }
    }

    private string GetDate2Week(DateTime date)
    {
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Sunday: return "日";
            case DayOfWeek.Monday: return "月";
            case DayOfWeek.Tuesday: return "火";
            case DayOfWeek.Wednesday: return "水";
            case DayOfWeek.Thursday: return "木";
            case DayOfWeek.Friday: return "金";
            case DayOfWeek.Saturday: return "土";
            default: return "";
        }
    }
}
