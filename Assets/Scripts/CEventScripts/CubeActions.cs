using System.Collections;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    // Handles all individual sound cube actions (rotate, color chnges, playing audio, etc)

    public float rotationSpeed;
    public float rotationDegrees;

    private RayCaster _rayCaster;
    private GameObject _this;
    private Renderer _rend;
    private Color _defaultColor;
    private bool _isOver;
    private AudioSource _audio;
    private bool _isActive;

    private void Awake()
    {
        _rayCaster = RayCaster.Instance;
        _this = this.gameObject;
        _rend = _this.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
        _audio = _this.GetComponent<AudioSource>();
        _isActive = false;
    }

    public void Over()
    {
        _rend.material.color = Color.cyan;
        
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
                //_this.transform.Rotate(0f, 0f, rotationDegrees);
                StartCoroutine(RotateCube(rotationDegrees));

                // change color
                _rend.material.color = Color.yellow;
            }
            // button is already activated
            else
            {
                // deactivate button
                _isActive = false;

                // stop sound clip
                _audio.Stop();

                // rotate back to default rotation
                //_this.transform.Rotate(0f, 0f, -rotationDegrees);
                StartCoroutine(RotateCube(-rotationDegrees));

                // change color back to default
                _rend.material.color = _defaultColor;
            }
        }
        else
        {
            return;
        }
    }


    private IEnumerator RotateCube(float targetRotation)
    {
        Quaternion rotation = Quaternion.Euler(0f, 0f, targetRotation);

        while (_this.transform.rotation != rotation)
        {
            _this.transform.rotation = Quaternion.Lerp(_this.transform.rotation, rotation, rotationSpeed);
        }
        yield return null;
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
