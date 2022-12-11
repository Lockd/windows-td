using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private TowerTypes type;
    [SerializeField] private float radius = 8f;
    [SerializeField] private float shotCooldown = .2f;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float bulletSize = .2f;
    [Range(0, 1)][SerializeField] private float enemySpeedReduction = 0f;
    [Range(0, 1)][SerializeField] private float slowChance = 0f;
    [SerializeField] private float slowDuration = 0f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int attackTargets = 1;
    CircleCollider2D _collider;
    List<GameObject> targets = new List<GameObject>();
    float canShootAfter = 0f;
    modifiers currentMods;

    void Start()
    {
        currentMods = (modifiers)PowerUpsManager.modifiersList["" + type];
        _collider = GetComponent<CircleCollider2D>();
        _collider.radius = radius;
    }

    void Update()
    {
        if (targets != null && targets.Count > 0 && Time.time > canShootAfter)
        {
            shoot();
        }
        if (_collider.radius != radius + currentMods.additionalRange)
        {
            updateTowerRange();
        }
    }

    void updateTowerRange()
    {
        // Should update towers range
        _collider.radius = radius + currentMods.additionalRange;
    }

    public void changeTarget(GameObject targetToRemove = null)
    {
        if (targetToRemove) targets.Remove(targetToRemove);
        if (!targetToRemove) targets.RemoveAt(0);
    }

    public void addEnemy(GameObject target)
    {
        targets.Add(target);
    }

    void shoot()
    {
        canShootAfter = Time.time + shotCooldown - currentMods.shotCooldownReduction;

        // TODO fix error here
        int totalTargets = attackTargets + currentMods.additionalTagets;
        for (int i = 0; i < totalTargets; i++)
        {
            GameObject spawnedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            BulletBehaviour bulletBehaviour = spawnedProjectile.GetComponent<BulletBehaviour>();
            bulletBehaviour.target = targets[i];
            bulletBehaviour.parentTower = gameObject;
            bulletBehaviour.speed = projectileSpeed;
            bulletBehaviour.damage = damage + currentMods.additionalDamage;
            bulletBehaviour.sprite = spriteRenderer.sprite;
            bulletBehaviour.size = bulletSize;
            if (enemySpeedReduction > 0 && Random.Range(0.01f, 1f) < slowChance)
            {
                bulletBehaviour.enemySpeedReduction = enemySpeedReduction;
                bulletBehaviour.slowDuration = slowDuration + currentMods.additionalFreezeTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Boss")
        {
            addEnemy(collider.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Boss")
        {
            changeTarget(collider.gameObject);
        }
    }
}
