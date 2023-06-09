using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField, Header("移動速度")]
    private float _moveSpeed;

    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        //ここで重力の値を取ってきてる。
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        _rigid.velocity = new Vector2(Vector2.left.x * _moveSpeed, _rigid.velocity.y);
    }
}
