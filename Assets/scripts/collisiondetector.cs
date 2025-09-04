using UnityEngine;

public class collisiondetector : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    BoxCollider2D touchingCol;
    Animator animator;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    [SerializeField]
    private bool _isGrounded = true;
    
    public bool IsGrounded { get {return _isGrounded;} private set
    {
        _isGrounded = value;
        animator.SetBool(AnimationStrings.isGrounded, value);
    } }
    private void Awake()
    {
        touchingCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance)  > 0;     
    }
}
