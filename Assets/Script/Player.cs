using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;
    [SerializeField, Header("�W�����v���x")]
    private float _jumpSpeed;

    private Vector2 _inputDirecrion;
    private Rigidbody2D _rigid;
    private bool _isJump;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent��Unity���Œǉ������R���|�[�l���g�̒l������Ă����B
        //�����ł͏d�͂̒l������Ă��Ă�B
        _rigid = GetComponent<Rigidbody2D>();

        _isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    //�L�����N�^�[�̈ړ�
    private void _Move()
    {
        //new Vector2(�����̓���, �c���̓���)

        //���ꂪ���ړ��ɂȂ�B
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
