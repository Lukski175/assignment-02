namespace Assignment2.Tests;

public class WizardTests
{
    [Fact]
    public void WizardCollection_contains_2_wizards()
    {
        var wizards = WizardCollection.Create();

        Assert.Equal(12, wizards.Count());
    }

    [Theory]
    [InlineData("Darth Vader", "Star Wars", 1977, "George Lucas")]
    [InlineData("Sauron", "The Fellowship of the Ring", 1954, "J.R.R. Tolkien")]
    public void Spot_check_wizards(string name, string medium, int year, string creator)
    {
        var wizards = WizardCollection.Create();

        Assert.Contains(wizards, w => w == new Wizard(name, medium, year, creator));
    }

    [Fact]
    public void RowlingWizards()
    {
        var wizards = WizardCollection.Create();
        var rowling1 = Queries.RowlingWizardsLinq(wizards);
        var rowling2 = Queries.RowlingWizards(wizards);

        var expected = new[] { "Harry Potter" };

        Assert.Equal(expected, rowling1);
        Assert.Equal(expected, rowling2);
    }

    [Fact]
    public void FirstSithLord()
    {
        var wizards = WizardCollection.Create();
        var sith1 = Queries.TheYearOfTheFirstSithLordLinq(wizards);
        var sith2 = Queries.TheYearOfTheFirstSithLord(wizards);

        var expected = 1977;

        Assert.Equal(expected, sith1);
        Assert.Equal(expected, sith2);
    }

    [Fact]
    public void HarryPotterWizards()
    {
        var wizards = WizardCollection.Create();
        var harry1 = Queries.HarryWizardsLinq(wizards);
        var harry2 = Queries.HarryWizards(wizards);

        var expected = new(string, int?)[] {("Harry Potter", 2010)};

        Assert.Equal(expected, harry1);
        Assert.Equal(expected, harry2);
    }

    [Fact]
    public void GroupedWizards()
    {
        var wizards = WizardCollection.Create();
        var group1 = Queries.WizardsGroupLinq(wizards);
        var group2 = Queries.WizardsGroup(wizards);

        var expected = new[] { "The Time Wizard", "Spider-man", "Gandalf", "Sauron", "Harry Potter", "Wizard 1", "Wizard 2", "Wizard 3", "Wizard 4", "Wizard 5", "Wizard 6", "Darth Vader" };

        Assert.Equal(expected, group1);
        Assert.Equal(expected, group2);
    }
}

