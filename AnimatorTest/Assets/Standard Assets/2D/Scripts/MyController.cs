using UnityEngine;

public class MyController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int _jump = Animator.StringToHash("Jump");

    private Vector2 _startScale;

    private bool _isCrunch;
    
    private void Start()
    {
        _startScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");
        _animator.SetFloat("Run", Mathf.Abs(h));
        if (h < 0)
            gameObject.transform.localScale = new Vector2(-_startScale.x, _startScale.y);
        else
            gameObject.transform.localScale = new Vector2(_startScale.x, _startScale.y);
        _rigidbody.velocity = new Vector2(h * _speed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            _rigidbody.AddForce(new Vector2(0f, 400f));
            _animator.SetTrigger(_jump);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _isCrunch = true;
           
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isCrunch = false;
           
        }
        _animator.SetBool("Crunch",_isCrunch);
    }
}