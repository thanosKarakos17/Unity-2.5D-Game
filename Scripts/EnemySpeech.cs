using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpeech : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource oksound;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions input;
    private int sceneToLoad;
    public Animator animator;
    private bool run = false;
    // Start is called before the first frame update

    void Start()
    {
        
    }
    public void myAwake()
    {
        backgroundMusic.Stop();
        Transform pos = GetComponent<Transform>();
        Vector3 newpos = new Vector3();
        newpos.y = -253.5978f;
        newpos.x = -549.566f;
        newpos.z = 88.45f;
        pos.localPosition = newpos;
        int lvl = GAMEMANAGER.level;
        if(lvl == 0) { 
            sceneToLoad = 1; 
            GAMEMANAGER.level = 1;
        }
        else if(lvl == 1)
        {
            sceneToLoad = 4;
            GAMEMANAGER.level = 2;
        }
        else if (lvl == 2)
        {
            sceneToLoad = 6;
            GAMEMANAGER.level = 3;
        }
        glb.reset();
        playerInput = new PlayerInput();
        input = playerInput.OnFoot;
        input.Enable();
        run = true;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (run && animator.GetCurrentAnimatorStateInfo(0).IsName("finish"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        if (run && playerInput != null)
        {
            input.OK.performed += ctx => loadnext();
        }
    }

    void OnEnable()
    {
        //input.Enable();
    }

    void OnDisable()
    {
        //input.Disable();
    }

    private void loadnext()
    {
        Time.timeScale = 1f;
        glb.reset();
        if (animator != null)
        {
            oksound.Play();
            animator.Play("black_panel");
        }
    }

    public void changepos()
    {
        Transform pos = GetComponent<Transform>();
        Vector3 newpos = pos.position;
        newpos.y = -253.5978f;
        pos.position = newpos;
    }
}
