using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float attack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(gameObject.tag)) { return; }

        Destroy(gameObject);
    }
}
