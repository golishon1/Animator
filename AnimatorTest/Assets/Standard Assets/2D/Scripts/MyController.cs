using UnityEngine;

public class MyController : MonoBehaviour
{
    private readonly int _jump = Animator.StringToHash("Jump");
    private readonly int _crunch = Animator.StringToHash("Crunch");
    
    [SerializeField] private float _speed = 5f;
    
    private Animator _animator;
    private bool _isCrunch;
    private Rigidbody2D _rigidbody;
    private Vector2 _startScale;

    private void Start()
    {
        _startScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var h = Input.GetAxis("Horizontal");

        Move(h);
        Flip(h);
        Jump();
        Crunch();
    }

    private void Move(float h)
    {
        _animator.SetFloat("Run", Mathf.Abs(h));
        _rigidbody.velocity = new Vector2(h * _speed, _rigidbody.velocity.y);
    }

    private void Flip(float h)
    {
        gameObject.transform.localScale = h < 0
            ? new Vector2(-_startScale.x, _startScale.y)
            : new Vector2(_startScale.x, _startScale.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0f, 400f));
            _animator.SetTrigger(_jump);
        }
    }

    private void Crunch()
    {
        if (Input.GetKey(KeyCode.LeftControl)) _isCrunch = true;
        if (Input.GetKeyUp(KeyCode.LeftControl)) _isCrunch = false;
        _animator.SetBool(_crunch, _isCrunch);
    }
}