using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredNPC : NPC
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log($"{npcName}: Please You Need to check on the others, go down the hall and check on them and the cargo!");
    }
}
