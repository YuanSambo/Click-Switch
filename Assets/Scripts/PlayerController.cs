using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 dir;
    private int currentColorIndex = 0;

    [Header("Player")]
    public GameObject gun;
    public GameEvent DeathEvent;
    public float speed;
    public Color[] color;
    

    [Header("Projectile")]
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform firePoint;

    [SerializeField] private float fireRate;
    private float _timer;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _gunSprite;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
        _gunSprite = gun.GetComponent<SpriteRenderer>();
    }

   
    private void Update()
    {
        Move();
        
        if(Input.GetKeyDown(KeyCode.X))
        {
            ChangeColor();
        }

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (fireRate <= _timer)
            {
                Shoot();
                _timer = 0;
            }
        }
        _timer += Time.deltaTime;
    }


    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
    }


    private void Shoot()
    {
        
            var inst = Instantiate(projectile, firePoint.position, firePoint.localRotation);
            SpriteRenderer sprite = inst.GetComponent<SpriteRenderer>();
            sprite.color = _playerSprite.color;

    }
    private void ChangeColor()
    {
        currentColorIndex++;
        if (currentColorIndex > color.Length-1)
        {
            currentColorIndex = 0;
        }
        _playerSprite.color = color[currentColorIndex];
        _gunSprite.color = color[currentColorIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Color collisionColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            Color thisColor = _playerSprite.color;
            if (collisionColor == thisColor)
            {
                GameManager.Instance.Point();
                Destroy(other.gameObject);
            }
            else { DeathEvent.Raise(); Destroy(gameObject); }
        }
    }
    
}
