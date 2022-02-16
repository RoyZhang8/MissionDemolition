using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    [Header("Set in Inespector")]

    public GameObject clouSphere;
    public int numberSpheresMin = 6;
    public int numberSphereMax = 10;
    public Vector2 sphereScaleRangeX = new Vector2(4, 8);
    public Vector2 sphereScaleRangeY = new Vector2(3, 4);
    public Vector2 sphereScaleRangeZ = new Vector2(2, 4);
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public float scaleYMin = 2f;

    private List<GameObject> spheres;

    // Start is called before the first frame update
    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(numberSpheresMin, numberSphereMax);

        for(int i = 0; i <num; i++)
        {
            GameObject sp = Instantiate<GameObject>(clouSphere);
            spheres.Add(sp);

            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            // Randomly assign a position
            Vector3 offset = Random.insideUnitSphere;
            offset.x *= sphereOffsetScale.x;
            offset.y *= sphereOffsetScale.y;
            offset.z *= sphereOffsetScale.z;
            spTrans.localPosition = offset;


            //Randomly assign scale
            Vector3 scale = Vector3.one; //reset the scale to 1
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);

            //Adjust the y scale by x distance from the core
            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x); //altered based on how far the cloudsphere is offset from cloud in X direction, the further out x the smaller the y scale.
            scale.y = Mathf.Max(scale.y, scaleYMin);

            spTrans.localScale = scale; //set the scale

        }//end for
    }

    // Update is called once per frame
    void Update()
    {
        //if spacebar is pressed restart clouds
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }//end if (Input.GetKeyDown(KeyCode.Space))
    }

    private void Restart()
    {
        //delete all cloudspheres game objects
        foreach (GameObject sp in spheres)
        {
            Destroy(sp);
        }

        Start(); //run start again
    }//end Restart()
}
