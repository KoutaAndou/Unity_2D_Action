using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField, Header("移動速度")]
    private float _moveSpeed;

    private Vector2 _inputDirecrion;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentでUnity側で追加したコンポーネントの値を取ってこれる。
        //ここでは重力の値を取ってきてる。
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    //キャラクターの移動
    private void _Move()
    {
        //これが横移動になる。new Vector2(横軸の動き,縦軸の動き)
        _rigid.velocity = new Vector2(_inputDirecrion.x * _moveSpeed, _rigid.velocity.y);
    }

    public void _Onmove(InputAction.CallbackContext context)
    {
        _inputDirecrion = context.ReadValue<Vector2>();
    }
}
