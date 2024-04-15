
public class WeaponNames
{
    public static string SWORD = "Sword";
    public static string BROADSWORD = "Broadsword";
    public static string KATANA = "Katana";
    public static string LONGSWORD = "Longsword";
    public static string RAPIER = "Rapier";
    public static string SABRE = "Sabre";
    public static string SCIMITAR = "Scimitar";
    public static string ULFBERHT = "Ulfberht";

    public static string[] AllWeaponNames =
    {
        SWORD,
        BROADSWORD,
        KATANA,
        LONGSWORD,
        RAPIER,
        SABRE,
        SCIMITAR,
        ULFBERHT
    };
    public static int Price(string weaponName)
    {
        return weaponName switch
        {
            "Broadsword" => 600,
            "Katana" => 180,
            "Longsword" => 700,
            "Rapier" => 200,
            "Sabre" => 210,
            "Scimitar" => 250,
            "Ulfberht" => 320,
            "Sword" => 400,
            _ => 0,
        };

    }
    public static float AttackSpeed(string weaponName)
    {
        return weaponName switch
        {
            "Broadsword" => 0.9f,
            "Katana" => 1.5f,
            "Longsword" => 0.8f,
            "Rapier" => 1.7f,
            "Sabre" => 1.4f,
            "Scimitar" => 1.0f,
            "Ulfberht" => 1.2f,
            "Sword" => 1.3f,
            _ => 0f,
        };
    }

    public static float AttackDamage(string weaponName)
    {
        return weaponName switch
        {
            "Broadsword" => 40,
            "Katana" => 16,
            "Longsword" => 44,
            "Rapier" => 14,
            "Sabre" => 17,
            "Scimitar" => 22,
            "Ulfberht" => 25,
            "Sword" => 28,
            _ => (float)0,
        };
    }
}
