using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _target;

    void Start() =>
        StartCoroutine(Shooting());

    IEnumerator Shooting()
    {
        bool isWorking = enabled;

        while (isWorking)
        {
            Vector3 direction = (_target.position - transform.position).normalized;

            Rigidbody rigidbody = Instantiate(_prefab, transform.position + direction, Quaternion.identity).GetComponent<Rigidbody>();

            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _speed;

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}