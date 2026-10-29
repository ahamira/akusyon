
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.8f;
    public float attackCooldown = 0.4f;

    private float nextAttackTime;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.jKey.wasPressedThisFrame
            && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void Attack()
    {
        Debug.Log("Attack!");

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange
        );

        foreach (Collider2D hit in hitObjects)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                Destroy(hit.gameObject);
                Debug.Log("Enemy defeated!");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }
}
