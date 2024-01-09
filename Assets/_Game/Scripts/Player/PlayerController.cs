using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  [Header("Attack Point")]
  [SerializeField] private Transform attackPoint;
  [SerializeField] private float cooldown = 0.5f;
  private bool canShoot = true;

  private void Update() {
    if (canShoot) {
      Shoot();
    }
  }

  private void Shoot() {
    ObjectPool.Instance.SpawnFromPool(Constants.TAG_BULLET, attackPoint.position, Quaternion.identity);
    canShoot = false;
    StartCoroutine(ResetShoot());
  }

  IEnumerator ResetShoot() {
    yield return new WaitForSeconds(cooldown);
    canShoot = true;
  }

  public void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag(Constants.TAG_BOT)) {
      ObjectPool.Instance.ReturnToPool(Constants.TAG_PLAYER, gameObject);
      ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, collision.gameObject);
    }
  }
}