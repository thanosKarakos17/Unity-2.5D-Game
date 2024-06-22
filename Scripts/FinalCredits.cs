using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public static class finalglb
{
    public static int rectangle = 1;
}

public class FinalCredits : MonoBehaviour
{
    public TextMeshProUGUI textgui1;
    public TextMeshProUGUI textgui2;
    public TextMeshProUGUI textgui3;
    public TextMeshProUGUI textgui4;

    public Animator img1;
    public Animator img2;
    public Animator img3;
    public Animator img4;

    private string text1;
    private string text2;
    private string text3;
    private string text4;
    private float textspeed = 0.15f;
  
    // Start is called before the first frame update
    void Start()
    {

        text1 = textgui1.text;
        textgui1.text = string.Empty;
        text2 = textgui2.text;
        textgui2.text = string.Empty;
        text3 = textgui3.text;
        textgui3.text = string.Empty;
        text4 = textgui4.text;
        textgui4.text = string.Empty;


        StartCoroutine(startText(textgui1, text1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startText(TextMeshProUGUI textgui, string text)
    {
        yield return StartCoroutine(typeline(textgui, text));
        textgui1.text = string.Empty;
        yield return StartCoroutine(typeline(textgui2, text2));
        textgui2.text = string.Empty;
        yield return StartCoroutine(typeline(textgui3, text3));
        textgui3.text = string.Empty;
        yield return StartCoroutine(typeline(textgui4, text4));
        textgui4.text = string.Empty;
        img1.Play("finalmove");
        img2.Play("finalmove");
        img3.Play("finalmove");
        img4.Play("finalmove");
    }

    IEnumerator typeline(TextMeshProUGUI textgui, string text)
    {
        foreach(char c in text.ToCharArray())
        {
            textgui.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
}
