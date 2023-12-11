const readlineSync = require('readline-sync');

class Wallet {
    constructor() {
        this.balance = 0;
        this.personalInfo = {};
        this.creditCards = [];
        this.businessCards = [];
        this.photos = [];
    }

    addMoney(amount) {
        this.balance += amount;
        console.log(`${amount} Ar added to the wallet. New balance: ${this.balance} Ar`);
    }

    checkBalance() {
        console.log(`Current balance: ${this.balance} Ar`);
    }

    displayPersonalInfo() {
        if (Object.keys(this.personalInfo).length !== 0) {
            console.log("Personal information:");
            for (const [key, value] of Object.entries(this.personalInfo)) {
                console.log(`${key}: ${value}`);
            }
        } else {
            console.log("No personal information available.");
        }
    }

    addCreditCard(card) {
        this.creditCards.push(card);
        console.log("Credit card added successfully.");
    }

    addBusinessCard(cardInfo) {
        const businessCard = {};
        console.log("\nEnter business card information:");
        businessCard['Name'] = readlineSync.question("Name: ");
        businessCard['Title'] = readlineSync.question("Title: ");
        businessCard['Company'] = readlineSync.question("Company: ");
        businessCard['Email'] = readlineSync.question("Email: ");
        businessCard['Phone Number'] = readlineSync.question("Phone Number: ");

        this.businessCards.push({ ...businessCard, ...cardInfo });
        console.log("Business card added successfully.");
    }

    addPhoto(photo) {
        this.photos.push(photo);
        console.log("Photo added successfully.");
    }

    displayRegisteredCards() {
        console.log("Registered cards:");
        if (this.creditCards.length !== 0) {
            console.log("\nCredit cards:");
            this.creditCards.forEach(card => console.log(card));
        } else {
            console.log("\nNo credit cards registered.");
        }

        if (this.businessCards.length !== 0) {
            console.log("\nBusiness cards:");
            this.businessCards.forEach(card => console.log(card));
        } else {
            console.log("\nNo business cards registered.");
        }
    }

    displayPhotos() {
        console.log("Registered photos:");
        if (this.photos.length !== 0) {
            this.photos.forEach(photo => console.log(photo));
        } else {
            console.log("No photos registered.");
        }
    }

    withdrawMoney(amount) {
        if (amount <= this.balance) {
            this.balance -= amount;
            console.log(`${amount} Ar withdrawn successfully. New balance: ${this.balance} Ar`);
        } else {
            console.log("Insufficient funds.");
        }
    }

    removeCard(card) {
        const cardIndex = this.creditCards.indexOf(card);
        if (cardIndex !== -1) {
            this.creditCards.splice(cardIndex, 1);
            console.log("Credit card removed successfully.");
        } else {
            const businessCardIndex = this.businessCards.findIndex(item => item['Name'] === card);
            if (businessCardIndex !== -1) {
                this.businessCards.splice(businessCardIndex, 1);
                console.log("Business card removed successfully.");
            } else {
                console.log("The specified card was not found.");
            }
        }
    }

    removePhoto(photo) {
        const photoIndex = this.photos.indexOf(photo);
        if (photoIndex !== -1) {
            this.photos.splice(photoIndex, 1);
            console.log("Photo removed successfully.");
        } else {
            console.log("The specified photo was not found.");
        }
    }

    searchCard(card) {
        if (this.creditCards.includes(card)) {
            console.log("Credit card found.");
        } else {
            const businessCardFound = this.businessCards.some(item => item['Name'] === card);
            if (businessCardFound) {
                console.log("Business card found.");
            } else {
                console.log("The specified card was not found.");
            }
        }
    }

    searchPhoto(photo) {
        if (this.photos.includes(photo)) {
            console.log("Photo found.");
        } else {
            console.log("The specified photo was not found.");
        }
    }

    setPersonalInfo() {
        console.log("\nEnter your personal information:");
        this.personalInfo['Name'] = readlineSync.question("Name: ");
        this.personalInfo['Address'] = readlineSync.question("Address: ");
        this.personalInfo['Phone Number'] = readlineSync.question("Phone Number: ");
        console.log("Personal information set successfully.");
    }
}

