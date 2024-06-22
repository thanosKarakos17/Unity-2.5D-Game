using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendlyNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public WizardSpeech panel;
    private string init_text;
    void Start()
    {
        init_text = panel.speech.text;
    }

    // Update is called once per frame
    void Update()
    {
        if(GAMEMANAGER.playerHealth < GAMEMANAGER.maxHealth && panel != null)
        {
            panel.speech.text = "Your HP is down let me heal you. " + "<i>" + "press <OK>" + "</i>";
            //GAMEMANAGER.restoreHealth();
        }
        else { panel.speech.text = init_text; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall" || other.gameObject.tag == "Player")
        {
            panel.show();
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "FireBall" || other.gameObject.tag == "Player")
        {
            //Debug.Log("UWU");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FireBall" || other.gameObject.tag == "Player")
        {
            //Debug.Log("UWU");
        }
    }
}
        
