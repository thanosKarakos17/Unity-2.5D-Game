using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiteBillboard : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] bool freezeXZaxis = true;
    void LateUpdate()
    {
        if (freezeXZaxis)
        {
            float angle = Camera.main.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
