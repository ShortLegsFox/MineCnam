public static class GetElementInfos
{
    public static Element GetWeakness(Element element)
    {
        int strength;

        strength = ((int)element - 1) + 5 % 4;

        return (Element)strength;
    }

    public static Element GetStrength(Element element)
    {
        int strength;

        strength = ((int)element + 1) + 5 % 4;

        return (Element)strength;
    }

    public static float AddStrongDamage(float damage)
    {
        return 1.2f * damage;
    }

    public static float RemoveWeakDamage(float damage)
    {
        return 0.8f * damage;
    }

    public static Effect GetEffect(Element element, EffectData effectData)
    {
        switch (element)
        {
            case Element.Water:
                return new Slow(5.0f, effectData);
            case Element.Fire:
                return new Burn(5.0f, effectData);
            default:
                return null;
        }
    }
}
