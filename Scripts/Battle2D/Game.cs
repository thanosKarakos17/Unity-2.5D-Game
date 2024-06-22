using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class Player
{
    private string filename;
    public string name;
    public int health;
    public int speed;
    public int defense;
    public List<MoveData> moves;
    public Player(string filename) { 
        this.filename = filename;
        open_json();
    }

    private void open_json()
    {
        string  path = "Assets\\Scripts\\" + filename + ".json";
        string jsonString = File.ReadAllText(path);
        Data data = JsonUtility.FromJson<Data>(jsonString);

        /*
        Debug.Log(jsonString);
        Debug.Log("Name: " + data.name);
        Debug.Log("Health: " + data.health);
        Debug.Log("Speed: " + data.speed);
        Debug.Log("Defense: " + data.defense);


        foreach (MoveData move in data.moves)
        {
            Debug.Log("Move Type: " + move.type);
            Debug.Log("Move Name: " + move.name);
            Debug.Log("Move Power: " + move.power);
            Debug.Log("Move Size: " + move.size);
            Debug.Log("Move Priority: " + move.priority);
        }
        */
        name = data.name;
        health = data.health;
        speed = data.speed;
        defense = data.defense;
        moves = data.moves;

    }

}


[System.Serializable]
public class Data
{
    public string name;
    public int health;
    public int speed;
    public int defense;
    public List<MoveData> moves;
}

[System.Serializable]
public class MoveData
{
    public string type;
    public string name;
    public int power;
    public int size;
    public float priority;
}

public class GamePlay
{
    private Player player0;
    private Player player1;
    public Player winner;
    public GamePlay(Player player0, Player player1)
    {
        this.player0 = player0;
        this.player1 = player1;
    }

    public bool game_over()
    {
        if(player0.health <= 0)
        {
            winner = player1;
            return true;
        }
        else if(player1.health <= 0)
        {
            winner = player0;
            return true;
        }
        return false;
    }

    private int check_player_speed()
    {
        if(player0.speed == player1.speed)
        {
            return UnityEngine.Random.Range(0, 2);
        }
        else if (player0.speed < player1.speed)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int check_move_turn(MoveData move0, MoveData move1)
    {
        if (move0.priority == move1.priority)
        {
            return check_player_speed();
        }
        else
        {
            float s = move0.priority + move1.priority;
            float rand = UnityEngine.Random.Range(0f, s);
            if (rand < move0.priority) { return 0; }
            else { return 1;}
        }
    }

    public void check_moves(MoveData move0, MoveData move1)
    {
        move0.size--;
        move1.size--;
        if(move0.size == 0) { player0.moves.Remove(move0); }
        if(move1.size == 0) { player1.moves.Remove(move1); }
    }

    public void use_shield(Player pl)
    {
        foreach(MoveData move in pl.moves)
        {
            if(move.type == "Defense") { 
                move.size--; 
                if(move.size <= 0) { pl.moves.Remove(move); }
            }
        }
    }

    public void damage(MoveData attackMove, Player opponent)
    {
        int p = attackMove.power;
        int d = opponent.defense;
        int damage = (int)Math.Floor(Math.Floor(p * p / (double)d) / (double)20) + 2;
        opponent.health -= damage;
    }


}

