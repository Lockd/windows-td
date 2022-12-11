using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerTypes { Excel, PowerPoint, Word, Chrome, Explorer, All, Generic };

[CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/Power up", order = 1)]
public class PowerUpScriptableObject : ScriptableObject
{
    public TowerTypes targetTower;
    public int additionalDamage = 0;
    public float shotCooldownReduction = 0f;
    public float additionalFreezeTime = 0f;
    public int additionalTagets = 0;
    public float additionalRange = 0f;
    public int spawnAdditionalTowers = 0;
    public Sprite sprite;
    public string title;
    [TextArea] public string description;
}
