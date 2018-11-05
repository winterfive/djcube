using UnityEngine;

public class CubeActions : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationDegrees;

    private RayCaster _rayCaster;
    private GameObject _this;
    private Renderer _rend;
    private Color _defaultColor;
    private bool _isOver;
    private AudioSource _audio;

    private void Awake()
    {
        _rayCaster = RayCaster.Instance;
        _this = this.gameObject;
        _rend = _this.GetComponent<Renderer>();
        _defaultColor = _rend.material.color;
        _audio = _this.GetComponent<AudioSource>();
    }

    public void Over()
    {
        _rend.material.color = Color.cyan;
        _this.transform.Rotate(0f, 0f, rotationDegrees);
        _isOver = true;
    }

    public void Out()
    {
        _rend.material.color = _defaultColor;
        _this.transform.Rotate(0f, 0f, -rotationDegrees);
        _isOver = false;
    }


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
