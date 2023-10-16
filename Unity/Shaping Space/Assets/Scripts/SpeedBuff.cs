using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PowerUps" ,menuName = "PowerUps/SpeedBoost")]
public class SpeedBuff : PowerUps
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().speed += amount;
    }
}
