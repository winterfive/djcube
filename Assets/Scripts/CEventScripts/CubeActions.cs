using UnityEngine;

public class CubeActions : MonoBehaviour
{
    private RayCaster _rayCaster;
    private GameObject _this;
    private Renderer _rend;
    private Color _defaultColor;
    private bool _isOver;

    private void Awake()
    {
        _rayCaster = RayCaster.Instance;
        _this = this.gameObject;
        _rend = _this.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
    }

    public void Over()
    {
        _rend.material.color = Color.cyan;
        _this.transform.Rotate(0f, 0f, 45f);
        _isOver = true;
    }

    public void Out()
    {
        // change color
        _rend.material.color = _defaultColor;
        _this.transform.Rotate(0f, 0f, -45f);
        _isOver = false;
    }


    //public float rotationSpeed;
    //public bool isActive;

    //private bool _IsOver;
    //private AudioSource _audioSource;
    //private GameObject _go;
    //private float _activeRotation = 45f;
    //private float _defaultRotation = 0f;
    //private Renderer _rend;
    //private Color _defaultColor;


    //private void Awake()
    //{
    //    _go = this.gameObject;
    //    _audioSource = _go.GetComponent<AudioSource>();
    //    isActive = false;
    //    _rend = _go.GetComponent<Renderer>();
    //    _defaultColor = _rend.material.color;
    //}


    //public void Over()
    //{
    //    _IsOver = true;

    //    // Change logo color (front poly of cube)
    //    _rend.material.color = Color.cyan;
    //}


    //public void Out()
    //{
    //    _IsOver = false;

    //    _rend.material.color = _defaultColor;
    //}


    //public void Update()
    //{
    //    if (Input.GetButton("Fire1"))
    //    {
    //        if (_IsOver)
    //        {
    //            if (!isActive)
    //            {
    //                // Activate button
    //                isActive = true;

    //                // Play sound
    //                _audioSource.Play();

    //                // Rotate 45 degrees
    //                _go.transform.Rotate(0f, 0f, _activeRotation);
    //                // StartCoroutine(RotateCube(_activeRotation));

    //                // Change color
    //                _rend.material.color = Color.yellow;
    //            }
    //            else
    //            {
    //                // Deactivate button
    //                isActive = false;

    //                // Stop sound clip
    //                _audioSource.Stop();

    //                // Rotate back to default rotation
    //                _go.transform.Rotate(0f, 0f, -_activeRotation);
    //                // StartCoroutine(RotateCube(-_activeRotation);

    //                // Change color back to default
    //                _rend.material.color = _defaultColor;
    //            }
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //}

    // TODO onOver and Fire1, turn button w/ lerp (1 second)
    //private IEnumerator RotateCube(float targetRotation)
    //{
    //    Quaternion rotation = Quaternion.Euler(0f, 0f, targetRotation);

    //    while (_go.transform.rotation != rotation)
    //    {
    //        _go.transform.rotation = Quaternion.Lerp(_go.transform.rotation.z, rotation, rotationSpeed);
    //    }
    //    yield return null;
    //}}
}
