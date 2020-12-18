using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IUsable, IInteractable
{
    
    HingeJoint Joint;
    JointLimits MinAngle;
    Quaternion rotationValues;
    public string TextInfo { get; set; }

    float Speed = 0.5f;
    
    private void Awake()
    {

        Joint = this.GetComponent<HingeJoint>();
        MinAngle = Joint.limits;
        rotationValues = transform.rotation;
        TextInfo = "AÇ";
       
    }
  
    public void Interact()
    {
        rotationValues.y = -90;
        MinAngle.min = -90;
        Joint.limits = MinAngle;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationValues, Speed);


    }

    public void InteractItem()
    {

        Interact();
        
    }

}
