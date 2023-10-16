using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBoost : MonoBehaviour
{
    public Boosts boosts;

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
        boosts.Apply(other.gameObject);    
    }
}
