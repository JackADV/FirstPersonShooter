using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public Transform healthBarparent; // Refers to empty canvas element
    public GameObject healthBarUiPrefab; // Healthbar prefab to spawn
    public Transform healthBarPoint; // refers to transform for following the health bar

    private int health = 0;
    private Slider healthSlider;
    private Renderer rend;
    void Start()
    {
        // Spawn a new healthbar before the first frame update
        GameObject clone = Instantiate(healthBarUiPrefab, healthBarparent);
        // get slider component form new healthbar
        healthSlider = clone.GetComponent<Slider>();
        // Set mhealth to max health
        health = maxHealth;
        rend = GetComponent<Renderer>();
    }
    void OnDestroy()
    {
        if (healthSlider)
        {
            Destroy(healthSlider.gameObject); // Destroys the healthbar when the enemy is destroyed
        }
    }
        
    // Update is called once per frame
    void LateUpdate()
    {
        // healthSlider.gameObject.SetActive(rend.isVisible);
        // Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
        // healthSlider.transform.position = screenPosition;

        // or

        // If the renderer (enemy) is visible
        if (rend.isVisible)
        {
            healthSlider.gameObject.SetActive(true);
            // Update position of healthbar with enemy
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(healthBarPoint.position);
            healthSlider.transform.position = screenPosition;
        }
        else
        {
            // deactivate the healthbar
            healthSlider.gameObject.SetActive(false);
        }
        
    }

    public void TakeDamage(int damage)
    {
        // Reduce health with damage
        health -= damage;
        healthSlider.value = (float)health / (float)maxHealth;
        // if health reaches zero
        if(health < 0)
        {
            // Destroy the gameobject
            Destroy(gameObject);
        }

    }
}
