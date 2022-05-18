using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private Vector3 pullForce(Attractor other)
    {
        Rigidbody attractorRigid = other.rigid;
        Vector3 pullVector = attractorRigid.position - rigid.position;
        float distance = pullVector.magnitude;
        pullVector = pullVector.normalized;
        return pullVector * (rigid.mass * attractorRigid.mass / (distance * distance));
    }

    void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        Vector3 totalForce = new Vector3(0, 0, 0);
        foreach (Attractor attractor in attractors)
        {
            if (this != attractor)
            {
                totalForce = totalForce + pullForce(attractor);
            }
        }
        rigid.AddForce(totalForce);
    }
}
