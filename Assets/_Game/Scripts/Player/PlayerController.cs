using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform attackPoint1;
    [SerializeField] private Transform attackPoint2;
    [SerializeField] private float cooldown = 0.5f;
    private bool canShoot = true;

    private void Update()
    {
        if (canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet1 = ObjectPool.Instance.SpawnFromPool(Constants.TAG_BULLET, attackPoint1.position, Quaternion.identity);
        GameObject bullet2 = ObjectPool.Instance.SpawnFromPool(Constants.TAG_BULLET, attackPoint2.position, Quaternion.identity);

        bullet1.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;

        canShoot = false;
        StartCoroutine(ResetShoot());
    }

    IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TAG_BOT))
        {
            ObjectPool.Instance.ReturnToPool(Constants.TAG_PLAYER, gameObject);
            ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, collision.gameObject);
        }
    }

}