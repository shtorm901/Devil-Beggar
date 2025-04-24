using UnityEngine;

public class Moving : MonoBehaviour
{
    private float MoveVector;

    public float Speed;
    public float JumpForce;

    public bool isGround;
    public bool FaceRight;

    Rigidbody2D rb;
    public void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate(){
        Move();
    }

    public void Update(){
        Jump();
        if(MoveVector < 0 && FaceRight){
            Flip();
        }
        else if(MoveVector > 0 && !FaceRight){
            Flip();
        }
    }

    public void Move(){
        MoveVector = Input.GetAxisRaw("Horizontal");
        {
            rb.linearVelocity = new Vector2(MoveVector* Speed, rb.linearVelocity.y);
        }
    }

    public void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            rb.AddForce(JumpForce * Vector2.up);
        }
    }

    public void Flip(){
        FaceRight = !FaceRight;
        transform.Rotate(0, 180, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            isGround = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            isGround = false;
        }
    }
}