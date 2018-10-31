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
    private float _originalRotation = 0f;
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

        // Change color to overColor
        _rend.material.color = Color.cyan;
    }


    public void Out()
    {
        _IsOver = false;

        _rend.material.color = _defaultColor;
    }


    public void Click()
    {
        if (_IsOver)
        {
            // play audio clip
            _audioSource.Play();

            // Turn cube 45 degrees
            //StartCoroutine(RotateCube(_activeRotation));
            _go.transform.Rotate(0f, 0f, 45f);

            // begin pulse animation coroutine
            // TODO

            _isActive = true;
        }        
    }

    // WORK ON HERE FIRST
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