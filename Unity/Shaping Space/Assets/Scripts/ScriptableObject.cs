using UnityEngine;

[CreateAssetMenu(menuName = "Items/Speed Boost Item")]
public class SpeedBoostItem : ScriptableObject
{
    public string itemName = "Speed Boost";
    public string itemDescription = "Increases player speed for a short duration.";
    public float speedBoostAmount = 2.0f; // Adjust the value as needed.
    public float duration = 5.0f; // Adjust the duration as needed.
}
