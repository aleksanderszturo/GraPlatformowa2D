using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object//
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    private void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Flip player when moving left-right//
        if (horizontalinput < 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput > -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        //Set animator parameters//
        anim.SetBool("Run", horizontalinput != 0);
    }
}
