using System;
using System.Collections.Generic;
using System.Linq;

class Wallet
{
    private double balance;
    private Dictionary<string, string> personalInfo;
    private List<string> creditCards;
    private List<Dictionary<string, string>> businessCards;
    private List<string> photos;

    public Wallet()
    {
        balance = 0;
        personalInfo = new Dictionary<string, string>();
        creditCards = new List<string>();
        businessCards = new List<Dictionary<string, string>>();
        photos = new List<string>();
    }

    public void AddMoney(double amount)
    {
        balance += amount;
        Console.WriteLine($"{amount} Ar added to the wallet. New balance: {balance} Ar");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Current balance: {balance} Ar");
    }

    public void DisplayPersonalInfo()
    {
        if (personalInfo.Count > 0)
        {
            Console.WriteLine("Personal information:");
            foreach (var entry in personalInfo)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
        else
        {
            Console.WriteLine("No personal information available.");
        }
    }

    public void AddCreditCard(string card)
    {
        creditCards.Add(card);
        Console.WriteLine("Credit card added successfully.");
    }

    public void AddBusinessCard(Dictionary<string, string> cardInfo)
    {
        Dictionary<string, string> businessCard = new Dictionary<string, string>();
        Console.WriteLine("\nEnter business card information:");
        businessCard["Name"] = Console.ReadLine();
        businessCard["Title"] = Console.ReadLine();
        businessCard["Company"] = Console.ReadLine();
        businessCard["Email"] = Console.ReadLine();
        businessCard["Phone Number"] = Console.ReadLine();

        businessCards.Add(new Dictionary<string, string>(businessCard.Concat(cardInfo)));
        Console.WriteLine("Business card added successfully.");
    }

    public void AddPhoto(string photo)
    {
        photos.Add(photo);
        Console.WriteLine("Photo added successfully.");
    }

    public void DisplayRegisteredCards()
    {
        Console.WriteLine("Registered cards:");
        if (creditCards.Count > 0)
        {
            Console.WriteLine("\nCredit cards:");
            foreach (var card in creditCards)
            {
                Console.WriteLine(card);
            }
        }
        else
        {
            Console.WriteLine("\nNo credit cards registered.");
        }

        if (businessCards.Count > 0)
        {
            Console.WriteLine("\nBusiness cards:");
            foreach (var card in businessCards)
            {
                foreach (var entry in card)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }
        else
        {
            Console.WriteLine("\nNo business cards registered.");
        }
    }

    public void DisplayPhotos()
    {
        Console.WriteLine("Registered photos:");
        if (photos.Count > 0)
        {
            foreach (var photo in photos)
            {
                Console.WriteLine(photo);
            }
        }
        else
        {
            Console.WriteLine("No photos registered.");
        }
    }

    public void WithdrawMoney(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"{amount} Ar withdrawn successfully. New balance: {balance} Ar");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void RemoveCard(string card)
    {
        if (creditCards.Contains(card))
        {
            creditCards.Remove(card);
            Console.WriteLine("Credit card removed successfully.");
        }
        else
        {
            var businessCard = businessCards.Find(b => b["Name"] == card);
            if (businessCard != null)
            {
                businessCards.Remove(businessCard);
                Console.WriteLine("Business card removed successfully.");
            }
            else
            {
                Console.WriteLine("The specified card was not found.");
            }
        }
    }

    public void RemovePhoto(string photo)
    {
        if (photos.Contains(photo))
        {
            photos.Remove(photo);
            Console.WriteLine("Photo removed successfully.");
        }
        else
        {
            Console.WriteLine("The specified photo was not found.");
        }
    }

    public void SearchCard(string card)
    {
        if (creditCards.Contains(card))
        {
            Console.WriteLine("Credit card found.");
        }
        else
        {
            var businessCardFound = businessCards.Any(b => b["Name"] == card);
            if (businessCardFound)
            {
                Console.WriteLine("Business card found.");
            }
            else
            {
                Console.WriteLine("The specified card was not found.");
            }
        }
    }

    public void SearchPhoto(string photo)
    {
        if (photos.Contains(photo))
        {
            Console.WriteLine("Photo found.");
        }
        else
        {
            Console.WriteLine("The specified photo was not found.");
        }
    }

    public void SetPersonalInfo()
    {
        Console.WriteLine("\nEnter your personal information:");
        SetPersonalInfoField("Name");
        SetPersonalInfoField("Address");
        SetPersonalInfoField("Phone Number");
        Console.WriteLine("Personal information set successfully.");
    }

    private void SetPersonalInfoField(string fieldName)
    {
        Console.Write($"{fieldName}: ");
        personalInfo[fieldName] = Console.ReadLine();
    }
}

class Program
{
    static void Main()
    {
        Wallet userWallet = null;

        Console.WriteLine("Welcome to the Wallet Management Program!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new wallet");
            Console.WriteLine("2. Add money");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Display personal information");
            Console.WriteLine("5. Add a credit card");
            Console.WriteLine("6. Add a business card");
            Console.WriteLine("7. Add a photo");
            Console.WriteLine("8. Display registered cards");
            Console.WriteLine("9. Display registered photos");
            Console.WriteLine("10. Withdraw money");
            Console.WriteLine("11. Remove a card");
            Console.WriteLine("12. Remove a photo");
            Console.WriteLine("13. Search for a card");
            Console.WriteLine("14. Search for a photo");
            Console.WriteLine("15. Help/Instructions");
            Console.WriteLine("0. Quit");

            Console.Write("Please choose an option (0-15): ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Thank you for using the program. Goodbye!");
                break;
            }
            else if (choice == "1")
            {
                userWallet = new Wallet();
                userWallet.SetPersonalInfo();
                Console.WriteLine("New wallet created.");
            }
            else if (choice == "2")
            {
                double amount;
                Console.Write("Enter the amount to add (Ar): ");
                if (double.TryParse(Console.ReadLine(), out amount))
                {
                    userWallet.AddMoney(amount);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else if (choice == "3")
            {
                userWallet.CheckBalance();
            }
            else if (choice == "4")
            {
                userWallet.DisplayPersonalInfo();
            }
            else if (choice == "5")
            {
                Console.Write("Enter the credit card number: ");
                userWallet.AddCreditCard(Console.ReadLine());
            }
            else if (choice == "6")
            {
                Dictionary<string, string> businessCardInfo = new Dictionary<string, string>();
                userWallet.AddBusinessCard(businessCardInfo);
            }
            else if (choice == "7")
            {
                Console.Write("Enter the photo name: ");
                userWallet.AddPhoto(Console.ReadLine());
            }
            else if (choice == "8")
            {
                userWallet.DisplayRegisteredCards();
            }
            else if (choice == "9")
            {
                userWallet.DisplayPhotos();
            }
            else if (choice == "10")
            {
                double amount;
                Console.Write("Enter the amount to withdraw (Ar): ");
                if (double.TryParse(Console.ReadLine(), out amount))
                {
                    userWallet.WithdrawMoney(amount);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else if (choice == "11")
            {
                Console.Write("Enter the card number to remove: ");
                userWallet.RemoveCard(Console.ReadLine());
            }
            else if (choice == "12")
            {
                Console.Write("Enter the photo name to remove: ");
                userWallet.RemovePhoto(Console.ReadLine());
            }
            else if (choice == "13")
            {
                Console.Write("Enter the card number to search: ");
                userWallet.SearchCard(Console.ReadLine());
            }
            else if (choice == "14")
            {
                Console.Write("Enter the photo name to search: ");
                userWallet.SearchPhoto(Console.ReadLine());
            }
            else if (choice == "15")
            {
                Console.WriteLine("\nHelp/Instructions:");
                Console.WriteLine("1. To create a new wallet, choose the option 'Create a new wallet'.");
                Console.WriteLine("2. To add money, choose the option 'Add money' and enter the amount.");
                Console.WriteLine("3. To check the balance, choose the option 'Check balance'.");
                Console.WriteLine("4. To display personal information, choose the option 'Display personal information'.");
                Console.WriteLine("5. To add a credit card, choose the option 'Add a credit card' and enter the card number.");
                Console.WriteLine("6. To add a business card, choose the option 'Add a business card' and enter the card information.");
                Console.WriteLine("7. To add a photo, choose the option 'Add a photo' and enter the photo name.");
                Console.WriteLine("8. To display registered cards, choose the option 'Display registered cards'.");
                Console.WriteLine("9. To display registered photos, choose the option 'Display registered photos'.");
                Console.WriteLine("10. To withdraw money, choose the option 'Withdraw money' and enter the amount.");
                Console.WriteLine("11. To remove a card, choose the option 'Remove a card' and enter the card number.");
                Console.WriteLine("12. To remove a photo, choose the option 'Remove a photo' and enter the photo name.");
                Console.WriteLine("13. To search for a card, choose the option 'Search for a card' and enter the card number.");
                Console.WriteLine("14. To search for a photo, choose the option 'Search for a photo' and enter the photo name.");
                Console.WriteLine("15. For help/instructions, choose the option 'Help/Instructions'.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a number between 0 and 15.");
            }
        }
    }
}
