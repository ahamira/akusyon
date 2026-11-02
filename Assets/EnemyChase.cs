
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Transform player;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        if (obj != null)
        {
            player = obj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }
}
