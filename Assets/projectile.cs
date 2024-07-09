using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{[SerializeField] private float _offsetx =1f;
    [SerializeField] private float tacticalnuke = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Airstrike();
    }
    void rocketlauncher()
    {
        transform.Translate(Vector2.left * tacticalnuke * Time.deltaTime);
    }
    void Airstrike()
    {
        if(transform.position.x < -9.32)
        {
            Destroy(this.gameObject);
        }
    }
}
