using System;
using System.Collections;
using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.UI;

public class BorderController : MonoBehaviour
{
    [NonSerialized]
    protected Image image;
    public PlayerController player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.trailController.isOverJumper)
        {
            var currentLauncherColor = player.launcherController.currentLauncherColor;
            image.color = new Color(currentLauncherColor.r, currentLauncherColor.g, currentLauncherColor.b, 0f);
            StartCoroutine(AlphaFade(0.2f));
        }
        else
        {
            StartCoroutine(AlphaFade(0.0f));
        }
    }

    private IEnumerator AlphaFade(float alpha)
    {
        float fadeTime = 0.2f;
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeTime)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(image.color.a, alpha, elapsedTime / fadeTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
