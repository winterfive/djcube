using UnityEngine;

public class RayCaster : SetAsSingleton<RayCaster>
{
    // Manages raycasting from the player's POV

    public float range;
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
            CheckForNewObject();
        }
        else
        {
            if (_currentFoundObject)
            {
                _cubeActions.Out();
                _currentFoundObject = null;
            }
        }
    }

    //  Compares newly found object with previous object
    //  RaycastHit -> void
    public void CheckForNewObject()
    {
        GameObject newObject = _hit.collider.gameObject;

        if (!newObject.Equals(_currentFoundObject))
        {
            _currentFoundObject = newObject;
            _cubeActions = _currentFoundObject.GetComponent<CubeActions>();
            _cubeActions.Over();            
        }
    }
}