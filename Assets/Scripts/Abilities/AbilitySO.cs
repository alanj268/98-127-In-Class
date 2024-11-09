using Unity.VisualScripting;
using UnityEngine;

public abstract class AbilitySO : ScriptableObject
{
    public int ID;
    [SerializeField] protected string abilityAnimationTrigger;
    [SerializeField] protected float cooldown = 1;
    private float cooldownCounter;
    public enum State
    {
        OnCooldown,
        Ready,
        Active
    }

    private State state = State.Ready;

    public void SetState(State newState)
    {
        state = newState;
    }

    public virtual bool CanCast()
    {
        return state == State.Ready;
    }

    protected abstract bool Cast();

    public bool Activate()
    {
        if (!CanCast() || !Cast())
            return false;

        state = State.Active;
        return true;
    }

    public void DecreaseCooldown()
    {
        if (state != State.OnCooldown)
            return;

        cooldownCounter -= Time.deltaTime;
        if (cooldownCounter < 0)
        {
            state = State.Ready;
            cooldownCounter = cooldown;
        }
    }
}