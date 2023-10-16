using UnityEngine;

[CreateAssetMenu(menuName = "powerUps")]
public abstract class PowerUps : MonoBehaviour
{
    public abstract void Apply(GameObject target);
}
