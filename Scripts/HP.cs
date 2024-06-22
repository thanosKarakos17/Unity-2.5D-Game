using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HP : MonoBehaviour
{
    Animator animator;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //bool idle = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        if(count != 0)
        {
            animator.Play("heal");
            count = 0;
        }
    }
}
