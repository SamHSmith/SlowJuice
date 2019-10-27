using Godot;

public class PlayerStats : Node {
    [Export] public float MaxHealth { get; private set; } = 100;
    [Export] public float CurrentHealth { get; private set; }

    [Signal] public delegate void HealthChanged(float health, float amountChanged);
    [Signal] public delegate void Healed(float health, float amountChanged);
    [Signal] public delegate void DamageTaken(float health, float amountChanged);

    public override void _Ready() {
        CurrentHealth = MaxHealth;
        
        EmitSignal(nameof(HealthChanged), CurrentHealth, 0.0f);
    }

    public void Heal(float amount) {
        var effectiveAmount = Mathf.Min(amount, MaxHealth - CurrentHealth);
        CurrentHealth += effectiveAmount;
        
        EmitSignal(nameof(Healed), CurrentHealth, effectiveAmount);
        EmitSignal(nameof(HealthChanged), CurrentHealth, effectiveAmount);
    }

    public void TakeDamage(float amount) {
        var effectiveAmount = Mathf.Min(amount, CurrentHealth);
        CurrentHealth += -effectiveAmount;

        EmitSignal(nameof(DamageTaken), CurrentHealth, effectiveAmount);
        EmitSignal(nameof(HealthChanged), CurrentHealth, effectiveAmount);
    }
}