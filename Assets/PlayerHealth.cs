
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 5;
    public int currentHp;

    void Start()
    {
        currentHp = maxHp;
        Debug.Log("HP: " + currentHp);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        Debug.Log("HP: " + currentHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
