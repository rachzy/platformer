using System;
using Platformer.Mechanics;
using UnityEngine;

public class BorderAnimation : MonoBehaviour
{
    [NonSerialized]
    protected RectTransform rect;
    public PlayerController player;
    public float duration;
    protected bool isScaled = false;
    protected bool currentlyInAnimation = false;
    protected Vector3 defaultScale = new(1.16f, 1.16f, 1.16f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localScale = defaultScale;
    }

    void Update()
    {
        if (player.IsGrounded() && player.trailController.isOverJumper && !isScaled)
        {
            FadeScale(new Vector3(1, 1, 1));
        }
        else if (isScaled)
        {
            FadeScale(defaultScale);
        }
    }

    private void FadeScale(Vector3 scale)
    {
        if (currentlyInAnimation) return;
        currentlyInAnimation = true;

        LeanTween.scale(rect, scale, duration).setOnComplete(() =>
        {
            currentlyInAnimation = false;
            isScaled = !isScaled;
        });
    }
}
