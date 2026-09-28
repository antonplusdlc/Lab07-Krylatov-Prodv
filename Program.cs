// потому что ChangeName изменяет обьект снаружи переданного по ссылке (по значению) Hero, а ReplaceHero может изменить только локальную копию ссылки

// in передает readonly ссылку. мы не можем так просто value = 10, компилятор запретит.

void DoubleValue(ref int number) {
    number = number * 2;
}

int x = 5;
DoubleValue(ref x);
Console.WriteLine(x); // 10 — изменилось

void Swap(ref int a1, ref int a2)
{
    int da = a1;
    a1 = a2;
    a2 = da;
}

int a = 1;
int b = 2;
int c = 55;
int d = 0;

Swap(ref a, ref b);
Swap(ref c, ref d);

Console.WriteLine($"{a} {b}\n{c} {d}");

// потому-что передается по значению. то есть копии.

bool TryDivide(int a, int b, out int result) {
    if (b == 0)
    {
        result = 0;
        return false;
    }

    result = a / b;
    return true;
}

bool test1 = TryDivide(5, 0, out int result1);
bool test2 = TryDivide(5, 5, out int result2);

Console.WriteLine($"{test1} {result1}\n{test2} {result2}");

bool TryDivideOstatok(int a, int b, out int chastnoe, out int ostatok)
{
    if (b == 0)
    {
        chastnoe = 0;
        ostatok = 0;
        return false;
    }

    chastnoe = a / b;
    ostatok = a % b;

    return true;
}

bool test3 = TryDivideOstatok(17, 5, out int result3, out int result4);

Console.WriteLine($"{test3}\n{result3} {result4}");

void PrintStats(in CharacterStats stats) {
    Console.WriteLine($"HP: {stats.Health}");
    Console.WriteLine($"Урон: {stats.Damage}");
    Console.WriteLine($"Броня: {stats.Armor}");
    Console.WriteLine($"Name: {stats.Name}");
}

void FormatCharacter(string name, int health, int damage = 0, int armor = 0)
{
    Console.WriteLine($"name: {name}");
    Console.WriteLine($"health: {health}");
    Console.WriteLine($"damage: {damage}");
    Console.WriteLine($"armor: {armor}");
}

CharacterStats character = new CharacterStats();

PrintStats(character);

Console.WriteLine();

FormatCharacter("da", 100);
Console.WriteLine();
FormatCharacter("da1", 50, armor: 100);
Console.WriteLine();
FormatCharacter(armor: 60, health: 40, name: "da2", damage: 90);

// ref даст нам изменить переменную из вне
void FullHealth(ref int health)
{
    health = 100;
}

// ._.
int CalculateDamage(int damage)
{
    return damage + 50; // bounska
}

// ну out ибо нам надо вернуть сразу два результата
bool TryUseSkill(int damage, out int newDamage)
{
    if (damage == 0)
    {
        newDamage = 0;
        return false;
    }

    newDamage = damage * 2;

    return true;
}

// in ибо нам надо readonly а также сразу необязательный параметр настроек вывода
void CharacterStat(in CharacterStats stats, bool isDetailed = false) {
    Console.WriteLine($"detailed: {isDetailed}");

    if (isDetailed)
    {
        Console.WriteLine($"HP: {stats.Health}");
        Console.WriteLine($"Урон: {stats.Damage}");
        Console.WriteLine($"Броня: {stats.Armor}");
        Console.WriteLine($"Name: {stats.Name}");
    }
}

Console.WriteLine();

CharacterStats stat = new CharacterStats {Name = "da", Health = 40, Armor = 50, Damage = 70};

FullHealth(ref stat.Health);
Console.WriteLine(stat.Health);

int newDmg = CalculateDamage(stat.Damage);
Console.WriteLine(newDmg);

if (TryUseSkill(stat.Damage, out int newDamage))
{
    Console.WriteLine(newDamage);
}
else
{
    Console.WriteLine("damage = 0!");
}

CharacterStat(in stat);
CharacterStat(isDetailed: true, stats: in stat);

struct CharacterStats {
    public string Name;
    public int Health;
    public int Damage;
    public int Armor;
}