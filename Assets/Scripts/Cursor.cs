using System;
using UnityEngine;



    public class Cursor : MonoBehaviour
    {
        private Transform _transform;
        private Camera _camera;


        private void Awake()
        {
            _camera = Camera.main;
            _transform = GetComponent<Transform>();
        }
        

       
        private void Update()
        {
            UnityEngine.Cursor.visible = false;
            var mousePos= _camera.ScreenToWorldPoint(Input.mousePosition);
            _transform.position = new Vector3(mousePos.x+.3f,mousePos.y+(-.3f),_transform.position.z);
        }
    }
