
public interface IDamageable
{
    float Health { get; }
    void OnDamagedReceived(float amount);
    void Die();
    bool IsDead();

}