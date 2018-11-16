using System.Collections;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    // Handles all individual sound cube actions (rotate, color changes, playing audio, etc)

    private RayCaster _rayCaster;
    private GameObject _this;
    private Renderer _rend;    
    private bool _isOver;
    private AudioSource _audio;
    private bool _isActive;
    private CubeValues _cubeValues;
    private Color _defaultColor;
    private Color _overColor;    
    private Color _glowColor;
    private float _glowSpeed;
    private float _rotationDuration;
    private float _defaultY;
    private float _activeRotationZ;
    private float _targetRotationZ;

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
            _activeRotationZ = _cubeValues.activeRotation;
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
        _defaultY = _this.transform.position.y;
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
                _targetRotationZ = _activeRotationZ;
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
                _targetRotationZ = 0f;
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
        //Quaternion start = _this.transform.localRotation;
        //Quaternion target = Quaternion.Euler(new Vector3(0f, _defaultY, _targetRotationZ));

        //while (time < _rotationDuration)
        //{
        //    _this.transform.rotation = Quaternion.Slerp(start, target, time / _rotationDuration);
        //    yield return null;
        //    time += Time.deltaTime;
        //}

        //_this.transform.rotation = target;

        // hint
        //currentRotation = transform.eulerAngles;
        //currendRotation.z = Mathf.Lerp(currentRotation.z, correctRotation, Time.deltaTime * smoothness);
        //transform.eulerAngles = currentRotation;

        while (time < _rotationDuration)
        {
            
        }
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
