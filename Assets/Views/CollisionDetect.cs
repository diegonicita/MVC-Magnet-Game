using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : Elemento
{
    private void OnCollisionEnter(Collision collision)
    {
        
            app.Notify("Collision", this.gameObject, collision);
        
    }
}
