using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveForce = 0.5f;
    public float rotationSpeed = 1.0f;
    public GameObject target;
    private Rigidbody rigid;

    public float damage = 20f;
    public float attackRate = 10f;
    public float attackRange = 3.01F;
    private float attackCooldown;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        attackCooldown = attackRate;
    }

    void Update()
    {
        // identify direction to target
        Vector3 targetOffset = target.transform.position + (target.transform.up * target.transform.localScale.y) - transform.position;

        // look at target
        transform.rotation = Quaternion.LookRotation(targetOffset);

        // determine thrust direction
        Vector3 thrustDirection = targetOffset - (target.GetComponent<Rigidbody>().velocity * 2F);
        thrustDirection = thrustDirection.magnitude < thrustDirection.normalized.magnitude ? thrustDirection : thrustDirection.normalized;

        // thrust
        rigid.AddForce(thrustDirection * moveForce);

        // manage cooldown time
        attackCooldown = attackCooldown > 0F ? attackCooldown - Time.deltaTime : -0.5F;

        // attack if able and target is within attack range
        if (attackCooldown < 0F && targetOffset.magnitude < attackRange)
        {
            target.GetComponent<Player>().TakeDamage(damage);
            attackCooldown = attackRate;
        }
    }
}
