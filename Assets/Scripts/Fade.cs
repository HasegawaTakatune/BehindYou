using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fade : MonoBehaviour
{
    /// <summary>
    /// フェード用のパネル画像
    /// </summary>
    [SerializeField]
    private Image fadePanel = default;

    /// <summary>
    /// ロード中テキスト
    /// </summary>
    [SerializeField]
    private Text nowloadText = default;

    /// <summary>
    /// フェード速度
    /// </summary>
    private float fadeSpeed = 0.01f;

    /// <summary>
    /// テキストの最大長さ
    /// </summary>
    private int maxTextLength = 8;

    /// <summary>
    /// フェードイン
    /// </summary>
    public void FadeIn()
    {
        StartCoroutine(AsyncFadeIn());
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    public void FadeOut()
    {
        StartCoroutine(AsyncFadeOut());
    }

    /// <summary>
    /// ローディング中
    /// </summary>
    public void NowLoading()
    {
        StartCoroutine(AsyncNoLoading());
    }

    /// <summary>
    /// フェードイン（非同期処理）
    /// </summary>
    /// <returns></returns>
    public IEnumerator AsyncFadeIn()
    {
        float alpha = 0;
        Color pnl = Color.black;

        fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
        fadePanel.enabled = true;

        while (alpha < 1)
        {
            yield return null;
            alpha += fadeSpeed;

            fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
        }
        NowLoading();
        yield return new WaitForSeconds(1.0f);
    }

    /// <summary>
    /// フェードアウト（非同期処理）
    /// </summary>
    /// <returns></returns>
    public IEnumerator AsyncFadeOut()
    {
        float alpha = 1;
        Color pnl = Color.black;

        fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
        fadePanel.enabled = true;
        nowloadText.enabled = false;

        while (0 < alpha)
        {
            yield return null;
            alpha -= fadeSpeed;

            fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
        }
        fadePanel.enabled = false;
    }

    /// <summary>
    /// ロード中（非同期処理）
    /// </summary>
    /// <returns></returns>
    private IEnumerator AsyncNoLoading()
    {
        nowloadText.enabled= true;
        nowloadText.text = "読み込み中";

        while (nowloadText.enabled)
        {
            yield return new WaitForSeconds(0.5f);
            nowloadText.text += "．";
            if (maxTextLength < nowloadText.text.Length) nowloadText.text = "読み込み中";
        }
    }
}
