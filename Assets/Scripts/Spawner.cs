using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _respawnTime;
    [SerializeField] private int _enemyCount;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_respawnTime);
        StartCoroutine(CreateEnemy());
    }

    public IEnumerator CreateEnemy()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
            enemy.SetTarget(_target);
            yield return _wait;
        }
    }
}
