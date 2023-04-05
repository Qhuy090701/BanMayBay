using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int speed = 20;

    private Vector3 target;

    private void Update()
    {
        if (target != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

            if (transform.position == target)
            {
                target = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.TAG_BULLET))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                health -= bullet.GetDamage();
                if (health <= 0)
                {
                    Die();
                }
                bullet.ReturnToPool();
                Debug.Log("Enemy hit");
            }
        }
    }

    private void Die()
    {
        ObjectPool.Instance.ReturnToPool(Constants.TAG_BOT, gameObject);
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}