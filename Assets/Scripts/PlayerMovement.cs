using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        Vector3 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir=(Vector2)mouse-rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) *Mathf.Rad2Deg; //Atan2 Calcula la ArcoTangente en radianes, multiplicarlo por Rad2Deg lo deja en grados.
        rb.rotation = angle;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput.normalized * speed * Time.fixedDeltaTime);
    }
}
