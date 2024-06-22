using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    // Start is called before the first frame update
    Image img;
    private bool mutex;
    private Sprite sevenup;
    void Start()
    {
        img = GetComponent<Image>();
    }

    public void SetImage(Sprite newSprite)
    {
        sevenup = newSprite;
        mutex = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mutex)
        {
            img.sprite = sevenup;
            mutex = false;
        }
    }
}
