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

    void Start()
    {
        spriteRenderer.sprite = sprite;
        transform.localScale = new Vector3(size, size, 1f);
    }

    void Update()
    {
        if (target != null && speed > 0f)
        {
            // TODO delete bullets if target is dead
            rb.velocity = (target.transform.position - transform.position).normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemyBehaviour = collider.gameObject.GetComponent<EnemyBehaviour>();
            enemyBehaviour.onGetDamage(damage);
            Destroy(gameObject);
        }
    }
}
