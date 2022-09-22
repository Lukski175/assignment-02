//foreach (var wizard in WizardCollection.Create())
//{
//    Console.WriteLine(wizard);
//}

//int[] ys = { 1, 5, 7, 42, 49, 56 };
//something(ys).ToList().ForEach(Console.WriteLine);
int[] ys = new[] { 2000, 2001, 2004, 1800, 1804, 1700, 1600, 1604 };
leaps(ys).ToList().ForEach(Console.WriteLine);

static int[] something(int[] ys)
{
    return ys.Where(a => a % 7 == 0).Where(a => a > 42).ToArray();
}

static int[] leaps(int[] ys)
{
    return ys.Where(a => a % 4 == 0).Where(a => a % 100 == 0 ? a % 400 == 0 : true).ToArray();
}