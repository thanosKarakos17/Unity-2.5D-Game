using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public AudioSource healSound;
    public HP hpanimator;
    public GameObject myprefab;
    private int counter = 0;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("boost");
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(animator != null && myprefab != null && (other.gameObject.tag == "FireBall" || other.gameObject.tag == "Player"))
        {
            counter++;
            if (counter == 2)
            {
                healSound.Play();
                hpanimator.count++;
                GAMEMANAGER.restoreHealth();
                Destroy(myprefab);
                //animator.enabled = false;
            }
        }
        
    }

}
