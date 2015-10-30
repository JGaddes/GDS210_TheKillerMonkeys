using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.W))
         {
             transform.eulerAngles = new Vector3(90, 0, 0);
         }

         if(Input.GetKeyDown(KeyCode.A))
         {
             transform.eulerAngles = new Vector3(90, -90, 0);
         }

         if(Input.GetKeyDown(KeyCode.S))
         {
             transform.eulerAngles = new Vector3(90, 180, 0);
         }

         if(Input.GetKeyDown(KeyCode.D))
         {
             transform.eulerAngles = new Vector3(90, 90, 0);
         }
    }
}