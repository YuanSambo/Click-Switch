using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class WallsScript : MonoBehaviour
    {

        public Color[] Colors;
        public GameObject Cursor;

        private SpriteRenderer _cursorSprite;
        private int _currentColorIndex = 0;
        private Tilemap _tilemap;
        public Text[] UIText;
        



        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
            _cursorSprite = Cursor.GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ChangeColor();
            }
        }


        private void ChangeColor()
        {
            _currentColorIndex++;
            if (_currentColorIndex > Colors.Length-1)
            {
                _currentColorIndex = 0;
            }

            _cursorSprite.color = Colors[_currentColorIndex];
            _tilemap.color = Colors[_currentColorIndex];
            foreach (var text in UIText)
            {
                text.color = Colors[_currentColorIndex];

            }
        }
        
    }
