using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions input;
    void Awake()
    {
        playerInput = new PlayerInput();
        input = playerInput.OnFoot;
    }

    // Update is called once per frame
    void Update()
    {
        input.OK.performed += ctx => foo ();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    private void foo()
    {
        SceneManager.LoadScene(0);
        //Application.Quit();
    }
}
