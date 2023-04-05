using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Transform startPoint;

    public void Start()
    {
        GameObject player = ObjectPool.Instance.SpawnFromPool(Constants.TAG_PLAYER, startPoint.position, Quaternion.identity);
    }
}