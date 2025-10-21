
using BirthCertificate.Services;

BabyService babyService = new BabyService();
BirthCertificateService bcService = new BirthCertificateService();

while (true)
{
    Console.WriteLine("Main Menu");
    Console.WriteLine("1) Manage Babies");
    Console.WriteLine("2) Manage Birth Certificates");
    Console.WriteLine("Exit");
    Console.WriteLine("Choose an option: ");

    string? choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ManageBabies();
            break;


    }

//----------------------------------------------------------------Manage Baby option-----------------------------------------------------------------------------
    void ManageBabies()
    {
        while (true)
        {
            Console.WriteLine("Babies menu: ");
            Console.WriteLine("1) Create Baby");
            Console.WriteLine("2) List Of Babies");
            Console.WriteLine("3) Update Baby");
            Console.WriteLine("4) Delete Baby");
            Console.WriteLine("0) Back");

            string? choice2 = Console.ReadLine();

            switch (choice2)
            {
                case "1":
                    CreateBaby();
                    break;
                case "2":
                    babyService.ListOfBabies();
                    break;
                case "3":
                    babyService.UpdateBabies();
                    break;
                
            }
        }
    }

//--------------------------------------------------------------Create Baby---------------------------------------------
    void CreateBaby()
    {
        Console.WriteLine("Create new Baby");
        try
        {
            Console.Write("Enter babies ID: ");
            long id = long.Parse(Console.ReadLine()!);

            Console.Write("Enter babies Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter babies Middle name: ");
            string? middlename = Console.ReadLine();

            Console.Write("Enter babies Nationality: ");
            string? nationality = Console.ReadLine();

            Console.Write("Enter babies Gender: ");
            string? gender = Console.ReadLine();

            Console.Write("Enter babies Place of Birth: ");
            string? placeOfBirth = Console.ReadLine();

            Console.Write("Enter babies Date of Birth DD.MM.YYYY: ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine()!);
            babyService.AddBaby(id, name, middlename, nationality, gender, placeOfBirth, dateOfBirth);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
