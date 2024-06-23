using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBehaviour : MonoBehaviour, IFlockingBehaviour
{
    public float multiplier = 1f;
    public Transform target;
    Seek _steering;
    private void Awake()
    {
        _steering = new Seek(target);
    }
    public Vector3 GetDir(List<IBoid> boids, IBoid self)
    {
        return (target.position-self.Position).normalized * multiplier;
    }
}