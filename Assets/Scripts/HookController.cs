using System.Collections;
using DG.Tweening;
using UnityEngine;


public class HookController : MonoBehaviour
{
    [Header("Speed Variables")]
    [SerializeField] private float moveUpSpeed;
    [SerializeField] private float moveDownSpeed;
    [SerializeField] private float moveSideSpeed;

    [Header("References")]
    [SerializeField] private Transform rope;
    [SerializeField] private Transform ropeLookTarget;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UIManager uiManager;
    
    private Camera _camera;
    private bool _isMovingDown = true;
    private int _screenWidth = 828;
    private float _oldXInput;

    private Transform _transform;
    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;
    }
    private void Update()
    {
        RotateHook();      
    }
    private void RotateHook()
    {
        if (gameObject.transform.position.y < 0 && !_isMovingDown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var xInput = GetNormalizedInput();
                _oldXInput = xInput;
            }
            if (Input.GetMouseButton(0))
            {
                var xInput = GetNormalizedInput();

                var delta = xInput - _oldXInput;

                transform.position += new Vector3(delta * Time.deltaTime * moveSideSpeed, 0, 0);

                var position = _transform.position;
                position = new Vector3(Mathf.Clamp(position.x, -2, 2), position.y, 0);
                _transform.position = position;

                _oldXInput = xInput;
            }
        }
        else if (gameObject.transform.position.y >= 0 && !_isMovingDown)
        {
            transform.DOMoveX(0, 0.75f);
        }
        rope.rotation = Quaternion.LookRotation(ropeLookTarget.position - rope.position);
    }
    private float GetNormalizedInput()
    {
        return  (Input.mousePosition.x - 0) / (_screenWidth - 0);
    }
    private IEnumerator HookMoveDown()
    {
        _isMovingDown = true;
        uiManager.onSurfaceCanvas.gameObject.SetActive(false);
        do
        {
            _camera.transform.position += Time.deltaTime* moveDownSpeed * -Vector3.up ;
            if (_camera.transform.position.y <= 9.45)
            {
                gameObject.transform.position += Time.deltaTime* moveDownSpeed * -Vector3.up ;
                gameObject.transform.GetComponent<Collider2D>().enabled = false;
            }
            yield return null;
        } while (_camera.transform.position.y >= -levelManager.currentDeptLenght);

        StartCoroutine(HookMoveUp());
    }
    private IEnumerator HookMoveUp()
    {
        _isMovingDown = false;
        while (_camera.transform.position.y <= 16)
        {
            _camera.transform.position +=   Time.deltaTime * moveUpSpeed* Vector3.up;
            if (gameObject.transform.position.y <= 9.43)
            {
                gameObject.transform.position += Time.deltaTime * moveUpSpeed* Vector3.up;
                transform.GetComponent<Collider2D>().enabled = true;
            }
            yield return null;
        }
        uiManager.onSurfaceCanvas.gameObject.SetActive(true);
    }
    public IEnumerator Hook()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(HookMoveDown());
        
    }
}
