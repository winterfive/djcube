using System.Collections;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    // Handles all individual sound cube actions (rotate, color changes, playing audio, etc)

    private RayCaster _rayCaster;
    private GameObject _this;
    private Renderer _rend;
    private Color _defaultColor;
    private bool _isOver;
    private AudioSource _audio;
    private bool _isActive;
    private CubeValues _cubeValues;
    private Color _overColor;
    private float _rotationDuration;
    private Color _glowColor;
    private float _glowSpeed;
    private float _activeRotation;
    private float _targetRotation;

    private void Awake()
    {
        GameObject cubeValuesObject = GameObject.FindWithTag("ScriptManager");

        if (cubeValuesObject != null)
        {
            _cubeValues = cubeValuesObject.GetComponent<CubeValues>();
            _overColor = _cubeValues.overColor;
            _rotationDuration = _cubeValues.rotationDuration;
            _glowColor = _cubeValues.glowColor;
            _glowSpeed = _cubeValues.glowSpeed;
            _activeRotation = _cubeValues.activeRotation;
        }
        else
        {
            Debug.Log("Cannot find cube values script.");
        }

        _rayCaster = RayCaster.Instance;
        _this = this.gameObject;
        _rend = _this.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
        _audio = _this.GetComponent<AudioSource>();
        _isOver = false;
        _isActive = false;        
    }


    public void Update()
    {
        if (_isActive)
        {
            LerpColor();
        }
    }


    public void Over()
    {
        _rend.material.color = _overColor;
        
        _isOver = true;
    }


    public void Out()
    {
        _rend.material.color = _defaultColor;
        
        _isOver = false;
    }


    public void Activate()
    {
        if (_isOver)
        {
            // if button isn't already activated
            if (!_isActive)
            {
                // activate button
                _isActive = true;

                // play sound
                _audio.Play();

                // rotate 45 degrees
                StopCoroutine(RotateCube());
                _targetRotation = _activeRotation;
                StartCoroutine(RotateCube());
            }

            // button is already activated
            else
            {
                // deactivate button
                _isActive = false;

                // stop sound clip
                _audio.Stop();

                // rotate back to default rotation
                StopCoroutine(RotateCube());
                _targetRotation = 0f;
                StartCoroutine(RotateCube());

                _rend.material.color = _overColor;
            }
        }
        else
        {
            return;
        }
    }


    private IEnumerator RotateCube()
    {
        float time = 0f;
        Quaternion start = _this.transform.rotation;
        Quaternion target = Quaternion.Euler(0f, 0f, _targetRotation);

        while (time < _rotationDuration)
        {
            _this.transform.rotation = Quaternion.Slerp(start, target, time / _rotationDuration);
            yield return null;
            time += Time.deltaTime;
        }

        _this.transform.rotation = target;
    }


    public void LerpColor()
    {
        //float pingpong = Mathf.PingPong(Time.time * _glowSpeed, 1.0f);
        //_rend.material.color = Color.Lerp(_overColor, _glowColor, pingpong);
    }


    private void OnEnable()
    {
        InputManager.OnClick += Activate;
    }


    private void OnDisable()
    {
        InputManager.OnClick -= Activate;
    }
}
