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
}
