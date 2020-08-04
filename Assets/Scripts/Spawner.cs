using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        public GameObject Walls;
        public GameObject Enemy;
        public Color[] colors;
        
        
        public float SpawnRate =2;
        private Enemy _enemy;
        private Transform _transform;
        private SpriteRenderer _enemySprite;


        private void Awake()
        {
            _enemy = Enemy.GetComponent<Enemy>();
            _transform = GetComponent<Transform>();
            _enemySprite = Enemy.GetComponent<SpriteRenderer>();
          
        }

        private void Start()
        {
            StartCoroutine(WaveCoroutine());
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
             
                _enemySprite.color = GetRandomColor();
                _enemy.Walls = Walls;
                var position = GetRandomPosition();
                Instantiate(Enemy, position, Enemy.transform.rotation);
                yield return new WaitForSeconds(SpawnRate);
            }
        }

        private IEnumerator WaveCoroutine()
        {
            _enemy.speed = 2f;
            while (SpawnRate>=.5f)
            {
                SpawnRate -= .1f;
                _enemy.speed += .2f;
                yield return new WaitForSeconds(5);
            }
            
        }
        
        private Color GetRandomColor()
        {
            var index = Random.Range(0, colors.Length);
            return colors[index];
        }

        private Vector2 GetRandomPosition()
        {
            return new Vector2(Random.Range(-4, 4),_transform.position.y);
        }
    }
}