using UnityEngine;

public interface IDurable
{
    float MaxDurability { get; }
    float CurrentDurability { get; set; }
}
