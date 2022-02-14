using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    /****VARIABLES****/
    static public GameObject POI; //THE STATIC POINT OF INTEREST

    [Header("Set in Inespector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;//desired Z pos of the camera


    private void Awake()
    {
        camZ = this.transform.position.z;//set z
    }//end Awake

    private void FixedUpdate()
    {
        if (POI == null) return; // do nothing if no poi

        Vector3 destination = POI.transform.position;

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //interpolate from current position to desition
        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;

        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
