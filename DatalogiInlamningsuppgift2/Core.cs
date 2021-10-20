using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if(Utils.TxtToArr(FILE_PATH_1, out doc1Arr, out errormsg) && 
                Utils.TxtToArr(FILE_PATH_2, out doc2Arr, out errormsg) && 
                Utils.TxtToArr(FILE_PATH_3, out doc3Arr, out errormsg))
            {
                stopwatch.Stop();
                Console.WriteLine("Texts from three documents loaded successfully into string[] arrays in " + stopwatch.Elapsed + "\n");

                stopwatch = new Stopwatch();
                stopwatch.Start();
                documents = Utils.SortArrays(doc1Arr, doc2Arr, doc3Arr);
                stopwatch.Stop();
                Console.WriteLine("Text sare now sorted in arrays with heapsort in "+ stopwatch.Elapsed + "\n");

                stopwatch = new Stopwatch();
                stopwatch.Start();
                bintreeArr = Utils.InsertIntoBinaryTree(documents);
                stopwatch.Stop();

                Console.WriteLine("Texts are now inserted into a sorted into three binary trees in " + stopwatch.Elapsed + "\n");
                
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
                    SearchForAWord();
                }
                else if (selectedMenuItem == "Show saved words")
                {
                    Console.Clear();
                    ShowSavedWords();
                }
                else if (selectedMenuItem == "Sort documents in alphabetical order")
                {
                    Console.Clear();
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

            // Algorithm to implement:

            Console.Clear();
            Console.Write("Enter word to search for: ");
            string input = Console.ReadLine();
            Console.WriteLine("\n");
            
            int count = 0;
            String result = "";
            Stopwatch stopwatch = new Stopwatch();
            if (input != String.Empty)
            {

                for (int i = 0; i < bintreeArr.Length; i++)
                {

                    //TODO HERE WE ARE 
                    if (bintreeArr[i].FindNode(out count, input))
                    {
                        stopwatch.Stop();
                        Console.WriteLine("Found word in " + stopwatch.Elapsed);
                        Console.WriteLine(input);
                        Console.WriteLine(count);

                    }

                }
            }
            else
            {
                Console.WriteLine("word does not exist");
            }
            stopwatch.Stop();
            

            listOfSearchedWords.Add(input);

            //foreach(var binTree in bintreeArr)
            //{
            //    Console.Write($"{binTree.GetHighestCountOfWord(out count, input)} NR OF TIMES: {count}");
            //}
            

            //SearchForAWordSubMenu();
        }

        // under construction
        private void SearchForAWordSubMenu()
        {
            
        }

        private void twoForLoops(string input)
        {
            // testing for in for O(n*n) Speed
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int counter = 0;
            bool found = false;
            for (int i = 0; i < documents.Length; i++)
            {
                for (int j = 0; j < documents[i].Length; j++)
                {
                    if (documents[i][j] == input)
                    {
                        counter++;
                        found = true;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("\nFor loop counter = " + counter);
            Console.WriteLine("Found word in " + stopwatch.Elapsed + "\n");
        }
    }
}