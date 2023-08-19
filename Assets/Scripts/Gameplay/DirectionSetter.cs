using UnityEngine;
using Dreamteck.Splines;

public class DirectionSetter : MonoBehaviour
{
    [SerializeField] private Vector2 _middlePointSensetivity, _endPointSensetivity;

    private Vector3[] _pointsStartPositions;
    private CardThrow _cardThrow;
    private SplineComputer _splineComputer;

    public void Init(
        CardThrow cardThrow,
        SplineComputer splineComputer)
    {
        _splineComputer = splineComputer;
        _cardThrow = cardThrow;
        InitializeSplineDotsPositions();
    }
    private void InitializeSplineDotsPositions()
    {
        _pointsStartPositions = new Vector3[_splineComputer.pointCount];
        for (int i = 0; i < _splineComputer.pointCount; i++)
        {
            _pointsStartPositions[i] = _splineComputer.GetPointPosition(i, SplineComputer.Space.Local);
        }
    }
    private void Update()
    {
        SetDirection();
    }
    private void SetDirection()
    {
        if (_cardThrow.CanThrow)
        {
            Vector3 test = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            float horizontal = test.x - 0.5f;
            float vertical = test.y - 0.5f;

            _splineComputer.SetPointPosition(1, _pointsStartPositions[1] + new Vector3(horizontal * _middlePointSensetivity.x, 0, vertical * _middlePointSensetivity.y), SplineComputer.Space.Local);
            _splineComputer.SetPointPosition(2, _pointsStartPositions[2] + new Vector3(horizontal * _endPointSensetivity.x, 0, vertical * _endPointSensetivity.y), SplineComputer.Space.Local);
        }
    }
}