let userWallet = null;

console.log("Welcome to the Wallet Management Program!");

while (true) {
    console.log("\nMenu:");
    console.log("1. Create a new wallet");
    console.log("2. Add money");
    console.log("3. Check balance");
    console.log("4. Display personal information");
    console.log("5. Add a credit card");
    console.log("6. Add a business card");
    console.log("7. Add a photo");
    console.log("8. Display registered cards");
    console.log("9. Display registered photos");
    console.log("10. Withdraw money");
    console.log("11. Remove a card");
    console.log("12. Remove a photo");
    console.log("13. Search for a card");
    console.log("14. Search for a photo");
    console.log("15. Help/Instructions");
    console.log("0. Quit");

    const choice = readlineSync.question("Please choose an option (0-15): ");

    if (choice === "0") {
        console.log("Thank you for using the program. Goodbye!");
        break;
    } else if (choice === "1") {
        userWallet = new Wallet();
        userWallet.setPersonalInfo();
        console.log("New wallet created.");
    } else if (choice === "2") {
        const amount = parseFloat(readlineSync.question("Enter the amount to add (Ar): "));
        userWallet.addMoney(amount);
    } else if (choice === "3") {
        userWallet.checkBalance();
    } else if (choice === "4") {
        userWallet.displayPersonalInfo();
    } else if (choice === "5") {
        const creditCard = readlineSync.question("Enter the credit card number: ");
        userWallet.addCreditCard(creditCard);
    } else if (choice === "6") {
        const businessCardInfo = {};
        userWallet.addBusinessCard(businessCardInfo);
    } else if (choice === "7") {
        const photo = readlineSync.question("Enter the photo name: ");
        userWallet.addPhoto(photo);
    } else if (choice === "8") {
        userWallet.displayRegisteredCards();
    } else if (choice === "9") {
        userWallet.displayPhotos();
    } else if (choice === "10") {
        const amount = parseFloat(readlineSync.question("Enter the amount to withdraw (Ar): "));
        userWallet.withdrawMoney(amount);
    } else if (choice === "11") {
        const cardToRemove = readlineSync.question("Enter the card number to remove: ");
        userWallet.removeCard(cardToRemove);
    } else if (choice === "12") {
        const photoToRemove = readlineSync.question("Enter the photo name to remove: ");
        userWallet.removePhoto(photoToRemove);
    } else if (choice === "13") {
        const cardToSearch = readlineSync.question("Enter the card number to search: ");
        userWallet.searchCard(cardToSearch);
    } else if (choice === "14") {
        const photoToSearch = readlineSync.question("Enter the photo name to search: ");
        userWallet.searchPhoto(photoToSearch);
    } else if (choice === "15") {
        console.log("\nHelp/Instructions:");
        console.log("1. To create a new wallet, choose the option 'Create a new wallet'.");
        console.log("2. To add money, choose the option 'Add money' and enter the amount.");
        console.log("3. To check the balance, choose the option 'Check balance'.");
        console.log("4. To display personal information, choose the option 'Display personal information'.");
        console.log("5. To add a credit card, choose the option 'Add a credit card' and enter the card number.");
        console.log("6. To add a business card, choose the option 'Add a business card' and enter the card information.");
        console.log("7. To add a photo, choose the option 'Add a photo' and enter the photo name.");
        console.log("8. To display registered cards, choose the option 'Display registered cards'.");
        console.log("9. To display registered photos, choose the option 'Display registered photos'.");
        console.log("10. To withdraw money, choose the option 'Withdraw money' and enter the amount.");
        console.log("11. To remove a card, choose the option 'Remove a card' and enter the card number.");
        console.log("12. To remove a photo, choose the option 'Remove a photo' and enter the photo name.");
        console.log("13. To search for a card, choose the option 'Search for a card' and enter the card number.");
        console.log("14. To search for a photo, choose the option 'Search for a photo' and enter the photo name.");
        console.log("15. For help/instructions, choose the option 'Help/Instructions'.");
    } else {
        console.log("Invalid option. Please enter a number between 0 and 15.");
    }
}
