using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apples : MonoBehaviour, IEatable, IInteractable
{

    int HealthValueOfApple = 5;
    Player p;

    public string TextInfo { get; set; }
 

    private void Awake()
    {

        p = FindObjectOfType<Player>().GetComponent<Player>();
        TextInfo = "YE";
    }

    public void AddHealth()
    {

        p.Health += HealthValueOfApple;
        UIManager.Instance.UpdateHealthAmount(p.Health);

    }

    
    public void InteractItem()
    {

        AddHealth();

    }
    
} 

