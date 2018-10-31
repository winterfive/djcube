using UnityEngine;

public class RaycastManager : SetAsSingleton<RaycastManager>
{
    // Manages raycasting from the player's POV

    public float range = 100f;

    private RaycastHit _hit;
    private GameObject _currentFoundObject;
    private GameObject _previousFoundObject;
    private Vector3 _currentNormal;

    public GameObject GetCurrentFoundObject() { return _currentFoundObject; }
    public Vector3 GetCurrentNormal() { return _currentNormal; }
    public RaycastHit GetCurrentHit() { return _hit; }


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, range))
        {
            CheckForNewObject(_hit);
        }
        else
        {
            _currentFoundObject = null;
        }
    }

    //  Compares newly found object with previous object
    //  Calls event
    //  RaycastHit -> void
    public void CheckForNewObject(RaycastHit hit)
    {
        GameObject newObject = hit.collider.gameObject;

        if (!newObject.Equals(_currentFoundObject))
        {
            _previousFoundObject = _currentFoundObject;
            // Set _previousFoundObject isActive to false
            _currentFoundObject = newObject;
        }
    }
}