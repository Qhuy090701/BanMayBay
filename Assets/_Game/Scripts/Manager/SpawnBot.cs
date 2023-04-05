using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    [SerializeField] private List<GameObject> squareList;
    [SerializeField] private List<GameObject> rectangleList;
    [SerializeField] private List<GameObject> triangleList;
    [SerializeField] private List<GameObject> diamondList;

    [SerializeField] private int spawnBot = 16;

    public void Start()
    {

        for (int i = 0; i < spawnBot; i++)
        {
            GameObject bot = ObjectPool.Instance.SpawnFromPool(Constants.TAG_BOT, squareList[i].transform.position, Quaternion.identity);
            StartCoroutine(MoveBotToTarget(bot.GetComponent<Enemy>(), rectangleList[i % rectangleList.Count].transform.position));
        }
    }

    private IEnumerator MoveBotToTarget(Enemy enemy, Vector3 target)
    {
        yield return new WaitForSeconds(5f);
        enemy.SetTarget(target);

        yield return new WaitForSeconds(10f);
        enemy.SetTarget(triangleList[Random.Range(0, triangleList.Count)].transform.position);

        yield return new WaitForSeconds(15f);
        enemy.SetTarget(diamondList[Random.Range(0, diamondList.Count)].transform.position);

        StartCoroutine(MoveBotToTarget(enemy, rectangleList[Random.Range(0, rectangleList.Count)].transform.position));
    }
}
