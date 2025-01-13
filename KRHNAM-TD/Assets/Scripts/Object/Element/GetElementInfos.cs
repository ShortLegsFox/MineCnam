public class GetElementInfos
{
    public Element GetWeakness(Element element)
    {
        int strength;

        strength = ((int)element - 1) + 5 % 4;

        return (Element)strength;
    }

    public Element GetStrength(Element element)
    {
        int strength;

        strength = ((int)element + 1) + 5 % 4;

        return (Element)strength;
    }

    public float AddStrongDamage(float damage)
    {
        return 1.2f*damage;
    }

    public float RemoveWeakDamage(float damage)
    {
        return 0.8f * damage;
    }
}
