using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour
{
    int moveSpeed;
    int attackDamage;
    float attackRadius;

    //movement
    float followRadius;

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    public void setAttackDamage(int atkDmg)
    {
        attackDamage = atkDmg;
    }

    public int getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    //movement toward a player

    public void setFollowRadius(float r)
    {
        followRadius = r;
    }

    public void setAttackRadius(float r)
    {
        attackRadius = r;
    }
    //if player in enemy radius, move to player
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if(Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //if player in radius, atk player
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }
}
