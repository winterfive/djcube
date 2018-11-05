using UnityEngine;

public class RayCaster : SetAsSingleton<RayCaster> {
    // Manages raycasting from the player's POV

    public float range = 100f;

    public delegate void NewObjectFound();
    public static event NewObjectFound OnNewObjectFound;
    
    private GameObject _currentFoundObject;
    private GameObject _previousFoundObject;
    private RaycastHit _hit;
    private CubeActions _cubeActions;

    public GameObject GetCurrentFoundObject() { return _currentFoundObject; }


    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, range))
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
            _previousFoundObject = _currentFoundObject;
            _currentFoundObject = newObject;

            _cubeActions = _currentFoundObject.GetComponent<CubeActions>();
            _cubeActions.Over();

            //if (OnNewObjectFound != null)
            //{
            //    OnNewObjectFound();
            //}
        }
    }
}