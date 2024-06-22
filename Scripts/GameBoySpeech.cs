using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class GameBoySpeech : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource backgroundMusic;
    public AudioSource oksound;
    GameObject panel;
    public TMP_Text speech;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions input;
    private Animator animator;
    public Dialogue dialogue;
    private Queue<DialogueLine> lines;
    void Start()
    {
        panel = GetComponent<GameObject>();
        if (GAMEMANAGER.level == 0)
        {
            speech.text = "Welcome to " + "<b><i>" + "Paper Dungeon" + "</i></b>" + "<i>" + " press <OK>" + "</i>";
        }
        
        
    }

    void Awake()
    {
        lines = new Queue<DialogueLine>();
        animator = GetComponent<Animator>();
        playerInput = new PlayerInput();
        input = playerInput.OnFoot;

        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        // Assign the method to be called when the space key is pressed
        //animator.Play("dialogue_in");
        Time.timeScale = 0f;
        input.OK.performed += ctx => next_line();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.Play("dialogue_out");
        //input.OK.performed += ctx => hide();
    }

    private void hide()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
            backgroundMusic = null;
        }
        animator.Play("dialogue_out");
    }

    private void next_line()
    {
        if(oksound != null) { oksound.Play(); }
        if (lines.Count > 0)
        {
            DialogueLine currentLine = lines.Dequeue();
            speech.text = currentLine.line;
        }
        else
        {
            oksound = null;
            Time.timeScale = 1f;
            hide();
            return;
        }
    }

}
