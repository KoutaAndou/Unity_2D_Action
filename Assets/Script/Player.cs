using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField, Header("�ړ����x")]
    private float _moveSpeed;

    private Vector2 _inputDirecrion;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent��Unity���Œǉ������R���|�[�l���g�̒l������Ă����B
        //�����ł͏d�͂̒l������Ă��Ă�B
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    //�L�����N�^�[�̈ړ�
    private void _Move()
    {
        //���ꂪ���ړ��ɂȂ�Bnew Vector2(�����̓���,�c���̓���)
        _rigid.velocity = new Vector2(_inputDirecrion.x * _moveSpeed, _rigid.velocity.y);
    }

    public void _Onmove(InputAction.CallbackContext context)
    {
        _inputDirecrion = context.ReadValue<Vector2>();
    }
}
