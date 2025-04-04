namespace SlittingDashboard.Data.Constants;

public static class CommentMenus
{
    // Updated Issues array
    public static readonly string[] Issues = new[]
    {
        "Postal Orders",
        "PTO",
        "Multiple lot",
        "Split Shift",
        "Operator working alone",
        "Part time",
        "Waiting for forklift driver",
        "Machine down",
        "Working on difficult orders",
        "Light duty",
        "Waiting for material ( pulling)",
        "Early leaving",
        "Stack job",
        "Operator supporting other slitter",
        "New operator in training",
        "Crane down",
        "Waiting for Crane",
        "Help with shop inspection",
        "Transfer Orders",
        "Re-measure belts",
        "Combo Job",
        "Multiple cut",
        "Fork lift classes",
        "Change blades",
        "Others- Minor accident"
    };

    public static readonly int[] SlitterNumbers =
{
    1, 2, 3, 4, 5, 6,7,8,9,10
};

    public static readonly string[] Shifts =
{
    "1st Shift",
    "2nd Shift",
    // "3rd Shift" (if applicable)
};

    public static readonly string[] TeamLeads =
    {
    "Eden Gebremaryam",
    "Sam Xiong"
};

    public static readonly string[] Supervisors =
    {
    "Anthony Carter",
    "Eden Gebremaryam",
    "Hikmeta Smajlovic"
};

    public static readonly string[] Operators =
{
    "Alexander Romero",
    "Anthony Watson",
    "Basile Bi Goa",
    "Benjamin Nkansah",
    "Calvin Evans",
    "Clement Kouadio",
    "Daniel Okafor",
    "Doa Her",
    "Drew Clay",
    "Ean Evans",
    "Eduardo Medina",
    "Elmer Soriano",
    "Jackson Hayes",
    "Fazli Bayramov",
    "Francisco Marchan",
    "Gregory C Jordan",
    "Herolind Berisha",
    "Jackson Hayes",
    "Johnnie Mosley",
    "Jonathan Pruett",
    "Luis Lucena",
    "Momcilo Petricevic",
    "Patrick Agyekum",
    "Paul Palmer-Buckle",
    "Sanjay R Valles",
    "Sanjay R Valluru",
    "Vezele Wolobah"
};

    public static readonly TimeOnly[] HourBlocks =
{
    new(8,0), new(9,0), new(10,0), new(11,0),
    new(12,0), new(14,0), new(15,0)
};
}