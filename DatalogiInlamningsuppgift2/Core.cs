using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatalogiInlamningsuppgift2.DataStructures;
using DatalogiInlamningsuppgift2.Utility;

namespace DatalogiInlamningsuppgift2
{ 
    // TODO: Lägg till en datastruktur där användaren välja att spara sina sökningar och reslutaten. Exempelvis en List<string> som printar ut det senaste.
    // http://www.dummytextgenerator.com/

    internal class Core
    {
        // Tidskomplexitetean för minst två funktioner ska skrivas som kommentar i koden
        // Minst en rekursiv funktion i programmet
        // Full kommenterad kod
        private string errormsg;
        private List<string> listOfSearchedWords;
        private string[] doc1Arr;
        private string[] doc2Arr;
        private string[] doc3Arr;
        private string[][] documents;
        private string FILE_PATH_1;
        private string FILE_PATH_2;
        private string FILE_PATH_3;
        private BinaryTree bintree1;
        private BinaryTree bintree2;
        private BinaryTree bintree3;
        private BinaryTree[] bintreeArr;


        //private List<string> doc1List;
        //private List<string> doc2List;
        //private List<string> doc3List;

        internal Core()
        {
            FILE_PATH_1 = @"\Textfiles\text1000.txt";
            FILE_PATH_2 = @"\Textfiles\text1500.txt";
            FILE_PATH_3 = @"\Textfiles\text3000.txt";
            listOfSearchedWords = new List<string>();
            InitTxtFiles();
            MainMenu();
        }

        // Load text from files to arrays
        private void InitTxtFiles()
        {
            if(Utils.TxtToArr(FILE_PATH_1, out doc1Arr, out errormsg) && 
                Utils.TxtToArr(FILE_PATH_2, out doc2Arr, out errormsg) && 
                Utils.TxtToArr(FILE_PATH_3, out doc3Arr, out errormsg))
            {
                Console.WriteLine("Texts from three documents loaded successfully into string[] arrays\n\n");

                documents = Utils.SortArrays(doc1Arr, doc2Arr, doc3Arr);
                Console.WriteLine("Text sare now sorted in arrays with heapsort\n");

                bintreeArr = Utils.InsertIntoBinaryTree(documents);

                Console.WriteLine("Texts are now inserted into a sorted into three binary trees");

                // TODO
                // 3. Fixa så man kan söka på ord med kmp algo ?


            }
            else
            {
                Console.WriteLine(errormsg);
                Environment.Exit(0);
            }

            //documents = new string[][] { doc1Arr, doc2Arr, doc3Arr };
        }

        // under construction
        private void MainMenu()
        {
            // VAL:
            // 1. söka förekomster av ord?
            // -> VILL DU SPARA ORDEN?
            // 2. visa sparade ord.
            // 3. sortera dokumenten i bokstavsordning
            // -> Hur många ord vill du skriva ut till consolen från de sorterade dokumenten?

            List<string> menuItems = new List<string>()
            {
                "Search for a word",
                "Show saved words",
                "Sort documents in alphabetical order",
                "Exit",
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = Menu.DrawMenu(menuItems);
                if (selectedMenuItem == "Search for a word")
                {
                    Console.Clear();
                    Console.WriteLine("option 1");
                    SearchForAWord();
                }
                else if (selectedMenuItem == "Show saved words")
                {
                    Console.Clear();
                    Console.WriteLine("option 2");
                    ShowSavedWords();
                }
                else if (selectedMenuItem == "Sort documents in alphabetical order")
                {
                    Console.Clear();
                    Console.WriteLine("option 3");
                    SortDocumentsInAlphabetOrder();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Console.WriteLine("bye bye");
                    Environment.Exit(0);
                }
            }
        }

        private void SortDocumentsInAlphabetOrder()
        {
            // Skapa en ny List och sedan använda List.Sort()? fast det blir kanske inte så snabbt i sådanna fall.
            throw new NotImplementedException();
        }

        // under construction
        private void ShowSavedWords()
        {
            if (listOfSearchedWords.Count > 0)
            {
                for(int i = 0; i < listOfSearchedWords.Count; i++)
                {
                    Console.WriteLine(listOfSearchedWords[i]);
                }
            }
            else if (listOfSearchedWords.Count == 0)
            {
                Console.WriteLine("You have no saved searches.");
            }
        }

        // under construction
        private void SearchForAWord()
        {

            // Algorithm to implement: https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm

            Console.Clear();
            Console.Write("Enter word to search for: ");
            string input = Console.ReadLine();
            Console.WriteLine("\n");

            listOfSearchedWords.Add(input);


            //if(DoesWordExistInDocuments(out index, out nrOfTimes))
            //{
            //    Console.WriteLine($"{input} does exist");
            //}
            //else
            //{
            //    Console.WriteLine($"{input} does not exist");
            //}


            // string s = "iojfkosefoiklasejflöiasejfioSlsaejfilsejfiolsefjilHJKHJKHJKHKJH"
            
            // string p = "fiol"
            // string p = "ostenisotuiawdghawkldhlawukdhuklawdhukla"
            // O(m)

            // O(n)

            //O(n+m)

            SearchForAWordSubMenu();
        }

        // under construction
        private void SearchForAWordSubMenu()
        {
            
        }
    }
}