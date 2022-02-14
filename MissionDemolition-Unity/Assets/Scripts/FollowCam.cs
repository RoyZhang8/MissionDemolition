using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    /****VARIABLES****/
    static public GameObject POI; //THE STATIC POINT OF INTEREST


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
