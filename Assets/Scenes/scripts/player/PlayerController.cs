using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("General Settings")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _speed = 5f;
    private float _jumpPower = 7;
    private Rigidbody2D _rb;
    bool _isGrounded = true;
    Vector3 transformStart;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        transformStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
        Jump();
        Fire();
        if(transform.position.y < -10){
            transform.position = transformStart;
        }
    }

    void Movment()
    {
        float horizontaInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontaInput * _speed * Time.deltaTime);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
            _isGrounded = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
    }
}