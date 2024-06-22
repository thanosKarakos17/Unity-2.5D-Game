using System.Collections;
using TMPro;
using UnityEngine;

public class Commenting : MonoBehaviour
{
    public TMP_Text displayText;
    private SpriteRenderer spriteRenderer;
    public bool write = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        displayText.text = glb.text;
    }
}
