
List<TeamMember> teamMembers = new List<TeamMember>(){
    new TeamMember() {Name = "Dirty Harry", SkillLevel = 5, CourageFactor = 1.2},
    new TeamMember() {Name = "Mean Joe", SkillLevel = 100, CourageFactor = 2},
    new TeamMember() { Name = "Slick Rick", SkillLevel = 45, CourageFactor = 1.8 },
    new TeamMember() { Name = "Silent Sam", SkillLevel = 32, CourageFactor = 1.1 },
    new TeamMember() { Name = "Noisy Nora", SkillLevel = 27, CourageFactor = 0.9 },
    new TeamMember() { Name = "Greasy Greg", SkillLevel = 39, CourageFactor = 1.5 },
    new TeamMember() { Name = "Fast Fiona", SkillLevel = 50, CourageFactor = 1.3 },
    new TeamMember() { Name = "Big Bertha", SkillLevel = 22, CourageFactor = 0.7 },
    new TeamMember() { Name = "Crazy Carl", SkillLevel = 48, CourageFactor = 2.0 },
    new TeamMember() { Name = "Jumpin' Jerry", SkillLevel = 41, CourageFactor = 1.0 },
    new TeamMember() { Name = "Lucky Lucy", SkillLevel = 35, CourageFactor = 1.9 },
    new TeamMember() { Name = "Danger Dave", SkillLevel = 29, CourageFactor = 1.4 }

};

Console.WriteLine("Plan Your Heist!");

string choice = null;

while (choice != "4")
{
    DisplayMenu();



    choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayMembers(teamMembers);
    }
    if (choice == "2")
    {
        AddTeamMembers(teamMembers);
    }
    if (choice == "3")
    {
        BankHeists(teamMembers);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Goodbye!");
    }

}

void DisplayMenu()
{
    Console.WriteLine(@"Choose an option
    1. Display Team Members
    2. Add Team Members
    3. Bank Heist
    4. Exit");
}

void AddTeamMembers(List<TeamMember> teamMembers)
{

    string name = null;
    while (name != "")
    {
        Console.WriteLine("Please enter the new member's name.");
        name = Console.ReadLine();
        if (name == "")
        {
            break;
        }

        Console.WriteLine("Provide Skill Level of member.");
        string skillLevel = Console.ReadLine();

        Console.WriteLine("Provide the member's courage factor.");
        string courageFactor = Console.ReadLine();

        teamMembers.Add(new TeamMember() { Name = name, SkillLevel = int.Parse(skillLevel), CourageFactor = double.Parse(courageFactor) });

        DisplayMembers(teamMembers);
    }

}

void DisplayMembers(List<TeamMember> teamMembers)
{
    foreach (TeamMember teamMember in teamMembers)
    {
        Console.WriteLine($@"{teamMember.Name} has a skill level of {teamMember.SkillLevel} 
        and a courage factor of {teamMember.CourageFactor}.");
    }
}

void BankHeists(List<TeamMember> teamMembers)
{
    Console.WriteLine("Enter bank difficulty level (integer):");
    string difficulty = Console.ReadLine();
    Console.WriteLine("Enter number of trial runs.");
    string trialRuns = Console.ReadLine();
    int totalSkillLevel = 0;
    List<TeamMember> wiseGuys = new List<TeamMember>();
    List<TeamMember> chickens = new List<TeamMember>();
    foreach (TeamMember wiseGuy in teamMembers)
    {
        if (wiseGuy.SkillLevel * wiseGuy.CourageFactor > int.Parse(difficulty))
        {
            wiseGuys.Add(wiseGuy);
        }
        else
        {
            chickens.Add(wiseGuy);
        }
    }
    foreach (TeamMember teamMember in wiseGuys)
    {
        totalSkillLevel += teamMember.SkillLevel;
    }
    int successNum = 0;
    int failureNum = 0;
    Console.WriteLine("The following team members have chickened out!");
    foreach (TeamMember chicken in chickens)
    {
        Console.WriteLine($"-{chicken.Name}");
    }
    for (int i = 1; i <= int.Parse(trialRuns); i++)
    {
        Random random = new Random();
        int luckValue = random.Next(-10, 11);
        int totalDifficulty = int.Parse(difficulty) + luckValue;

        if (totalSkillLevel >= totalDifficulty)
        {
            Console.WriteLine($"Team skill: {totalSkillLevel}.");
            Console.WriteLine($"Bank difficulty : {totalDifficulty}.");
            Console.WriteLine("You have successfully robbed the bank!");
            successNum++;
        }
        else
        {
            Console.WriteLine($"Team skill: {totalSkillLevel}.");
            Console.WriteLine($"Bank difficulty : {totalDifficulty}.");
            Console.WriteLine("You have failed to rob the bank. :(");
            failureNum++;
        }
    }
    Console.WriteLine($"You had {successNum} success(es).");
    Console.WriteLine($"You had {failureNum} failure(s).");
}