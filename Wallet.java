import java.util.*;

class Wallet {
    private double balance;
    private Map<String, String> personalInfo;
    private List<String> creditCards;
    private List<Map<String, String>> businessCards;
    private List<String> photos;

    public Wallet() {
        balance = 0;
        personalInfo = new HashMap<>();
        creditCards = new ArrayList<>();
        businessCards = new ArrayList<>();
        photos = new ArrayList<>();
    }

    public void addMoney(double amount) {
        balance += amount;
        System.out.printf("%.2f Ar added to the wallet. New balance: %.2f Ar%n", amount, balance);
    }

    public void checkBalance() {
        System.out.printf("Current balance: %.2f Ar%n", balance);
    }

    public void displayPersonalInfo() {
        if (!personalInfo.isEmpty()) {
            System.out.println("Personal information:");
            for (Map.Entry<String, String> entry : personalInfo.entrySet()) {
                System.out.printf("%s: %s%n", entry.getKey(), entry.getValue());
            }
        } else {
            System.out.println("No personal information available.");
        }
    }

    public void addCreditCard(String card) {
        creditCards.add(card);
        System.out.println("Credit card added successfully.");
    }

    public void addBusinessCard(Map<String, String> cardInfo) {
        Map<String, String> businessCard = new HashMap<>();
        Scanner scanner = new Scanner(System.in);

        System.out.println("\nEnter business card information:");
        System.out.print("Name: ");
        businessCard.put("Name", scanner.nextLine());
        System.out.print("Title: ");
        businessCard.put("Title", scanner.nextLine());
        System.out.print("Company: ");
        businessCard.put("Company", scanner.nextLine());
        System.out.print("Email: ");
        businessCard.put("Email", scanner.nextLine());
        System.out.print("Phone Number: ");
        businessCard.put("Phone Number", scanner.nextLine());

        businessCards.add(new HashMap<>(businessCard));
        businessCards.get(businessCards.size() - 1).putAll(cardInfo);

        System.out.println("Business card added successfully.");
    }

    public void addPhoto(String photo) {
        photos.add(photo);
        System.out.println("Photo added successfully.");
    }

    public void displayRegisteredCards() {
        System.out.println("Registered cards:");

        if (!creditCards.isEmpty()) {
            System.out.println("\nCredit cards:");
            for (String card : creditCards) {
                System.out.println(card);
            }
        } else {
            System.out.println("\nNo credit cards registered.");
        }

        if (!businessCards.isEmpty()) {
            System.out.println("\nBusiness cards:");
            for (Map<String, String> card : businessCards) {
                for (Map.Entry<String, String> entry : card.entrySet()) {
                    System.out.printf("%s: %s%n", entry.getKey(), entry.getValue());
                }
                System.out.println();
            }
        } else {
            System.out.println("\nNo business cards registered.");
        }
    }

    public void displayPhotos() {
        System.out.println("Registered photos:");

        if (!photos.isEmpty()) {
            for (String photo : photos) {
                System.out.println(photo);
            }
        } else {
            System.out.println("No photos registered.");
        }
    }

    public void withdrawMoney(double amount) {
        if (amount <= balance) {
            balance -= amount;
            System.out.printf("%.2f Ar withdrawn successfully. New balance: %.2f Ar%n", amount, balance);
        } else {
            System.out.println("Insufficient funds.");
        }
    }

    public void removeCard(String card) {
        if (creditCards.remove(card)) {
            System.out.println("Credit card removed successfully.");
        } else if (removeBusinessCard(card)) {
            System.out.println("Business card removed successfully.");
        } else {
            System.out.println("The specified card was not found.");
        }
    }

    private boolean removeBusinessCard(String card) {
        for (Map<String, String> businessCard : businessCards) {
            if (businessCard.containsValue(card)) {
                businessCards.remove(businessCard);
                return true;
            }
        }
        return false;
    }

    public void removePhoto(String photo) {
        if (photos.remove(photo)) {
            System.out.println("Photo removed successfully.");
        } else {
            System.out.println("The specified photo was not found.");
        }
    }

    public void searchCard(String card) {
        if (creditCards.contains(card)) {
            System.out.println("Credit card found.");
        } else if (searchBusinessCard(card)) {
            System.out.println("Business card found.");
        } else {
            System.out.println("The specified card was not found.");
        }
    }

    private boolean searchBusinessCard(String card) {
        for (Map<String, String> businessCard : businessCards) {
            if (businessCard.containsValue(card)) {
                return true;
            }
        }
        return false;
    }

    public void searchPhoto(String photo) {
        if (photos.contains(photo)) {
            System.out.println("Photo found.");
        } else {
            System.out.println("The specified photo was not found.");
        }
    }

