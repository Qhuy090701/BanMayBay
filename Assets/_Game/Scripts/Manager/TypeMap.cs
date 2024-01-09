using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMap : MonoBehaviour {
  public enum Maptypes {
    Square,
    Rectangle,
    Triangle,
    Diamond
  }

  [SerializeField] private Maptypes maptypes;

  [Header("List Map")] [SerializeField] private List<GameObject> squareList;
  [SerializeField] private List<GameObject> rectangleList;
  [SerializeField] private List<GameObject> triangleList;
  [SerializeField] private List<GameObject> diamondList;

  [Header("List Enemy")] [SerializeField]
  private List<GameObject> enemyList;

  [Header("Spawn Point")] [SerializeField]
  private Transform spawnPoint;

  [SerializeField] private int spawnBot = 16;

  private float elapsedTime = 0f;
  private float changeMapInterval = 5f;
  public static bool isChangeMap = false;
  private void Start() {
    maptypes = Maptypes.Square;

    for (int i = 0; i < spawnBot; i++) {
      GameObject enemy = ObjectPool.Instance.SpawnFromPool(Constants.TAG_BOT, spawnPoint.position, Quaternion.identity);
      enemyList.Add(enemy);
      SetEnemyTarget(enemy, GetTargetPosition(i));
    }
  }

  private void Update() {
    elapsedTime += Time.deltaTime;

    if (elapsedTime >= changeMapInterval) {
      isChangeMap = true;
      ChangeMapType();
      elapsedTime = 0f;
    }

    for (int i = 0; i < spawnBot; i++) {
      SetEnemyTarget(enemyList[i], GetTargetPosition(i));
    }
    
    isChangeMap = false;
  }

  private Vector3 GetTargetPosition(int index) {
    switch (maptypes) {
      case Maptypes.Square:
        return squareList[index % squareList.Count].transform.position;

      case Maptypes.Rectangle:
        return rectangleList[index % rectangleList.Count].transform.position;

      case Maptypes.Triangle:
        return triangleList[index % triangleList.Count].transform.position;

      case Maptypes.Diamond:
        return diamondList[index % diamondList.Count].transform.position;

      default:
        return Vector3.zero;
    }
  }

  private void SetEnemyTarget(GameObject enemy, Vector3 targetPosition) {
    enemy.GetComponent<Enemy>().SetTarget(targetPosition);
  }

  private void ChangeMapType() {
    switch (maptypes) {
      case Maptypes.Square:
        maptypes = Maptypes.Rectangle;
        break;

      case Maptypes.Rectangle:
        maptypes = Maptypes.Triangle;
        break;

      case Maptypes.Triangle:
        maptypes = Maptypes.Diamond;
        break;

      case Maptypes.Diamond:
        maptypes = Maptypes.Square;
        break;
    }
  }
}