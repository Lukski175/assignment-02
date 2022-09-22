using Microsoft.VisualBasic;
using System.ComponentModel;

namespace Assignment2;

public class Queries
{
    public static IEnumerable<string> RowlingWizardsLinq(IEnumerable<Wizard> wizards) => wizards.Where(a => a.Creator == "J.K. Rowling").Select(a => a.Name);
    public static IEnumerable<string> RowlingWizards(IEnumerable<Wizard> wizards)
    {
        return (from c in wizards
                where c.Creator == "J.K. Rowling"
                select new
                {
                    Name = c.Name,
                }.Name).ToList();
    }


    public static int? TheYearOfTheFirstSithLordLinq(IEnumerable<Wizard> wizards) => wizards.Where(a => a.Name.Contains("Darth")).OrderBy(a => a.Year).Select(a => a.Year).First();
    public static int? TheYearOfTheFirstSithLord(IEnumerable<Wizard> wizards)
    {
        return (from c in wizards
                where c.Name.Contains("Darth")
                select new
                {
                    Year = c.Year
                }.Year).First();
    }


    public static IEnumerable<(string, int?)> HarryWizardsLinq(IEnumerable<Wizard> wizards) => wizards.Where(a => a.Medium.Contains("Harry Potter")).Select(a => (a.Name, a.Year)).Distinct();
    public static IEnumerable<(string, int?)> HarryWizards(IEnumerable<Wizard> wizards)
    {
        var wiz = (from c in wizards
                   where c.Medium.Contains("Harry Potter")
                   select new
                   {
                       Name = c.Name,
                       Year = c.Year,
                   }).Distinct();

        foreach (var w in wiz)
        {
            yield return (w.Name, w.Year);
        }
    }

    public static IEnumerable<String> WizardsGroupLinq(IEnumerable<Wizard> wizards) => wizards.OrderByDescending(a => a.Creator).ThenBy(a => a.Name).Select(a => a.Name);
    public static IEnumerable<String> WizardsGroup(IEnumerable<Wizard> wizards)
    {
        return (from c in wizards
                orderby c.Name
                orderby c.Creator descending
                select new
                {
                    c.Name,
                }.Name).ToList();
    }
}