    public void setPersonalInfo() {
        Scanner scanner = new Scanner(System.in);

        System.out.println("\nEnter your personal information:");
        System.out.print("Name: ");
        personalInfo.put("Name", scanner.nextLine());
        System.out.print("Address: ");
        personalInfo.put("Address", scanner.nextLine());
        System.out.print("Phone Number: ");
        personalInfo.put("Phone Number", scanner.nextLine());

        System.out.println("Personal information set successfully.");
    }

    public static void main(String[] args) {
        Wallet userWallet = null;

        System.out.println("Welcome to the Wallet Management Program!");

        while (true) {
            System.out.println("\nMenu:");
            System.out.println("1. Create a new wallet");
            System.out.println("2. Add money");
            System.out.println("3. Check balance");
            System.out.println("4. Display personal information");
            System.out.println("5. Add a credit card");
            System.out.println("6. Add a business card");
            System.out.println("7. Add a photo");
            System.out.println("8. Display registered cards");
            System.out.println("9. Display registered photos");
            System.out.println("10. Withdraw money");
            System.out.println("11. Remove a card");
            System.out.println("12. Remove a photo");
            System.out.println("13. Search for a card");
            System.out.println("14. Search for a photo");
            System.out.println("15. Help/Instructions");
            System.out.println("0. Quit");

            Scanner scanner = new Scanner(System.in);
            System.out.print("Please choose an option (0-15): ");
            String choice = scanner.nextLine();

            if (choice.equals("0")) {
                System.out.println("Thank you for using the program. Goodbye!");
                break;
            } else if (choice.equals("1")) {
                userWallet = new Wallet();
                userWallet.setPersonalInfo();
                System.out.println("New wallet created.");
            } else if (choice.equals("2")) {
                System.out.print("Enter the amount to add (Ar): ");
                double amount = scanner.nextDouble();
                userWallet.addMoney(amount);
            } else if (choice.equals("3")) {
                userWallet.checkBalance();
            } else if (choice.equals("4")) {
                userWallet.displayPersonalInfo();
            } else if (choice.equals("5")) {
                System.out.print("Enter the credit card number: ");
                String creditCard = scanner.nextLine();
                userWallet.addCreditCard(creditCard);
            } else if (choice.equals("6")) {
                Map<String, String> businessCardInfo = new HashMap<>();
                userWallet.addBusinessCard(businessCardInfo);
            } else if (choice.equals("7")) {
                System.out.print("Enter the photo name: ");
                String photo = scanner.nextLine();
                userWallet.addPhoto(photo);
            } else if (choice.equals("8")) {
                userWallet.displayRegisteredCards();
            } else if (choice.equals("9")) {
                userWallet.displayPhotos();
            } else if (choice.equals("10")) {
                System.out.print("Enter the amount to withdraw (Ar): ");
                double amount = scanner.nextDouble();
                userWallet.withdrawMoney(amount);
            } else if (choice.equals("11")) {
                System.out.print("Enter the card number to remove: ");
                String cardToRemove = scanner.nextLine();
                userWallet.removeCard(cardToRemove);
            } else if (choice.equals("12")) {
                System.out.print("Enter the photo name to remove: ");
                String photoToRemove = scanner.nextLine();
                userWallet.removePhoto(photoToRemove);
            } else if (choice.equals("13")) {
                System.out.print("Enter the card number to search: ");
                String cardToSearch = scanner.nextLine();
                userWallet.searchCard(cardToSearch);
            } else if (choice.equals("14")) {
                System.out.print("Enter the photo name to search: ");
                String photoToSearch = scanner.nextLine();
                userWallet.searchPhoto(photoToSearch);
            } else if (choice.equals("15")) {
                System.out.println("\nHelp/Instructions:");
                System.out.println("1. To create a new wallet, choose the option 'Create a new wallet'.");
                System.out.println("2. To add money, choose the option 'Add money' and enter the amount.");
                System.out.println("3. To check the balance, choose the option 'Check balance'.");
                System.out.println("4. To display personal information, choose the option 'Display personal information'.");
                System.out.println("5. To add a credit card, choose the option 'Add a credit card' and enter the card number.");
                System.out.println("6. To add a business card, choose the option 'Add a business card' and enter the card information.");
                System.out.println("7. To add a photo, choose the option 'Add a photo' and enter the photo name.");
                System.out.println("8. To display registered cards, choose the option 'Display registered cards'.");
                System.out.println("9. To display registered photos, choose the option 'Display registered photos'.");
                System.out.println("10. To withdraw money, choose the option 'Withdraw money' and enter the amount.");
                System.out.println("11. To remove a card, choose the option 'Remove a card' and enter the card number.");
                System.out.println("12. To remove a photo, choose the option 'Remove a photo' and enter the photo name.");
                System.out.println("13. To search for a card, choose the option 'Search for a card' and enter the card number.");
                System.out.println("14. To search for a photo, choose the option 'Search for a photo' and enter the photo name.");
                System.out.println("15. For help/instructions, choose the option 'Help/Instructions'.");
            } else {
                System.out.println("Invalid option. Please enter a number between 0 and 15.");
            }
        }
    }
}
