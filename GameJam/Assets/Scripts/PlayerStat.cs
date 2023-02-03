using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Playerstat/playerStatus", order = 1)]
public class PlayerStat : ScriptableObject
{
    public float HP;
    public float ATK;
}
