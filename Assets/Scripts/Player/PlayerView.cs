using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject body;
    public Animator anim;
    Rigidbody _rb;
    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //anim.SetFloat("Speed", _rb.velocity.magnitude);
    }
}
