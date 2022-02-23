/****
 * Created by: Ruoyu Zhang
 * Data Created: Feb 11, 2022
 * 
 * Last Edited by: Feb 22, 2022
 * Last Edited: Feb 22, 2022
 * 
 * Description: Create the Slingshot
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    static public Slingshot S;

    /*** VARIABLES ***/
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultipler = 8f;


    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos; //launch position of projectile
    public GameObject projectile; //instance of projectile
    public bool aimingMode; // is player 
    public Rigidbody projectileRB; // ridigbody of projectile

    static public Vector3 LAUNCH_POS
    {
        get
        {
            if (S == null) return Vector3.zero; //if there is no slingshot, return null
            return S.launchPos; //otherwise return the launchPos
        }
    }

    private void Awake()
    {
        // Set the Slingshot singleton S
        S = this;

        Transform launchPointTrans = transform.Find("LaunchPoint");//find child object

        launchPoint = launchPointTrans.gameObject; //the game object of child object
        launchPoint.SetActive(false);//disable game object
        launchPos = launchPointTrans.position;
    }//end Awake

    private void Update()
    {
        if (!aimingMode) return;

        // get the current mouse position in 2d screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos; //pixel amount of change between the mouse3d and launchPos

        //limit mouseDelta to slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); // sets the vector to the same direction, but length is 1.0
            mouseDelta *= maxMagnitude;
        }// end if(mouseDelta.magnitude > maxMagnitude)

        //move projectile to this new position
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultipler;

            FollowCam.POI = projectile;

            projectile = null; //forget the last instance
            MissionDemolition.ShotFired();

        }

    }// end Update

    private void OnMouseEnter()
    {
        launchPoint.SetActive(true); //enable game  object
        print("Slingshot: OnMouseEnter");

    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false); //disable game object
        print("Slingshot: OnMouseExit");

    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;    // == projectile.GetComponent<Rigidbody>().isKinematic = true;
    }// End mousedown



}
