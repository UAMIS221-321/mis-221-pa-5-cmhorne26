
// main

using mis_221_pa_5_cmhorne26;

DisplayMenu();

//main menu

static void DisplayMenu()
{
    System.Console.WriteLine("Welcome to Train Like A Champion ~ Personal Fitness!"); 
    System.Console.WriteLine("Please enter a number to contine...");
    System.Console.WriteLine("1) Manage trainer data\n2) Manage listing data\n3) Manage customer booking data\n4) Run Reports\n5) Exit");

    int userChoice = int.Parse(Console.ReadLine());
    ValidChoice(userChoice);
}

static void ValidChoice(int userChoice)
{
    if(userChoice != 1 && userChoice != 2 && userChoice != 3 && userChoice != 4 && userChoice != 5)
    {
        Console.Clear();
        System.Console.WriteLine("Invalid selection. Please select a valid number choice.\nPress any key to return to the main menu...");
        Console.ReadKey();
        Console.Clear();
        DisplayMenu();
    }
    if(userChoice == 5) // exit
    {
        Environment.Exit(0);
    }
    else if(userChoice == 1) // Manage Trainer Data
    {
         TrainerManager trainerManager = new TrainerManager();

    Console.Clear();
    Console.WriteLine("Manage Trainer Data\n");
    Console.WriteLine("1) Add trainer\n2) Edit trainer\n3) Delete trainer\n4) Return to main menu");

    int trainerAction = int.Parse(Console.ReadLine());

    switch (trainerAction)
    {
        case 1: // Add trainer
            Console.WriteLine("Enter Trainer ID: ");
            int trainerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trainer Name: ");
            string trainerName = Console.ReadLine();
            Console.WriteLine("Enter Mailing Address: ");
            string mailingAddress = Console.ReadLine();
            Console.WriteLine("Enter Trainer Email Address: ");
            string trainerEmail = Console.ReadLine();

            Trainer newTrainer = new Trainer(trainerId, trainerName, mailingAddress, trainerEmail);
            trainerManager.AddTrainer(newTrainer);
            Console.WriteLine("Trainer added successfully.");
            break;
        case 2: // Edit trainer
            Console.WriteLine("Enter Trainer ID to edit: ");
            int trainerIdToEdit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Trainer Name: ");
            string updatedTrainerName = Console.ReadLine();
            Console.WriteLine("Enter New Mailing Address: ");
            string updatedMailingAddress = Console.ReadLine();
            Console.WriteLine("Enter New Trainer Email Address: ");
            string updatedTrainerEmail = Console.ReadLine();

            Trainer updatedTrainer = new Trainer(trainerIdToEdit, updatedTrainerName, updatedMailingAddress, updatedTrainerEmail);
            trainerManager.EditTrainer(updatedTrainer);
            Console.WriteLine("Trainer updated successfully.");
            break;
        case 3: // Delete trainer
            Console.WriteLine("Enter Trainer ID to delete: ");
            int trainerIdToDelete = int.Parse(Console.ReadLine());
            trainerManager.DeleteTrainer(trainerIdToDelete);
            Console.WriteLine("Trainer deleted successfully.");
            break;
        case 4: // Return to main menu
            Console.Clear();
            DisplayMenu();
            break;
        default:
            Console.WriteLine("Invalid selection. Returning to main menu.");
            DisplayMenu();
            break;
    }
    }
    else if (userChoice == 2) // Manage Listing Data
    {
        ListingManager listingManager = new ListingManager();

    Console.Clear();
    Console.WriteLine("Manage Listing Data\n");
    Console.WriteLine("1) Add listing\n2) Edit listing\n3) Delete listing\n4) Return to main menu");

    int listingAction = int.Parse(Console.ReadLine());

    switch (listingAction)
    {
        case 1: // Add listing
            Console.WriteLine("Enter Listing ID: ");
            int listingId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trainer Name: ");
            string trainerName = Console.ReadLine();
            Console.WriteLine("Enter Date of the Session (yyyy-MM-dd): ");
            DateTime sessionDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Time of the Session (HH:mm): ");
            TimeSpan sessionTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter Cost of the Session: ");
            decimal sessionCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Is the listing taken? (true/false): ");
            bool isTaken = bool.Parse(Console.ReadLine());

            Listing newListing = new Listing(listingId, trainerName, sessionDate, sessionTime, sessionCost, isTaken);
            listingManager.AddListing(newListing);
            Console.WriteLine("Listing added successfully.");
            break;
        case 2: // Edit listing
            Console.WriteLine("Enter Listing ID to edit: ");
            int listingIdToEdit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Trainer Name: ");
            string updatedTrainerName = Console.ReadLine();
            Console.WriteLine("Enter New Date of the Session (yyyy-MM-dd): ");
            DateTime updatedSessionDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Time of the Session (HH:mm): ");
            TimeSpan updatedSessionTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Cost of the Session: ");
            decimal updatedSessionCost = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Is the listing taken? (true/false): ");
            bool updatedIsTaken = bool.Parse(Console.ReadLine());

            Listing updatedListing = new Listing(listingIdToEdit, updatedTrainerName, updatedSessionDate, updatedSessionTime, updatedSessionCost, updatedIsTaken);
            listingManager.EditListing(updatedListing);
            Console.WriteLine("Listing updated successfully.");
            break;
        case 3: // Delete listing
            Console.WriteLine("Enter Listing ID to delete: ");
            int listingIdToDelete = int.Parse(Console.ReadLine());
            listingManager.DeleteListing(listingIdToDelete);
            Console.WriteLine("Listing deleted successfully.");
            break;
        case 4: // Return to main menu
            Console.Clear();
            DisplayMenu();
            break;
        default:
            Console.WriteLine("Invalid selection. Returning to main menu.");
            DisplayMenu();
            break;
    }
    }
    else if (userChoice == 3) // Manage customer booking data
    {
        BookingManager bookingManager = new BookingManager();
    ListingManager listingManager = new ListingManager();

    Console.Clear();
    Console.WriteLine("Manage Customer Booking Data\n");
    Console.WriteLine("1) Book a session\n2) Update booking status\n3) Return to main menu");

    int bookingAction = int.Parse(Console.ReadLine());

    switch (bookingAction)
    {
        case 1: // Book a session
            Console.WriteLine("Available sessions:");
            List<Listing> availableSessions = bookingManager.GetAvailableSessions(listingManager.LoadListings());
            foreach (Listing session in availableSessions)
            {
                Console.WriteLine(session);
            }

            Console.WriteLine("Enter Listing ID to book: ");
            int listingId = int.Parse(Console.ReadLine());
            Listing selectedListing = availableSessions.FirstOrDefault(l => l.ListingID == listingId);

            if (selectedListing != null)
            {
                Console.WriteLine("Enter Session ID: ");
                int sessionId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Customer Name: ");
                string customerName = Console.ReadLine();
                Console.WriteLine("Enter Customer Email: ");
                string customerEmail = Console.ReadLine();

                bookingManager.BookSession(selectedListing, sessionId, customerName, customerEmail);
                listingManager.EditListing(selectedListing);

                Console.WriteLine("Session booked successfully.");
            }
            else
            {
                Console.WriteLine("Invalid Listing ID.");
            }
            break;
        case 2: // Update booking status
            Console.WriteLine("Enter Session ID to update status: ");
            int sessionIdToUpdate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new status (booked/completed/cancelled): ");
            string newStatus = Console.ReadLine();

            bookingManager.UpdateBookingStatus(sessionIdToUpdate, newStatus);
            Console.WriteLine("Booking status updated successfully.");
            break;
        case 3: // Return to main menu
            Console.Clear();
            DisplayMenu();
            break;
        default:
            Console.WriteLine("Invalid selection. Returning to main menu.");
            DisplayMenu();
            break;
    }
    }
    else if (userChoice == 4) // Run Reports
    {
        
    } 
}


