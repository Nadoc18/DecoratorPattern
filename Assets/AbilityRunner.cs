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
        currentAbility.Use(gameObject);
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
    void Use(GameObject p_currentObject);
}


public class DelayedDecorator : IAbility
{
    private IAbility wrappedAbility;

    public DelayedDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject p_currentObject)
    {
        wrappedAbility.Use(p_currentObject);
    }
}

public class CoolDownDecorator : IAbility
{
    private IAbility wrappedAbility;
    private bool m_canUseAbility;

    public CoolDownDecorator(IAbility wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject p_currentObject)
    {
        if (m_canUseAbility)
        {
            wrappedAbility.Use(p_currentObject);
            CoolDown();
        }
    }

    private void CoolDown()
    {
        //TODO:  Do CoolDown
        m_canUseAbility = false;
        //At end 
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
