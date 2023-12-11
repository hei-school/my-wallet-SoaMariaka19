class Wallet:
    def __init__(self):
        self.balance = 0
        self.personal_info = {}
        self.credit_cards = []
        self.business_cards = []
        self.photos = []

    def add_money(self, amount):
        self.balance += amount
        print(f"{amount} Ar added to the wallet. New balance: {self.balance} Ar")

    def check_balance(self):
        print(f"Current balance: {self.balance} Ar")

    def display_personal_info(self):
        if self.personal_info:
            print("Personal information:")
            for key, value in self.personal_info.items():
                print(f"{key}: {value}")
        else:
            print("No personal information available.")

    def add_credit_card(self, card):
        self.credit_cards.append(card)
        print("Credit card added successfully.")

    def add_business_card(self, card_info):
        business_card = {}
        print("\nEnter business card information:")
        business_card['Name'] = input("Name: ")
        business_card['Title'] = input("Title: ")
        business_card['Company'] = input("Company: ")
        business_card['Email'] = input("Email: ")
        business_card['Phone Number'] = input("Phone Number: ")

        self.business_cards.append({**business_card, **card_info})
        print("Business card added successfully.")

    def add_photo(self, photo):
        self.photos.append(photo)
        print("Photo added successfully.")

    def display_registered_cards(self):
        print("Registered cards:")
        if self.credit_cards:
            print("\nCredit cards:")
            for card in self.credit_cards:
                print(card)
        else:
            print("\nNo credit cards registered.")

        if self.business_cards:
            print("\nBusiness cards:")
            for card in self.business_cards:
                print(card)
        else:
            print("\nNo business cards registered.")

    def display_photos(self):
        print("Registered photos:")
        if self.photos:
            for photo in self.photos:
                print(photo)
        else:
            print("No photos registered.")

    def withdraw_money(self, amount):
        if amount <= self.balance:
            self.balance -= amount
            print(f"{amount} Ar withdrawn successfully. New balance: {self.balance} Ar")
        else:
            print("Insufficient funds.")

    def remove_card(self, card):
        if card in self.credit_cards:
            self.credit_cards.remove(card)
            print("Credit card removed successfully.")
        elif card in self.business_cards:
            self.business_cards.remove(card)
            print("Business card removed successfully.")
        else:
            print("The specified card was not found.")

    def remove_photo(self, photo):
        if photo in self.photos:
            self.photos.remove(photo)
            print("Photo removed successfully.")
        else:
            print("The specified photo was not found.")

    def search_card(self, card):
        if card in self.credit_cards:
            print("Credit card found.")
        elif card in self.business_cards:
            print("Business card found.")
        else:
            print("The specified card was not found.")

    def search_photo(self, photo):
        if photo in self.photos:
            print("Photo found.")
        else:
            print("The specified photo was not found.")

    def set_personal_info(self):
        print("\nEnter your personal information:")
        self.personal_info['Name'] = input("Name: ")
        self.personal_info['Address'] = input("Address: ")
        self.personal_info['Phone Number'] = input("Phone Number: ")
        print("Personal information set successfully.")

user_wallet = None

print("Welcome to the Wallet Management Program!")

while True:
    print("\nMenu:")
    print("1. Create a new wallet")
    print("2. Add money")
    print("3. Check balance")
    print("4. Display personal information")
    print("5. Add a credit card")
    print("6. Add a business card")
    print("7. Add a photo")
    print("8. Display registered cards")
    print("9. Display registered photos")
    print("10. Withdraw money")
    print("11. Remove a card")
    print("12. Remove a photo")
    print("13. Search for a card")
    print("14. Search for a photo")
    print("15. Help/Instructions")
    print("0. Quit")

    choice = input("Please choose an option (0-15): ")

    if choice == "0":
        print("Thank you for using the program. Goodbye!")
        break
    elif choice == "1":
        user_wallet = Wallet()
        user_wallet.set_personal_info()
        print("New wallet created.")
    elif choice == "2":
        amount = float(input("Enter the amount to add (Ar): "))
        user_wallet.add_money(amount)
    elif choice == "3":
        user_wallet.check_balance()
    elif choice == "4":
        user_wallet.display_personal_info()
    elif choice == "5":
        credit_card = input("Enter the credit card number: ")
        user_wallet.add_credit_card(credit_card)
    elif choice == "6":
        business_card_info = {}
        user_wallet.add_business_card(business_card_info)
    elif choice == "7":
        photo = input("Enter the photo name: ")
        user_wallet.add_photo(photo)
    elif choice == "8":
        user_wallet.display_registered_cards()
    elif choice == "9":
        user_wallet.display_photos()
    elif choice == "10":
        amount = float(input("Enter the amount to withdraw (Ar): "))
        user_wallet.withdraw_money(amount)
    elif choice == "11":
        card_to_remove = input("Enter the card number to remove: ")
        user_wallet.remove_card(card_to_remove)
    elif choice == "12":
        photo_to_remove = input("Enter the photo name to remove: ")
        user_wallet.remove_photo(photo_to_remove)
    elif choice == "13":
        card_to_search = input("Enter the card number to search: ")
        user_wallet.search_card(card_to_search)
    elif choice == "14":
        photo_to_search = input("Enter the photo name to search: ")
        user_wallet.search_photo(photo_to_search)
    elif choice == "15":
        print("\nHelp/Instructions:")
        print("1. To create a new wallet, choose the option 'Create a new wallet'.")
        print("2. To add money, choose the option 'Add money' and enter the amount.")
        print("3. To check the balance, choose the option 'Check balance'.")
        print("4. To display personal information, choose the option 'Display personal information'.")
        print("5. To add a credit card, choose the option 'Add a credit card' and enter the card number.")
        print("6. To add a business card, choose the option 'Add a business card' and enter the card information.")
        print("7. To add a photo, choose the option 'Add a photo' and enter the photo name.")
        print("8. To display registered cards, choose the option 'Display registered cards'.")
        print("9. To display registered photos, choose the option 'Display registered photos'.")
        print("10. To withdraw money, choose the option 'Withdraw money' and enter the amount.")
        print("11. To remove a card, choose the option 'Remove a card' and enter the card number.")
        print("12. To remove a photo, choose the option 'Remove a photo' and enter the photo name.")
        print("13. To search for a card, choose the option 'Search for a card' and enter the card number.")
        print("14. To search for a photo, choose the option 'Search for a photo' and enter the photo name.")
        print("15. For help/instructions, choose the option 'Help/Instructions'.")
    else:
        print("Invalid option. Please enter a number between 0 and 15.")
