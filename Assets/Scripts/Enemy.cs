using System;
using UnityEngine;
using UnityEngine.Tilemaps;



    public class Enemy : MonoBehaviour
    {
        [HideInInspector]
        public GameObject Walls;
        public float speed;
        public GameEvent PlayerDeath;

        private Tilemap _tilemap;
        private Transform _transform;
        private SpriteRenderer _enemySprite;
        private ParticleSpawner _particleSpawner;

        private void Awake()
        {
            _tilemap = Walls.GetComponent<Tilemap>();
            _transform = GetComponent<Transform>();
            _enemySprite = GetComponent<SpriteRenderer>();
            _particleSpawner = GetComponent<ParticleSpawner>();
        }

        private void Update()
        {
            _transform.position+=Vector3.down*Time.deltaTime*speed;
            
        }


        private void OnMouseDown()
        {
            if (_enemySprite.color == _tilemap.color)
            {
                SoundManager.Instance.Play("EnemyDeath");
                CameraManager.Instance.CameraShake();
                GameManager.Instance.Point();
                _particleSpawner.SpawnParticle();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                PlayerDeath.Raise();
                Destroy(gameObject);
            }
        }
        
    }
