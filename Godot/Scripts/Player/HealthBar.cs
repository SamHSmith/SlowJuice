using Godot;

public class HealthBar : Control {
    
    private TextureProgress _healthBar;
    private TextureProgress _healthBarUnder;
    private Tween _updateTween;

    [Export] private Color _healthyColor = Colors.Green;
    [Export] private Color _cautionColor = Colors.Yellow;
    [Export] private Color _dangerColor = Colors.Red;
    [Export] private float _cautionThreshold = 60f;
    [Export] private float _dangerThreshold = 30f;
    
    public override void _Ready() {
        _healthBar = GetNode<TextureProgress>("HealthBarTexture");
        _healthBarUnder = GetNode<TextureProgress>("HealthBarTextureUnder");
        _updateTween = GetNode<Tween>("UpdateTween");
    }

    private void _on_PlayerStats_HealthChanged(float health, float amountChanged) {
        AssignColor(health);
        
        // Change health bars value
        _healthBar.Value = health;
        _updateTween.InterpolateProperty(_healthBarUnder, "value", _healthBarUnder.Value, 
            health, 0.5f, Tween.TransitionType.Sine, Tween.EaseType.InOut);
        _updateTween.Start();
    }

    private void AssignColor(float health) {
        if (health <= _dangerThreshold) {
            _healthBar.TintProgress = _dangerColor;
        }
        else if (health <= _cautionThreshold) {
            _healthBar.TintProgress = _cautionColor;
        }
        else {
            _healthBar.TintProgress = _healthyColor;
        }
    }
}


