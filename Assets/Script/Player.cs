using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField, Header("移動速度")]
    private float _moveSpeed;
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;

    private Vector2 _inputDirecrion;
    private Rigidbody2D _rigid;
    private bool _isJump;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentでUnity側で追加したコンポーネントの値を取ってこれる。
        //ここでは重力の値を取ってきてる。
        _rigid = GetComponent<Rigidbody2D>();

        _isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    //キャラクターの移動
    private void _Move()
    {
        //new Vector2(横軸の動き, 縦軸の動き)

        //これが横移動になる。
        _rigid.velocity = new Vector2(_inputDirecrion.x * _moveSpeed, _rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            _isJump = false;
        }
    }

    public void _Onmove(InputAction.CallbackContext context)
    {
        _inputDirecrion = context.ReadValue<Vector2>();
    }

    public void _Onjump(InputAction.CallbackContext context)
    {
        if(!context.performed || _isJump)
        {
            return;
        }

        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        _isJump = true;
    }
}
