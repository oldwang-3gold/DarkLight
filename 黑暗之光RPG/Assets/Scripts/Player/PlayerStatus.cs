using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public int grade = 1;
    public int hp = 100;
    public int mp = 100;
    public int coin = 200;//金币数量

    public void GetCoin(int co)
    {
        coin += co;
    }
}
