using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerScript ps;
    public Slider slider;
    public int health, currentHealth;


    void Start()
    {
        ps = GameObject.Find("/Player").GetComponent<PlayerScript>();
        currentHealth = ps.health;
    }

    void Update()
    {
        health = ps.health;
        if(currentHealth > health)
        {
            TakeDamage();
        }
        if(currentHealth < health)
        {
            StartCoroutine(HealthHeal());
        }
    }

    private void TakeDamage()
    {
        StartCoroutine(TakeDamageT());
    }

    private IEnumerator TakeDamageT()
    {
        for(int i = currentHealth; health < currentHealth; i --)
        {
        yield return new WaitForSeconds(0.03f);
        slider.value = i;
        currentHealth = i;
        }
        currentHealth = health;
    }
    public IEnumerator HealthHeal()
    {
        for(int i = currentHealth; health > currentHealth; i++)
        {
            yield return new WaitForSeconds(0.03f);
            slider.value = i;
            currentHealth = i;
        }
        currentHealth = health;
    }

}