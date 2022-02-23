/****
 * Created by: Ruoyu Zhang
 * Data Created: Feb 11, 2022
 * 
 * Last Edited by: Feb 22, 2022
 * Last Edited: Feb 22, 2022
 * 
 * Description: Create the Rigidbody
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
