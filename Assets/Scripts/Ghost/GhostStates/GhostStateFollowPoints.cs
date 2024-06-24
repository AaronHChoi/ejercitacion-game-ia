using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateFollowPoints<T> : State<T>, IPoints
{
    GhostModel _model;
    List<Vector3> _waypoints;
    int _nextPoint = 0;
    bool _isFinishPath = true;
    Animator _anim;
    public GhostStateFollowPoints(GhostModel model, Animator anim)
    {
        _model = model;
        _anim = anim;
    }
    public override void Enter()
    {
        base.Enter();
        //_anim.SetFloat("Vel", 1);
    }
    public override void Execute()
    {
        base.Execute();
        Run();
    }
    public override void Sleep()
    {
        base.Sleep();
        //_anim.SetFloat("Vel", 0);
    }
    public void SetWayPoints(List<Node> newPoints)
    {
        var list = new List<Vector3>();
        for (int i = 0; i < newPoints.Count; i++)
        {
            list.Add(newPoints[i].transform.position);
        }
        SetWayPoints(list);
    }
    public void SetWayPoints(List<Vector3> newPoints)
    {
        _nextPoint = 0;
        if (newPoints.Count == 0) return;
        _waypoints = newPoints;
        var pos = _waypoints[_nextPoint];
        pos.y = _model.transform.position.y;
        _model.SetPosition(pos);
        _isFinishPath = false;
    }
    void Run()
    {
        if (IsFinishPath) return;
        var point = _waypoints[_nextPoint];
        var posPoint = point;
        posPoint.y = _model.transform.position.y;
        Vector3 dir = posPoint - _model.transform.position;
        if (dir.magnitude < 0.2f)
        {
            if (_nextPoint + 1 < _waypoints.Count)
                _nextPoint++;
            else
            {
                _isFinishPath = true;
                return;
            }
        }
        _model.Move(dir.normalized);
        _model.LookDir(dir);
    }
    public bool IsFinishPath => _isFinishPath;
}
