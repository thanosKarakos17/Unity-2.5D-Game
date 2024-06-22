using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBoxPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        if(GAMEMANAGER.level == 1)
        {
            rect.anchoredPosition = new Vector2(13f, 100f);
        }
        else if(GAMEMANAGER.level == 2)
        {
            rect.anchoredPosition = new Vector2(105f, 85f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
