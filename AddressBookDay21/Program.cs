using System;

namespace AddressBookDay13
{
    public class AddressBook
    {

        static void Main(string[] args)
        {

            Console.WriteLine(" Welcome to Address Book System ");
            Program studentBook = new Program();


            //Address book created  for student
            studentBook.AddDetails("Student", "Ajinkya", " Patil ", " Pant nagar ", "Mumbai", "Maharashtra", 400025, 8806184085, " patil@gmail.com ");
            studentBook.AddDetails("Student", "Priya", " Kadam ", " Shivaji Chowk ", "Mumbai", "Maharashtra", 400011, 880664052, " kadam@gmail.com ");
            studentBook.AddDetails("Student", "Sachin", " Deshmukh ", " Gokhale nagar ", "Pune", "Maharashtra", 400017, 88060214103, " deshmukh@gmail.com ");
            studentBook.AddDetails("Student", "Pooja", " Gore ", " Swami chowk ", "Banglore", "Karnataka", 400517, 8875811103, " gore@gmail.com ");
            studentBook.AddDetails("Student", "Sheetal", " Patel ", " Gandhi nagar ", "Ahmdabad", "Gujrat", 400017, 8806154783, " pawar@gmail.com ");

            Console.WriteLine(" Enter  stored Book name : ");
            string addressBook = Console.ReadLine();
            if (addressBook == "Student")
            {
                studentBook.AddressBook(addressBook);


                //Giving option to perform
                Console.WriteLine("1:Search person by city or state");
                Console.WriteLine("2: Count of the person in  city");
                Console.WriteLine("3: Display the details");
                Console.WriteLine("4: Display by sorted first name");
                Console.WriteLine("5: Display by sorted City or zip ");
                Console.WriteLine("6: Read address book from file");
                Console.WriteLine("7: Write address book from file");
                Console.WriteLine("8: Read  and write address book from csv file");
                Console.WriteLine("9: Read and write address book from json file");
                
                Console.WriteLine("Enter the choice want to perform the function");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentBook.Search();
                        break;
                    case 2:
                        studentBook.Count();
                        break;
                    case 3:
                        studentBook.ComputeDetails();
                        break;
                    case 4:
                        studentBook.SortByFirstName();
                        break;
                    case 5:
                        studentBook.SortByCityOrStateOrZip();
                        break;
                    case 6:
                        studentBook.ReadAFile();
                        break;
                    case 7:
                        studentBook.SortByFirstName();
                        studentBook.WriteAFile();
                        break;
                    case 8:
                        studentBook.ImplementCsv();
                        break;
                    case 9:
                        studentBook.JsonSerialize();
                        studentBook.JsonDeSerialize();
                        break;
         
                 



                }
            }

        }
    }
}
