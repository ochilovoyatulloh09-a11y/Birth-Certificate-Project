using System.Net;
using BirthCertificate.Entities;

namespace BirthCertificate.Services;

public class BabyService
{
   private readonly string filePath;

   public BabyService()
   {
      string dataFolder =
         "C:\\Users\\OyatulloLaptop\\Desktop\\Birth-Certificate-Project\\ConsoleApp2\\Birth-Certificate-Project\\TextFiles";
      if (!Directory.Exists(dataFolder))
      {
         Directory.CreateDirectory(dataFolder);
      }

      filePath = Path.Combine(dataFolder, "Baby.txt");
   }

   public void AddBaby(long id, string? name, string? middlename, string? nationality, string? gender,
      string? placeOfBirth, DateTime dateOfBirth)
   {
      Baby baby = new Baby()
      {
         Id = id,
         Name = name,
         MiddleName = middlename,
         Nationality = nationality,
         Gender = gender,
         PlaceOfBirth = placeOfBirth,
         DateOfBirth = dateOfBirth
      };
      string line =
         $"{baby.Id} | {baby.Name} | {baby.MiddleName} | {baby.Nationality} | {baby.Gender} | {baby.PlaceOfBirth} | {baby.DateOfBirth}";
      File.AppendAllText(filePath, line + Environment.NewLine);
      Console.WriteLine("Baby saved successfully.");
   }

   public void ListOfBabies()
   {
      if (!File.Exists(filePath))
      {
         Console.WriteLine("No babies found");
         return;
      }

      string[] lines = File.ReadAllLines(filePath);
      if (lines.Length == 0)
      {
         Console.WriteLine("No babies available");
      }

      Console.WriteLine("ID:\tName:\tMiddle Name:\tNationality:\tGender:\tPlace of Birth:\tDate of Birth:");
      foreach (var line in lines)
      {
         string[] parts = line.Split('|');
         if (parts.Length == 7)
         {
            Console.WriteLine(
               $"{parts[0]}\t{parts[1]}\t{parts[2]}\t\t{parts[3]}\t\t{parts[4]}\t{parts[5]}\t\t{parts[6]}");
         }
      }
   }

   public void UpdateBabies()
   {
      string[] lines = File.ReadAllLines(filePath);
      if (lines.Length == 0)
      {
         Console.WriteLine("No baby available.");
      }

      Console.WriteLine("Enter baby ID to update: ");
      string? inputId = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(inputId))
      {
         Console.WriteLine("Invalid ID");
         return;
      }

      long id = long.Parse(inputId);
      bool found = false;

      for (int i = 0; i < lines.Length; i++)
      {
         string[] parts = lines[i].Split('|');
         if (parts.Length < 6)
         {
            continue;
         }

         if (long.Parse(parts[0]) == id)
         {
            found = true;
            Console.WriteLine($"\nEditing baby: {parts[1]} (ID: {parts[0]})");
            Console.WriteLine("Press ENTER to keep the current value.\n");

            Console.Write($"Name ({parts[1]}): ");
            string? name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
               parts[1] = name;

            Console.Write($"Date of Birth ({parts[2]}): ");
            string? dob = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dob))
               parts[2] = dob;

            Console.Write($"Gender ({parts[3]}): ");
            string? gender = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(gender))
               parts[3] = gender;

            Console.Write($"Place of Birth ({parts[4]}): ");
            string? place = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(place))
               parts[4] = place;

            Console.Write($"Hospital Note Number ({parts[5]}): ");
            string? note = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(note))
               parts[5] = note;
            
            lines[i] = string.Join("|", parts);
            break;
         }
      }
      if (found)
      {
         File.WriteAllLines(filePath, lines);
         Console.WriteLine("\nBaby information updated successfully!");
      }
      else
      {
         Console.WriteLine("Baby with this ID not found.");
      }
   }
}
   
 
