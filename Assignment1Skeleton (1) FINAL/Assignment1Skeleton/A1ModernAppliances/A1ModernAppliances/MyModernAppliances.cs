using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: charmisha , meet, harkeerat </remarks>
    /// <remarks>Date: 11-02-2024 </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout 
        /// this method allows user to enter the item number of appliances
        /// this user inputed item number is match with the item number of the appliance available
        /// once a match is found it is added to the found list
        /// then if the count of the found list is 0, which means no item with userinputed item number is found, then a text is prompted to tell the user
        /// if the count is not null , then further it is checked if the item is in available
        /// it it is available the item is checkout using checkout() method
        /// if not , then a text is prompted to the user
        /// 
        /// </summary>

        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");
            // Create long variable to hold item number
            long itemNumber;
            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();
            // Convert user input from string to long and store as item number variable.
            itemNumber = long.Parse(userInput);
            // Create 'foundAppliance' variable to hold appliance with item number
            List<Appliance> found = new List<Appliance>();
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    found.Add(appliance);
                    break;
                }
            }
            // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (found.Count == 0)
            {
                Console.WriteLine("No appliances found with that item number");
                return;
            }
            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance
            Appliance check = found[0];
            if (check.IsAvailable)
            {
                check.Checkout();
                Console.WriteLine($"Appliance with item number {itemNumber} has been checked out");
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// here the user is allowed to enter a specific brand name, 
        /// then the entered brand name is checked in the list of Appliance if it exist or not ,
        /// if yes it is added to the found list and the item with the brand name is displayed using DisplayAppliancesFromList() method
        /// </summary>
        public override void Find()

        {
            Console.WriteLine("Enter brand to search for:");
            // Write "Enter brand to search for:"

            string userEnteredBrand;
            userEnteredBrand = Console.ReadLine();
            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.

             List<Appliance> found = new List<Appliance>();
            // Create list to hold found Appliance objects

           
            foreach (var appliance in Appliances)
            {
                if(appliance.Brand == userEnteredBrand)
                {
                    found.Add(appliance);
                }
            }
            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list


            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// the user enter the numbers of doors they want in a refrigerator
        /// then we check/loop through the Appliances , where the Appliance is downcasted to Refrigerator 
        /// we make sure first that the appliance is only Refrigerator
        /// after that, we check through the Appliances (Refrigerators) if the we have a Regrigerator with the similar numbers of doors entered by the user,
        /// if yes, we add the appliance( which here is refrigerator) to the found list and displayed at the end using DisplayAppliancesFromList() method
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            // Write "Possible options:"

            Console.WriteLine("0 - Any\n2 - Double doors\n3 - three doors\n4 - Four doors ");
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"

            Console.WriteLine("Enter numbers of doors:");
            // Write "Enter number of doors: "

            string enteredNumber;
            // Create variable to hold entered number of doors

            string userInput = Console.ReadLine();
            // Get user input as string and assign to variable

            int numberOfDoors = Convert.ToInt32(userInput);
            // Convert user input from string to int and store as number of doors variable.

            List<Appliance> found = new List<Appliance>();
            // Create list to hold found Appliance objects


            foreach(var appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;

                    if (numberOfDoors == 0 || refrigerator.Doors == numberOfDoors)
                    {
                        found.Add(appliance);
                    }
                }
            }
            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;

            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// here the user can search vacuum using 2 factor one is grade and other is volts
        /// therefore here user gives two input - grade and volt
        /// According to the input we check into Appliances (specifically for Vaccums only, by making sure that appliance is Vaccum), if the condition grade/volt given by user is available or not 
        /// here the Appliance is downcasted to Vaccums 
        /// if yes, we add the found appliance to the found list and display it at the end using DisplayAppliancesFromList() method
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");
            // Write "Possible options:"

            Console.WriteLine("0 - Any\n1 - residential\n2 - Commercial");
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            Console.WriteLine("Enter grade:");
            // Write "Enter grade:"

            string userInputGrade = Console.ReadLine();
            // Get user input as string and assign to variable

            string grade;
            // Create grade variable to hold grade to find (Any, Residential, or Commercial)

            if (userInputGrade == "0")
            {
                grade = "Any";
            }
            else if (userInputGrade == "1")
            {
                grade = "Residential";
            }
            else if (userInputGrade == "2")
            {
                grade = "Commercial";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            //Test input is "0"
            // Assign "Any" to grade
            // Test input is "1"
            // Assign "Residential" to grade
            // Test input is "2"
            // Assign "Commercial" to grade
            // Otherwise(input is something else)
            // Write "Invalid option."

            // Return to calling(previous) method
            // return;

            Console.WriteLine("Possible options:");
            // Write "Possible options:"

            Console.WriteLine("0 - Any\n1 - 18 Volt\n2 - 24 Volt");
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            Console.WriteLine("Enter volatage:");
            // Write "Enter voltage:"

            string userInputVoltage = Console.ReadLine(); 
            // Get user input as string
            // Create variable to hold voltage
            short Voltage;

            if (userInputVoltage == "0")
            {
                Voltage = 0;
            }
            else if (userInputVoltage == "1")
            {
                Voltage = 18;
            }
            else if (userInputVoltage == "2")
            {
                Voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            // Test input is "0"
            // Assign 0 to voltage
            // Test input is "1"
            // Assign 18 to voltage
            // Test input is "2"
            // Assign 24 to voltage
            // Otherwise
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;

            List<Appliance> found = new List<Appliance>();
            // Create found variable to hold list of found appliances.

            foreach(var appliance in Appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    if ((grade == "Any" || grade == vacuum.Grade) && (Voltage == 0 || Voltage == vacuum.BatteryVoltage))
                    {
                        found.Add(vacuum);
                    }
                }

            }
            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;

            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// for the microwaves the user has option to select for kitchen and work.
        /// Hence, the user gives that input
        /// then that input is checked in the microwave appliance (by making sure that appliance is microwave only) and is matched, 
        /// which means that from all the available microwave we sort out kitchen and work as per the user demand
        /// here Appliance is downcasted to Microwaves 
        /// if any item is available it is added to the found list and displayed at the end using DisplayAppliancesFromList() method
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            // Write "Possible options:"

            Console.WriteLine("0 - Any\n1 - Kitchen\n2 - Work site");
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            Console.WriteLine("Enter room type:");
            // Write "Enter room type:"

            string userInput = Console.ReadLine();
            // Get user input as string and assign to variable

            char roomType;
            // Create character variable that holds room type

            if (userInput == "0")
            {
                roomType = 'A';
            }
            else if (userInput == "1")
            {
                roomType = 'K';
            }
            else if (userInput == "2")
            {
                roomType = 'W';
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;

            List<Appliance> found = new List<Appliance>();
            // Create variable that holds list of 'found' appliances


            foreach(var appliance in Appliances)
            {
                if(appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;
                    if(roomType == 'A'|| roomType == microwave.RoomType)
                    {
                        found.Add(microwave);
                    }
                }
            }
            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// for the dishwasher the user can select according the rating of the sound
        /// therefore , user gives input about the sound they want
        /// according to that input, all the dishwasher appliances (by making sure appliance is dishwasher only) are checked to match the user requirement 
        /// Appliance is downcasted to Dishwasher 
        /// if the requirement matches the appliance(dishwasher) is added to the found list and displayed using DisplayAppliancesFromList() method.
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");
            // Write "Possible options:"

            Console.WriteLine("0 - Any\n1 - Quiestest\n2 - Quieter\n3 - Quiet\n4 - Moderate");
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            Console.WriteLine("Enter sound rating:");
            // Write "Enter sound rating:"

            string userInput = Console.ReadLine();
            // Get user input as string and assign to variable

            string soundRating;
            // Create variable that holds sound rating

            if (userInput == "0")
            {
                soundRating = "Any";
            }
            else if (userInput == "1")
            {
                soundRating = "Qt";
            }
            else if (userInput == "2")
            {
                soundRating = "Qr";
            }
            else if (userInput == "3")
            {
                soundRating = "Qu";
            }
            else if (userInput == "4")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            List<Appliance> found = new List<Appliance>();
            // Create variable that holds list of found appliances

            foreach (var appliance in Appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if (soundRating == "Any" || dishwasher.SoundRating == soundRating)
                    {
                        found.Add(dishwasher);
                    }
                }
            }


            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, 0);
        }


        /// <summary>
        /// Generates random list of appliances
        /// the user is first prompted to enter the type of appliance, here the possible input is : 0 which is for any appliance, 1 is for refrigerator, 2 is for Vacuums, 3 is for Microwaves and 4 is for Dishwasher
        /// then they are asked to enter the number of random appliances they want to see
        /// let say the user input 1 where the appliance is matched with regrigerator and added to the found list ,
        /// the same goes with all the other appliance , 
        /// if the user input 0 then all the appliances are added to found list
        /// Sorts the found list using a RandomComparer to randomize the order of elements.
        /// the data is then displayed using the is DisplayAppliancesFromList() method
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Appliance Types");
            // Write "Appliance Types"

            Console.WriteLine("0 - Any\n1 - Refrigerators\n2 - Vacuums\n3 - Microwaves\n4 - Dishwashers");
            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            Console.WriteLine("Enter type of appliance:");
            // Write "Enter type of appliance:"

            string userInputType = Console.ReadLine();
            // Get user input as string and assign to appliance type variable

            Console.WriteLine("Enter number of appliances:");
            // Write "Enter number of appliances: "

            string numberOfAppliancesInput = Console.ReadLine();
            // Get user input as string and assign to variable

            int userInputNumberOfAppliances = Convert.ToInt32(numberOfAppliancesInput);
            // Convert user input from string to int

            List<Appliance> found = new List<Appliance>();
            // Create variable to hold list of found appliances

            foreach (Appliance appliance in Appliances)
            {
                if (userInputType == "0")
                {
                    found.Add(appliance);
                }
                else if (userInputType == "1" && appliance is Refrigerator)
                {
                    found.Add(appliance);
                }
                else if (userInputType == "2" && appliance is Vacuum)
                {
                    found.Add(appliance);
                }
                else if (userInputType == "3" && appliance is Microwave)
                {
                    found.Add(appliance);
                }
                else if (userInputType == "4" && appliance is Dishwasher)
                {
                    found.Add(appliance);
                }                
            }
            // Loop through appliances
            // Test inputted appliance type is "0"
            // Add current appliance in list to found list
            // Test inputted appliance type is "1"
            // Test current appliance type is Refrigerator
            // Add current appliance in list to found list
            // Test inputted appliance type is "2"
            // Test current appliance type is Vacuum
            // Add current appliance in list to found list
            // Test inputted appliance type is "3"
            // Test current appliance type is Microwave
            // Add current appliance in list to found list
            // Test inputted appliance type is "4"
            // Test current appliance type is Dishwasher
            // Add current appliance in list to found list

            // Randomize list of found appliances
            found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            DisplayAppliancesFromList(found, userInputNumberOfAppliances);
        }
    }
}
