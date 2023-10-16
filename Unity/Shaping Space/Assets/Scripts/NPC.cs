using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName;
    
    public virtual void Interact()
    {
        Debug.Log($"You are interacting with {npcName}.");
    }
}
