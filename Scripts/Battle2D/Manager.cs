using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class glb
{
    public static int level = GAMEMANAGER.level - 1;
    public static bool next = false;
    public static string text;
    public static string playerText;
    public static MoveData selectedMove;
    public static Player player0 = new Player("saiki");
    private static string enemy_file = (level == 1) ? "flash" : "mario";
    public static Player player1 = new Player(enemy_file);

    public static void reset()
    {
        level = GAMEMANAGER.level - 1;
        next = false;
        text = "";
        playerText = "";
        //selectedMove = null;
        player0 = new Player("saiki");
        enemy_file = (level == 1) ? "flash" : "mario";
        player1 = new Player(enemy_file);
}
}
public class Manager : MonoBehaviour
{
    public MoveSection movesection;
    public Commenting commenting;
    public Guidance guide;
    public PlayerHealth phealth0;
    public PlayerHealth phealth1;
    public List<Sprite> sprites;
    public ImageChanger profil0;
    public ImageChanger profil1;
    public ImageChanger photo0;
    public ImageChanger photo1;
    public List<Sprite> photos;

    private Player player0, player1;
    private GamePlay gamePlay;
    private List<MoveData> attacks;
    private int state = 0;
    private int playerTurn;
    private MoveData opponentMove;
    private bool mutex = true;
    private bool defend;
    private int round = 1;
    private int shieldNPC = 5;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        mutex = true;
        round = 1;
        shieldNPC = 5;
        player0 = glb.player0;
        player0.health = GAMEMANAGER.playerHealth;
        player1 = glb.player1;

        profil0.SetImage(sprites[0]);
        profil1.SetImage(sprites[glb.level]);
        photo0.SetImage(photos[0]);
        photo1.SetImage(photos[glb.level]);


        attacks = new List<MoveData>();
        attacks.Add(player1.moves[0]);
        attacks.Add(player1.moves[1]);
        phealth0.maxHealth = player0.health;
        phealth1.maxHealth = player1.health;
        gamePlay = new GamePlay(player0, player1);
        string title = player0.name + " VS " + player1.name;
        glb.text = title;
        foo();
    }

    // Update is called once per frame
    void Update()
    {
        foo();
    }
    void foo()
    {
        switch (state)
        {
            case 0:select_move(); break;
            case 1:process_move(); break;
            case 2:process_move(); break;
            case 3:ending_round(); break;
            case 4:game_over(); break;
            case 5:changeScene(); break;
            default: break; 
        }
  
    }

    private void select_move()
    {
        glb.text = player0.name + " VS " + player1.name + "<b>" +" Round " + round + "</b>"; 
        guide.text = "select moves with <UP/DOWN>. Press <OK> to continue";
        movesection.attack_phase = true;
        if(glb.next)
        {
            //mutex = false;
            guide.text = " ";
            int m = UnityEngine.Random.Range(0, attacks.Count);
            opponentMove = attacks[m];
            int turn = gamePlay.check_move_turn(glb.selectedMove, attacks[m]);
            if(turn == 0) { glb.text = glb.playerText; }
            else if(turn == 1) { glb.text = player1.name + " used " + attacks[m].name; }
            movesection.attack_phase=false;
            glb.next = false;
            playerTurn = turn;
            state = 1;
            //mutex = false;
        }
    }

    private void process_move()
    {
        if(playerTurn == 0)
        {
      
            if (mutex == true)
            {
                defend = false;
                glb.text = player0.name + " used " + glb.selectedMove.name;
                guide.text = " ";
                foreach (MoveData m in player1.moves)
                {
                    if (m.type == "Defense")
                    {
                        int shield = UnityEngine.Random.Range(0, 2);
                        if (shieldNPC < 1) { shield = 0; }
                        if (shield == 1)
                        {
                            shieldNPC--;
                            //Debug.Log(shieldNPC);
                            glb.text = player1.name + " used " + "<b>" + m.name + "</b>" + " and avoided the attack";
                            defend = true;
                            //Debug.Log(m.size);
                        }
                        break;
                    }
                }
            }
            guide.text = "Press <OK> to continue";
            movesection.waitForOk = true;
            mutex = false;
            if (glb.next == true)
            {
                movesection.waitForOk = false;
                if (defend == false)
                {
                    gamePlay.damage(glb.selectedMove, player1);
                    phealth0.health = player0.health;
                    phealth1.health = player1.health;
                }
                //gamePlay.use_shield(player1);
   
                playerTurn = 1 - playerTurn;
                state++;
                glb.next = false;
                mutex = true;
            }
        }
        else if(playerTurn == 1)
        {
            glb.text = player1.name + " used " + opponentMove.name;
            guide.text = "select/unselect defense with <UP/DOWN>. Press <OK> to confirm";
            if(glb.next)
            {
                guide.text = " ";
                if (glb.playerText.Length > 1) { 
                    glb.text = glb.playerText;
                    gamePlay.use_shield(player0);
                }
                else {
                    gamePlay.damage(opponentMove, player0);
                    phealth0.health = player0.health;
                    phealth1.health = player1.health;
                }
                glb.next = false;
                playerTurn = 1 - playerTurn;
                state ++;
            }
        }

    }

    private void ending_round()
    {
        gamePlay.check_moves(glb.selectedMove, opponentMove);
        state=4;
        round++;
    }

    private bool game_over()
    {
        bool result = gamePlay.game_over();
        if (result == false) 
        {
            state = 0;
            return false;
        }
        else
        {
            state = 5;
        }
        return true;
    }

    private void changeScene()
    {
        GAMEMANAGER.resetBoss();
        Player winner = gamePlay.winner;
        glb.text = "<b>" + " Winner: " + "</b>" + winner.name;
        movesection.waitForOk = true;
        guide.text = "press <OK>";
        if (!(winner.Equals(player0))) { guide.text = "press <OK> to retry"; }
        if(glb.next)
        {
            if (winner.Equals(player0)) 
            {
                if (GAMEMANAGER.level == 3) { SceneManager.LoadScene(7); }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
            else {
                glb.reset();
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

}
