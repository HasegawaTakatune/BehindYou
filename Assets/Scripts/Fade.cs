using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Image fadePanel = default;

    [SerializeField]
    private Text fadeText = default;

    private float fadeSpeed = 0.05f;

    private int maxTextLength = 8;

    public void FadeIn()
    {
        StartCoroutine(AsyncFadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(AsyncFadeOut());
    }

    public void NowLoading()
    {
        StartCoroutine(AsyncNoLoading());
    }

    private IEnumerator AsyncFadeIn()
    {
        float alpha = 0;
        Color pnl = Color.black;
        // Color txt = Color.white;

        while (alpha < 1)
        {
            yield return null;
            alpha += fadeSpeed;

            fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
            // fadeText.color = new Color(txt.r, txt.g, txt.b, alpha);
        }
        NowLoading();
    }

    private IEnumerator AsyncFadeOut()
    {
        float alpha = 1;
        Color pnl = Color.black;
        // Color txt = Color.white;

        fadeText.enabled = false;

        while (0 < alpha)
        {
            yield return null;
            alpha -= fadeSpeed;

            fadePanel.color = new Color(pnl.r, pnl.g, pnl.b, alpha);
            // fadeText.color = new Color(txt.r, txt.g, txt.b, alpha);
        }
    }

    private IEnumerator AsyncNoLoading()
    {
        fadeText.enabled= true;
        fadeText.text = "読み込み中";

        while (fadeText.enabled)
        {
            yield return new WaitForSeconds(0.5f);
            fadeText.text += "．";
            if (maxTextLength < fadeText.text.Length) fadeText.text = "読み込み中";
        }
    }
}
