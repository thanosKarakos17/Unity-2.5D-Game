using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressScene : MonoBehaviour
{
    //public GameObject focusBox;
    public AudioSource src;
    public Animator animator;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions input;
    // Start is called before the first frame update
    void Awake()
    {
        GAMEMANAGER.resetBoss();
        GAMEMANAGER.randomBoss();
        playerInput = new PlayerInput();
        input = playerInput.OnFoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("finish"))
        {
            if(GAMEMANAGER.level == 0) { SceneManager.LoadScene(2); }
            else if (GAMEMANAGER.level == 1) { SceneManager.LoadScene(3); }
            else if (GAMEMANAGER.level == 2) { SceneManager.LoadScene(5); }
        }
        input.OK.performed += ctx => load_next();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private void load_next()
    {
        src.Play();
        animator.Play("black_panel");
    }
}
