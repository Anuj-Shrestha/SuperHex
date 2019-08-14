using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float movement;
    public float moveSpeed = 600f;
    public Rigidbody2D rb;

    void FixedUpdate()
    {

        movement = Input.GetAxisRaw("Horizontal");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition.normalized;

            // Move object across X plane
            transform.RotateAround(Vector3.zero, Vector3.forward, -touchDeltaPosition.x * moveSpeed * Time.fixedDeltaTime);
        }

        transform.RotateAround(Vector3.zero, Vector3.forward, -movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
