
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;

namespace AddressBookDay13
{
    public class Program
    {
        
        List<ContactDetails> contactDetailsList;
        private Dictionary<string, ContactDetails> contactDetailsMap;
        private Dictionary<string, Dictionary<string, ContactDetails>> multipleAddressBookMap;
        private List<ContactDetails> sortedBookList;


        public Program()
        {
            contactDetailsList = new List<ContactDetails>();
            contactDetailsMap = new Dictionary<string, ContactDetails>();
            multipleAddressBookMap = new Dictionary<string, Dictionary<string, ContactDetails>>();
            sortedBookList = new List<ContactDetails>();

        }
       
        /// <summary>
        /// UC12: Sorted person in alphabatical order as per the city or zip or state
        /// </summary>
        public void SortByCityOrStateOrZip()
        {
            List<ContactDetails> sortedList;
            Console.WriteLine(" Sort the contacts by City or State or Zip ");
            Console.WriteLine("1: Entered for sorting list by City ");
            Console.WriteLine("2: Entered for sorting list by State");
            Console.WriteLine("3: Entered for sorting list by zip");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    sortedList = contactDetailsList.OrderBy(x => x.city).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
                case 2:
                    sortedList = contactDetailsList.OrderBy(x => x.state).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
                case 3:
                    sortedList = contactDetailsList.OrderBy(x => x.zip).ToList();
                    foreach (ContactDetails book in sortedList)
                    {
                        Console.WriteLine(book.toString());
                    }
                    break;
            }

        }
        public List<ContactDetails> AddDetails(string addressBook, string firstName, string LastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            ContactDetails contactDetails = new ContactDetails(addressBook, firstName, LastName, address, city, state, zip, phoneNumber, email);
            contactDetailsList.Add(contactDetails);

            return contactDetailsList;

        }
        /// <summary>
        /// UC11: Sort the contactlist in alphabetical order of first name
        /// </summary>
        public List<ContactDetails> SortByFirstName()
        {
            Console.WriteLine(" Sort the contacts alphabetically ");
            sortedBookList = contactDetailsList.OrderBy(x => x.firstName).ToList();
            foreach (ContactDetails book in sortedBookList)
            {
                Console.WriteLine(book.toString());
            }
            return sortedBookList;

        }


        public void AddressBook(string addressBook)
        {
            multipleAddressBookMap.Add(addressBook, contactDetailsMap);
        }



        /// <summary>
        /// UC8: Ability to search person from the contactlist
        /// UC9: Ability to view person from the contactlist
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ContactDetails> Search()
        {
            Console.WriteLine(" Enter state ");
            string state = Console.ReadLine();
            var stateCheck = contactDetailsList.FindAll(x => x.state == state);
            Console.WriteLine(" Enter city ");
            string city = Console.ReadLine();
            var cityCheck = stateCheck.FindAll(x => x.city == city);
            Console.WriteLine(" Find Person ");
            string firstName = Console.ReadLine();
            var person = cityCheck.Where(x => x.firstName == firstName).FirstOrDefault();
            if (person != null)
            {
                Console.WriteLine(firstName + " is  in " + city);
            }
            else
            {
                Console.WriteLine(firstName + " is not  in " + city);
            }
            Dictionary<string, ContactDetails> detailCity = new Dictionary<string, ContactDetails>();
            Dictionary<string, ContactDetails> detailState = new Dictionary<string, ContactDetails>();
            detailCity.Add(city, person);
            detailState.Add(state, person);
            foreach (KeyValuePair<string, ContactDetails> i in detailCity)
            {
                Console.WriteLine("City: {0}  {1}", i.Key, i.Value.toString());
            }

            foreach (KeyValuePair<string, ContactDetails> i in detailState)
            {
                Console.WriteLine("State: {0}  {1}", i.Key, i.Value.toString());
            }

            Console.WriteLine(detailCity.Count());
            return detailCity;
        }
        /// <summary>
        /// UC10: Ability to count the person from the same state
        /// </summary>
        public void Count()
        {
            Console.WriteLine(" Enter state ");
            string state = Console.ReadLine();
            var stateCheck = contactDetailsList.FindAll(x => x.state == state);
            Console.WriteLine(" No of contacts from the state: " + state + " are " + stateCheck.Count);
        }
        public void ComputeDetails()
        {
            foreach (ContactDetails book in contactDetailsList)
            {
                Console.WriteLine(book.toString());
            }
        }
        /// <summary>
        /// UC13:Ability to read file using file I/O
        /// </summary>
        public void ReadAFile()
        {
            string InputFile = @"C:\Users\User\source\repos\File IO\AddressBookDay20\AddressBookDay20\AddressBookDay20\bin\Debug\netcoreapp3.1\AddressBookDay20.txt";
            using (StreamReader read = File.OpenText(InputFile))
            {
                string s = " ";
                while ((s = read.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
                read.Close();
            }
        }
        /// <summary>
        /// UC13:Ability to write file using file I/O
        /// </summary>
        public void WriteAFile()
        {
            string InputFile = @"C:\Users\User\source\repos\File IO\AddressBookDay20\AddressBookDay20\AddressBookDay20\bin\Debug\netcoreapp3.1\AddressBookDay20.txt";
            using (StreamWriter write = File.AppendText(InputFile))
            {
                write.WriteLine("This table contains student informaton in sorted manner");
                foreach (ContactDetails printInText in sortedBookList)
                {
                    write.WriteLine(printInText.toString());
                }
                write.Close();
                Console.WriteLine(File.ReadAllText(InputFile));
            }


        }
        /// <summary>
        /// UC14: Ability to read and write the csv file
        /// </summary>
        public void ImplementCsv()
        {

            string importFilePath = @"C:\Users\User\source\repos\fileIO\AddressBookDay21\AddressBookDay21\CsvFile\AddressBookDay21A.csv";
            string exportFilePath = @"C:\Users\User\source\repos\fileIO\AddressBookDay21\AddressBookDay21\CsvFile\AddressBookDay21A.csv";

            // writing csv file
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                List <ContactDetails> sortedlist= SortByFirstName();
                csvExport.WriteRecords(sortedlist);
            }

            //reading csv file
            using (TextReader reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ContactDetails>().ToList();
                Console.WriteLine("Read data successfully from MultipleAddressBook.csv, here are codes ");

                foreach (ContactDetails contactDetails in records)
                {
                    Console.WriteLine("\t" + contactDetails.firstName);
                }
            }
        }
        /// <summary>
        /// UC15: Ability to read and write JSON file
        /// </summary>
        public void JsonSerialize()
        {
            try
            {
                string path = @"C:\Users\User\source\repos\fileIO\AddressBookDay21\AddressBookDay21\JsonFile\AddressBook.json";
          
                string jsonData = JsonConvert.SerializeObject(contactDetailsList);
             
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Flush();
                    sw.Write(jsonData);
                    Console.WriteLine(jsonData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        public void JsonDeSerialize()
        {
            string path = @"C:\Users\User\source\repos\fileIO\AddressBookDay21\AddressBookDay21\JsonFile\AddressBook.json";
            string result = File.ReadAllText(path);

           // JsonReader reader = new JsonTextReader();
            //Convert ContactDetails object to JSON string formt

           List<ContactDetails>  contactDetails = JsonConvert.DeserializeObject<List<ContactDetails>>(result);

        }

    }

}
