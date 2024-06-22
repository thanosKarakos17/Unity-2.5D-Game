using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GAMEMANAGER
{
    private static int damage = 2;
    public static int maxHealth = 60;
    public static int playerHealth = 60;
    public static int level = 0;
    public static List<bool> bossFight = new List<bool>() { false, false, false};
    
    public static void randomBoss()
    {
        int index = UnityEngine.Random.Range(0, 3);
        bossFight[index] = true;
    }

    public static void resetBoss()
    {
        bossFight = new List<bool>() { false, false, false };
    }

    public static void restoreHealth()
    {
        playerHealth = maxHealth;
    }

    public static void damagePlayer()
    {
        playerHealth -= damage;
        if (playerHealth <= 0) { playerHealth = 4; }
    }
}
