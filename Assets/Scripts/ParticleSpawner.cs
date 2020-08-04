using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
    {
        public ParticleSystem _particle;
        private Transform _transform;
        private SpriteRenderer _playerSprite;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _playerSprite = GetComponent<SpriteRenderer>();
        }
        
        public void SpawnParticle()
        {
            var splash =Instantiate(_particle, _transform.position, Quaternion.identity);
            var particle = splash.GetComponent<ParticleSystem>();
            var particleMain = particle.main;
            particleMain.startColor = _playerSprite.color;
            particle.Play();
        }
}