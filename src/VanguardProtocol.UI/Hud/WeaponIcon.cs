namespace VanguardProtocol.UI.Hud;

public sealed class WeaponIcon
{
    public float Value { get; private set; }
    public float DisplayValue { get; private set; }
    public float Max { get; set; } = 100f;
    public void SetImmediate(float value) { Value = Math.Clamp(value, 0f, Max); DisplayValue = Value; }
    public void SetTarget(float value) => Value = Math.Clamp(value, 0f, Max);
    public void Tick(float dt)
    {
        var speed = 80f * dt;
        if (DisplayValue < Value) DisplayValue = MathF.Min(Value, DisplayValue + speed);
        else if (DisplayValue > Value) DisplayValue = MathF.Max(Value, DisplayValue - speed);
    }
    public float Normalized => Max <= 0 ? 0 : DisplayValue / Max;
}
