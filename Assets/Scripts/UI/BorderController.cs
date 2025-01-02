using System;
using System.Collections;
using Platformer.Mechanics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BorderController : MonoBehaviour
{
    [NonSerialized]
    protected Image image;
    [NonSerialized]
    protected UIGradient UIGradient;
    public PlayerController player;
    public float fadeDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
        UIGradient = GetComponent<UIGradient>();
    }

    void Update()
    {
        if (player.IsGrounded() && player.trailController.isOverJumper)
        {
            EnableBorder(player.launcherController.currentLauncherColor);
        }
        else
        {
            DisableBorder();
        }
    }

    public void EnableBorder(Color color)
    {
        var mainColor1 = new Color(color.r, color.g, color.b, 0.5f);
        var mainColor2 = new Color(color.r, color.g, color.b, 0f);
        UIGradient.m_color1 = mainColor1;
        UIGradient.m_color2 = mainColor2;
        image.enabled = true;
    }

    public void DisableBorder()
    {
        image.enabled = false;
    }
}
