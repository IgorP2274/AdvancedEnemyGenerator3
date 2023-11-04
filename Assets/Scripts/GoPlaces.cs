using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;

    private Transform[] _points;
    private int _pointNumber;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        Transform _targetPoint = _points[_pointNumber];
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == _targetPoint.position)
            GetNextPosition();
    }

    private void GetNextPosition()
    {
        _pointNumber++;

        if (_pointNumber == _points.Length)
            _pointNumber = 0;

        Vector3 currentPosition = _points[_pointNumber].transform.position;
        transform.forward = currentPosition - transform.position;
    }
}