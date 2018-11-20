using System.Collections;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    // Handles all individual sound cube actions (rotate, color changes, playing audio, etc)

    private RayCaster _rayCaster;
    private GameObject _background;
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
    private float _activeRotationZ;
    private float _targetRotationZ;
    private float _defaultY;

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
        _background = GameObject.FindGameObjectWithTag("Background");
        _rend = _background.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
        _audio = GetComponent<AudioSource>();
        _isOver = false;
        _isActive = false;
        _defaultY = _background.transform.rotation.y;
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
                _targetRotationZ = -_activeRotationZ;
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
        Quaternion start = _background.transform.rotation;
        Quaternion target = start * Quaternion.AngleAxis(_targetRotationZ, Vector3.forward);

        while (time < _rotationDuration)
        {
            _background.transform.rotation = Quaternion.Lerp(start, target, time / _rotationDuration);
            yield return null;
            time += Time.deltaTime;
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
