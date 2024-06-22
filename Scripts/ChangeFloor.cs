using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public Material material1;
    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if(GAMEMANAGER.level == 1) { mr.material = material1; }
        else if(GAMEMANAGER.level == 2) {  mr.material = material2; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
