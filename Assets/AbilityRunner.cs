using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = new DelayedDecorator( new RageAbility());

    public void UseAbility()
    {
        //You can pass SFX VFX by Parameters for example 
        currentAbility.Use();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentAbility = new CoolDownDecorator(new FireballAbility());
        }
    }
}

public interface IAbility
{
    void Use();
}


public class DelayedDecorator : MonoBehaviour, IAbility
{
    private IAbility wrappedAbility;
    private float delayTime = 2f;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use()
    {
        StartCoroutine(UseWithDelay(wrappedAbility));  
    }
    private IEnumerator UseWithDelay(IAbility wrappedAbility)
    {
        yield return new WaitForSeconds(delayTime);
        wrappedAbility.Use();
    }
}

public class CoolDownDecorator : MonoBehaviour, IAbility
{
    private IAbility wrappedAbility;
    private bool m_canUseAbility;
    private float timeToReload;

    public CoolDownDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use()
    {
        if (m_canUseAbility)
        {
            wrappedAbility.Use();
            m_canUseAbility = false;
            CoolDown();
        }
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(timeToReload);
        m_canUseAbility = true;
    }
}

public class RageAbility : IAbility
{
    public void Use()
    {
        Debug.Log("Do Rage ability");
    }

    public void Use(GameObject p_currentObject)
    {
        throw new System.NotImplementedException();
    }
}

public class FireballAbility : IAbility
{
    public void Use()
    {
        Debug.Log("Do Fireball Ability");
    }

    public void Use(GameObject p_currentObject)
    {
        throw new System.NotImplementedException();
    }
}

public class HealAbility : IAbility
{
    public void Use()
    {
        Debug.Log("Do Heal Ability");
    }

    public void Use(GameObject p_currentObject)
    {
        throw new System.NotImplementedException();
    }
}
