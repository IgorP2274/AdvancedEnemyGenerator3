using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    public void SetTarget(Transform target) =>
        _target = target;

    private void Update() 
    {
        if (_target != null)
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    } 
}
