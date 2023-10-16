using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI textMeshPro;
    public float proximityDistance = 5f;

    private bool playerInRange = false;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= proximityDistance && !playerInRange)
        {
            playerInRange = true;
            SetText(); 
            textMeshPro.gameObject.SetActive(true);
        }
        else if (distanceToPlayer > proximityDistance && playerInRange)
        {
            playerInRange = false;
            textMeshPro.gameObject.SetActive(false); 
        }
    }

    protected virtual void SetText()
    {
        
    }
}
