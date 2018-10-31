  using System;
using System.Collections;
using UnityEngine;

public class CubeActions : MonoBehaviour
{
    public float rotationSpeed;
    protected bool _IsOver;

    private AudioSource _audioSource;
    private GameObject _go;
    private float _activeRotation = 45f;
    private float _defaultRotation = 0f;
    private bool _isActive;
    private Renderer _rend;
    private Color _defaultColor;


    private void Awake()
    {
        _go = this.gameObject;
        _audioSource = _go.GetComponent<AudioSource>();
        _isActive = false;
        _rend = _go.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
    }


    public void Over()
    {
        _IsOver = true;

        // Change logo color (front poly of cube)
        _rend.material.color = Color.cyan;
    }


    public void Out()
    {
        _IsOver = false;

        _rend.material.color = _defaultColor;
    }


    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (_IsOver)
            {
                if (!_isActive)
                {
                    // Activate button
                    _isActive = true;

                    // Play sound
                    _audioSource.Play();

                    // Rotate 45 degrees
                    _go.transform.Rotate(0f, 0f, _activeRotation);
                    // StartCoroutine(RotateCube(_activeRotation));

                    // Change color
                    _rend.material.color = Color.yellow;
                }
                else
                {
                    // Deactivate button
                    _isActive = false;

                    // Stop sound clip
                    _audioSource.Stop();

                    // Rotate back to default rotation
                    _go.transform.Rotate(0f, 0f, -_activeRotation);
                    // StartCoroutine(RotateCube(-_activeRotation);

                    // Change color back to default
                    _rend.material.color = _defaultColor;
                }
            }
            else
            {
                return;
            }
        }   
    }

    // TODO onOver and Fire1, turn button w/ lerp (1 second)
    //private IEnumerator RotateCube(float targetRotation)
    //{
    //    Quaternion rotation = Quaternion.Euler(0f, 0f, targetRotation);

    //    while (_go.transform.rotation != rotation)
    //    {
    //        _go.transform.rotation = Quaternion.Lerp(_go.transform.rotation.z, rotation, rotationSpeed);
    //    }
    //    yield return null;
    //}
}