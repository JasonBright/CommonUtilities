using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsExtensions 
{
    /// <summary>
    /// Рассчет балистической траектории
    /// Source code: https://answers.unity.com/questions/1362266/calculate-force-needed-to-reach-certain-point-addf-1.html
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Vector3 CalcBallisticVelocityVector(Vector3 source, Vector3 target, float angle){
        Vector3 direction = target - source;                            
        float h = direction.y;                                           
        direction.y = 0;                                               
        float distance = direction.magnitude;                           
        float a = angle * Mathf.Deg2Rad;                                
        direction.y = distance * Mathf.Tan(a);                            
        distance += h/Mathf.Tan(a);                                      
 
        // calculate velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2*a));
        return velocity * direction.normalized;    
    }
}
