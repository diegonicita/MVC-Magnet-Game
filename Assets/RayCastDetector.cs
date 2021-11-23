using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetector : Elemento
{   
    // Update is called once per frame
    void Update()
    {      
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    app.Notify(hit.transform.gameObject.name, this);

                switch (hit.transform.gameObject.name)
                {
                    case "Cube":
                        Debug.Log("c");
                        break;
                    case "Sphere":
                        Debug.Log("e");
                        break;
                }

                }
            }
        
    }
}
