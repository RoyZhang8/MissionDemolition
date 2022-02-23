/****
 * Created by: Ruoyu Zhang
 * Data Created: Feb 11, 2022
 * 
 * Last Edited by: Feb 22, 2022
 * Last Edited: Feb 22, 2022
 * 
 * Description: Create the goal of the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // A static field accessible by code anywhere
    static public bool goalMet = false;
    void OnTriggerEnter(Collider other)
    {
        // When the trigger is hit by something
        // Check to see if it's a Projectile
        if (other.gameObject.tag == "Projectile")
        {
            // If so, set goalMet to true
            Goal.goalMet = true;
            // Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
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
