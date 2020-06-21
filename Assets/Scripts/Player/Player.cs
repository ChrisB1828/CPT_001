using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigid;
    
    [SerializeField]
    private float _jumpForce = 6.0f; //players jump hight
    [SerializeField]
    private float _speed = 7.0f; //players speed
    [SerializeField]
    protected int _health;
    public int Health { get; set; }

    private bool _resetJump;
    private bool _isAttacking;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private Animator _animation;
    private Weapons _weapons;

    private bool _facingRight = true; // which way player ar currently faceing

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _animation = GetComponent<Animator>();
        _weapons = GetComponent<Weapons>();
        Health = _health;
    }

    void Update()
    { 
        Movement();
        Jump();
        Attack();
    }

    void PlayerHealth()
    {
        _health = 150;
    }

    void Movement() // movment - left, right and jump
    {

        IsGrounded(); //need to input code for falling animation!!!!!

        float move = Input.GetAxisRaw("Horizontal"); //movement

        if (move > 0 && !_facingRight)
        {
            Flip3();
        }
        else if (move < 0 && _facingRight)
        {
            Flip3();  
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move); //player animation  when moveing
    }

    void Jump()
    {  
        if ( Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true) //jumping
        {
            //_rigid.AddForce(new Vector2(0f, _jumpForce));
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
            _playerAnim.JumpAnim(); //jumping animation when jumping
        }  
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }     
    }

    bool IsGrounded() //to chech if player is grounded
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.8f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Flip(bool faceRight) //Fliping animations
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }
    public void Flip2()
    {
        _facingRight = !_facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Flip3()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);  
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
