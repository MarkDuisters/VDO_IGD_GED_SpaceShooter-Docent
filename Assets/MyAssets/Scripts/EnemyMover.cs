using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

  
}
