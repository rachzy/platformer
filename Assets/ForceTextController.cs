using System;
using TMPro;
using UnityEngine;

public class ForceTextController : MonoBehaviour
{
    public GameObject player;
    public TMP_Text textObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = MathF.Round(player.GetComponent<Rigidbody2D>().inertia).ToString();
    }
}
