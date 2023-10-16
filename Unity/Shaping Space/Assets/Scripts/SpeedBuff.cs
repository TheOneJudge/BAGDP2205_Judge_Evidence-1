using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Boosts/SpeedBoost")]
public class SpeedBuff : Boosts
{
    public float amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().speed += amount;
    }
}
