using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveSection : MonoBehaviour
{
    public bool active = false;
    private SpriteRenderer spriteRenderer;
    private Moveinput input;
    private Moveinput.OnCLickActions onclick;
    private Player player;
    public bool attack_phase = true;
    public TMP_Text displayText;
    public MoveData selectedMove;
    public MoveData defenseMove;
    public bool waitForOk = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        input = new Moveinput();
        onclick = input.onCLick;
        onclick.Enable();
        player = glb.player0;
        attack_phase = true;
        selectedMove = player.moves[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForOk) { displayText.text = " "; }
        else { 
            displayText.text = displayMoves();
            selectMove();
        }
    }

    private string displayMoves()
    {
        string s = "";
        foreach (MoveData move in player.moves)
        {
            string ms;
            if (attack_phase)
            {
                if (move.Equals(selectedMove))
                {
                    ms = "<i><b>" + move.name + " " + move.size + "</b></i>";
                }
                else
                {
                    ms = move.name + " " + move.size;
                    if (move.type.Equals("Defense")) { ms = "<s>" + ms + "</s>"; }
                }
            }
            else 
            {
                ms = move.name + " " + move.size;
                if (!(move.type.Equals("Defense"))) { ms = "<s>" + ms + "</s>"; defenseMove = null; }
                else {
                    if (active)
                    {
                        ms = "<b>" + ms + "</b>";
                        defenseMove = move;
                    } else
                    {
                        ms = "<s>" + ms + "</s>";
                        defenseMove = null;
                    }
                }
            }
            s += ms + "\n";
        }
        return s;
    }

    private void selectMove()
    {
        float n = onclick.Move.ReadValue <float>();
        if (attack_phase)
        {
            if (n == 1)
            {
                selectedMove = player.moves[0];
            }
            else if (n == -1) { selectedMove = player.moves[1]; }
        } else
        {
            if (n == 1) { active = true; }
            else if(n == -1) { active = false; }
        }

        string msg = " ";
        if(attack_phase) { 
            msg = player.name + " used " + selectedMove.name;
            glb.selectedMove = selectedMove;
        }
        else {
            if (defenseMove != null) { msg = player.name + " used " + defenseMove.name + " and avoided the attack"; }
            else { msg = ""; } 
        }
        onclick.Ok.performed += ctx => notify(msg); 

    }

    private void notify(string msg)
    {
        glb.next = true;
        glb.playerText = msg;
    }
}
