using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public GameObject parentTower;
    public GameObject target;
    public int damage;
    public float speed = 0f;
    public Sprite sprite;
    public float size = .2f;
    public float enemySpeedReduction = 0f;
    public float slowDuration = 0f;
    float dieAfter;

    void Start()
    {
        spriteRenderer.sprite = sprite;
        transform.localScale = new Vector3(size, size, 1f);
        dieAfter = 4 + Time.time;
    }

    void Update()
    {
        if (target != null && speed > 0f)
        {
            rb.velocity = (target.transform.position - transform.position).normalized * speed;
        }
        if (
            Time.time > dieAfter ||
            target == null
        )
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Boss")
        {
            EnemyBehaviour enemyBehaviour = collider.gameObject.GetComponent<EnemyBehaviour>();
            bool isStun = enemySpeedReduction == 1f;
            enemyBehaviour.onApplySlow(enemySpeedReduction, slowDuration, isStun);
            enemyBehaviour.onGetDamage(damage);
            Destroy(gameObject);
        }
    }
}
