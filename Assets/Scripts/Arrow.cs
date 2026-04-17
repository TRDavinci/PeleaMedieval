using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;
    public float lifeTime = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Player"))
        {
            Health targetHealth = collision.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Obstaculo"))
        {
            Destroy(gameObject);
        }*/
    }
}
