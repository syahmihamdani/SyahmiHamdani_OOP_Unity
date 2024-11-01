using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed = new Vector2(7f, 5f);
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(1f, 1f);
    [SerializeField] private Vector2 timeToStop = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 stopClamp = new Vector2(2.5f, 2.5f);

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        if (rb == null){
            Debug.LogError("Rigidbody2D component missing on Player.");
            return;
        }

        moveVelocity = 2 * maxSpeed / timeToFullSpeed; 
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed); 
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move(){

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDirection = new Vector2(x, y).normalized;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        min.x += 0.225f;
        max.x -= 0.225f;
        min.y += 0.225f;
        max.y -= 0.225f;

        float friction = GetFriction().x;

        if (moveDirection != Vector2.zero){
            Vector2 targetVelocity = moveDirection * moveVelocity;
            float interpolation = Time.deltaTime / timeToFullSpeed.x * (1 - friction);
            rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, interpolation);
        }
        else{
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime / timeToStop.x);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, stopClamp.magnitude);
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, min.x, max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, min.y, max.y);

        transform.position = clampedPosition;
    }

    public Vector2 GetFriction(){
        if(moveDirection.magnitude > 0){
            return moveFriction;
        }
        else{
            return stopFriction;
        }
    }

    public void MoveBound(){
    }

    public bool IsMoving(){
        return rb.velocity.magnitude > 0.1f;
    }
}
