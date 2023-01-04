using UnityEngine;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentAbility = new FireballAbility();
            UseAbility();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // wait time and active RageAbility
            currentAbility = new DelayedDecorator(new RageAbility());
            UseAbility();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            // If the cool down is reloaded you can active Heal Ability
            currentAbility = new CoolDownDecorator ( new HealAbility());
            UseAbility();
        }
    }


    public void UseAbility()
    {
        currentAbility.Use();
    }

}
