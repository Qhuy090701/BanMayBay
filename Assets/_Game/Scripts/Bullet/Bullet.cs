using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  [Header("Bullet")] [SerializeField] private int damage = 1;
  [SerializeField] private float timeReturnToPool = 2f;
  [SerializeField] private float speed = 20f;

  private void OnEnable() {
    StartCoroutine(ResetShoot());
  }

  private void Update() {
    transform.Translate(Vector3.up * speed * Time.deltaTime);
  }

  IEnumerator ResetShoot() {
    yield return new WaitForSeconds(timeReturnToPool);
    ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, gameObject);
  }

  public int GetDamage() {
    return damage;
  }

  public void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag(Constants.TAG_BOT)) {
      if (TypeMap.isChangeMap == false) {
        ObjectPool.Instance.ReturnToPool(Constants.TAG_BULLET, gameObject);
      }
    }
  }
}