using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCrash : Player
{
    [SerializeField]
    int _life;
    public float attackCooldown;
    Coroutine _cooldown;
    public Action onSpin = delegate { };
    public float fuerzaEmpuje = 1000f;
    public GameObject personaje;

    public void Dead()
    {
        Destroy(gameObject);
    }
    public void Spin()
    {
        Attack();
        _cooldown = StartCoroutine(Cooldown());
        onSpin();
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        _cooldown = null;
    }

    void Attack()
    {
        
        Vector3 direccionOpuesta = transform.position - personaje.transform.position;
        direccionOpuesta.Normalize(); // Normalizar para obtener una direcci�n unitaria

        // Aplicar fuerza al personaje en la direcci�n opuesta
        Rigidbody personajeRigidbody = personaje.GetComponent<Rigidbody>();
        personajeRigidbody.AddForce(direccionOpuesta * fuerzaEmpuje);
    }
    public bool IsCooldown => _cooldown != null;
    public int Life => _life;
}
