using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("UIManager is null");
            }
            return _instance;
        }
        
    }
    public Text InteractionText;
    public Text PlayerHealthText;
    public Text BulletAmountText;


    private void Awake()
    {

        _instance = this;

    }
  

    public void UpdateHealthAmount(int Health)
    {

        PlayerHealthText.text = "Health:" + " " + Health;

    }

    public void UpdateBulletAmount (int AddedBullet)
    {

        BulletAmountText.text = "Bullet:" + " " + AddedBullet;

    }

}
