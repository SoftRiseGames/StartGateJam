using UnityEngine;



public interface IEntity
{
    public bool Attack(float attackPower, Entity entity, float duration);
    public void Shield(float shieldPower);
    public void TakeDamage(float damage);
    public void Death();
}
