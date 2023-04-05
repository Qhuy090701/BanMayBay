using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;

    public int GetDamage()
    {
        return damage;
    }

    public void ReturnToPool()
    {
        ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.TAG_DEADZONE))
        {
            ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, gameObject);
        }
    }
}
