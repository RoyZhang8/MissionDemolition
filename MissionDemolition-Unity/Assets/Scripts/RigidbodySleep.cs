/****
 * Created by: Ruoyu Zhang
 * Data Created: Feb 16, 2022
 * 
 * Last Edited by: Feb 16, 2022
 * Last Edited: Feb 16, 2022
 * 
 * Description: RIDIGIDBODY
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null) rb.Sleep();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
