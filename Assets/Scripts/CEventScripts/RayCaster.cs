using UnityEngine;

public class RayCaster : SetAsSingleton<RayCaster> {
    // Manages raycasting from the player's POV

    public float range = 100f;
    public int layerMask;
    
    private GameObject _currentFoundObject;
    private RaycastHit _hit;
    private CubeActions _cubeActions;
    private int _layerMask;


    private void Start()
    {
        _currentFoundObject = null;
        _layerMask = 1 << 8;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, range, _layerMask))
        {
            CheckForNewObject(_hit);
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
            if (_currentFoundObject != null)
            {
                _cubeActions.Out();
            }

            _currentFoundObject = newObject;

            _cubeActions = _currentFoundObject.GetComponent<CubeActions>();
            _cubeActions.Over();
        }
    }
}