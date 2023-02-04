using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "NPC", menuName ="NPC/Dialog", order =1)]
public class NPC : ScriptableObject
{
    public string mark;
    public string nameNpc;
    public string dialog;
}
