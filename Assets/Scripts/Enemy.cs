using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;


    [SerializeField] private Transform[] _points;
    [SerializeField] private int _count;
    [SerializeField] private int _currentPoint;

    private void Start()
    {
        _count = _path.childCount;
        _points = new Transform[_count];

        for (int i = 0; i < _count; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (target.position == transform.position)
        {
            _currentPoint++;

            if (_currentPoint >= _count)
                Destroy(gameObject);
        }
    }

    public void SetPath(Transform path) =>
        _path = path;
}
