using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootControl : MonoBehaviour
{
    public static shootControl _shootControl;
    public GameObject Projectile;
    [SerializeField]
    [Range(1, 100)]
    private float projectileSpeed;

    //private ParticleSystem _clone_ps;
    

    // Start is called before the first frame update
    void Start()
    {
        if (_shootControl == null)
        {
            _shootControl = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CannonShoot(Transform cannonWeaponPivot)
    {
        
            

        GameObject newBullet = Instantiate(Projectile, cannonWeaponPivot.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(cannonWeaponPivot.position * projectileSpeed, ForceMode2D.Force);
        //_clone_ps = newBullet.GetComponentInChildren<ParticleSystem>();
        //_clone_ps.Play();
        Destroy(newBullet, 2.0f);
    }
}
