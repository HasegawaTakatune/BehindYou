using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleNest : MonoBehaviour
{

    [SerializeField]
    private Fade fade = default;

    private void Start()
    {
        fade.FadeOut();
    }
}
