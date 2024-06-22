using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class WizardSpeech : MonoBehaviour
{
    public AudioSource healSound;
    public AudioSource oksound;
    public TMP_Text speech;
    public Animator playerAnim;
    private Animator animator;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions input;
    private bool isshown = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        input = playerInput.OnFoot;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.OK.performed += ctx => hide();
    }

    public void show()
    {
        animator.Play("wizard_box_in");
        isshown = true;
    }

    public void hide()
    {
        if (isshown)
        {
            if (GAMEMANAGER.playerHealth < GAMEMANAGER.maxHealth) { 
                GAMEMANAGER.restoreHealth();
                //Debug.Log(GAMEMANAGER.playerHealth);
                healSound.Play();
                playerAnim.Play("heal");
            }
                oksound.Play();
                animator.Play("wizard_box_out");
            isshown = false;
        }
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }
}
