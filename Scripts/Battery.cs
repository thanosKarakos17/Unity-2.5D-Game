using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private RectTransform rect;
    private float max_size;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        rect = GetComponent<RectTransform>();
        max_size = rect.offsetMax.x;
    }

    // Update is called once per frame
    void Update()
    {
        float newRightValue = max_size * (GAMEMANAGER.playerHealth*1.0f / GAMEMANAGER.maxHealth);
        rect.offsetMax = new Vector2(newRightValue, rect.offsetMax.y);
    }
}
