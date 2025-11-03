using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ContainerObstacle"))
        {
            GameManager.Instance.AddScore(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle")) 
        {
            GameManager.Instance.StopGame();
            Destroy(collision.gameObject);
        }
    }
}