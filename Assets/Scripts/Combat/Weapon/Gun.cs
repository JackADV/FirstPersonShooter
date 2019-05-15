using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public int maxReserve = 300, maxClip = 30;
    public float spread = 2f, recoil = 1f;
    public Transform shotOrigin;
    public GameObject projectilePrefab;

    private int currentReserve = 0, currentClip = 0;

    void Start()
    {
        Reload();
    }

    
    public void Reload()
    {
        // If there is ammo in reserve
        if (currentReserve > 0)
        {
            // If reserve is greater than max clip
            if (currentReserve >= maxClip)
            {
                int difference = maxClip - currentClip;
                currentReserve -= difference;
                // Replenish entire clip with max ammo
                currentClip = maxClip;

                // if clip is lower than max clip size
            }
            if (currentReserve < maxClip)
            {
                // Set entire clip to reserve
                currentClip += currentReserve;
                currentReserve -= currentReserve;
            }
        // If clip < max clip
        }
    }

    public override void Attack()
    {
        // Attack logic
        // Reduce the clip
        currentClip--; // CurrentClip = currentClip -1 / currentClip -= 1
        // get origin + direton for bullet
        Camera attachedCamera = Camera.main;
        Transform camTransform = attachedCamera.transform;
        Vector3 lineOrigin = shotOrigin.position;
        Vector3 direction = camTransform.forward;
        // Spawn Bullet
        GameObject clone = Instantiate(projectilePrefab, camTransform.position, camTransform.rotation);
        Projectile projectile = clone.GetComponent<Projectile>();
        projectile.Fire(lineOrigin, direction);

        base.Attack();
    }
}
