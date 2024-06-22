using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Guidance : MonoBehaviour
{
    public TMP_Text displayText;
    private SpriteRenderer spriteRenderer;
    public string text;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = "select moves with <UP/DOWN>. Press <OK> to continue";
    }

    void Update()
    {
        displayText.text = text;
    }
}
