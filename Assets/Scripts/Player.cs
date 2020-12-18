using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    float Speed = 10f;
    public int Health = 50;
    public int BulletAmount = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);

        ShowInteractionType();

        var NearestObject = FindInteractedObject();
        if (NearestObject == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            var Interactable = NearestObject.GetComponent<IInteractable>();
            if (Interactable == null) return;
            Interactable.InteractItem();
            
        }
    }

    private GameObject FindInteractedObject()
    {

        GameObject nearObject = null;

        Vector3 ray = transform.TransformDirection(Vector3.forward);
        
        Debug.DrawRay(transform.position, ray * 5, Color.green);
        
        if(Physics.Raycast(transform.position, ray, out var hit, 5))
        {
            nearObject = hit.transform.gameObject;
        }
        return nearObject;
    }

    void ShowInteractionType() 
    {

        var nearObject = FindInteractedObject();
        if (nearObject == null) return;
        var text = nearObject.GetComponent<IInteractable>().TextInfo;

        UIManager.Instance.InteractionText.text = text;
        UIManager.Instance.InteractionText.gameObject.SetActive(true);
    }
}
