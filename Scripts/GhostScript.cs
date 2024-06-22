using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostScript : MonoBehaviour
{
    public AudioSource damageSound;
    public AudioSource vanishSound;
    public Animator animator;
    public Animator playerAnim;
    public GameObject booster;
    public EnemySpeech enemy_panel;
    public GameObject obj;
    public bool isBoss;
    public int index;
    //public EnemySpeech enemybox;
    // Start is called before the first frame update
    private Vector3 lastPosition;
    void Start()
    {
        //GAMEMANAGER.randomBoss();
        if (GAMEMANAGER.bossFight[index])
        {
            isBoss = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (obj != null)
        {
            lastPosition = transform.position;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // Replace "StateName" with the name of your animation state
            if (stateInfo.IsName("Destroy") && stateInfo.normalizedTime >= 1.0f)
            {
                // State has finished
                Destroy(obj);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall" && animator != null && other.gameObject.transform.localScale.x >= 0.2)
        {
            animator.Play("dissolve");
            vanishSound.Play();
            if (isBoss == false)
            {
                Instantiate(booster, lastPosition, Quaternion.identity);
            }
            else
            {
                Destroy(obj);
                enemy_panel.myAwake();
            }

            //SceneManager.LoadScene(2);
            //enemybox.changepos();
        }
        else if (other.gameObject.tag == "FireBall" && animator != null && other.gameObject.transform.localScale.x < 0.2)
        {
            //Debug.Log("Player touched me");
            GAMEMANAGER.damagePlayer();
            damageSound.Play();
            playerAnim.Play("damage");
            Debug.Log(GAMEMANAGER.playerHealth);

        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "FireBall" && animator != null) { Debug.Log("UWU"); }
        //else if (other.gameObject.tag == "Player") { Debug.Log("Player touched me"); }
    }

   
}
