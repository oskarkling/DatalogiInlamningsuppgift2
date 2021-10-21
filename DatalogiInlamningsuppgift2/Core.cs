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
        private List<SearchResult> listOfResults;

        internal Core()
        {
            FILE_PATH_1 = @"\Textfiles\text1000.txt";
            FILE_PATH_2 = @"\Textfiles\text1500.txt";
            FILE_PATH_3 = @"\Textfiles\text3000.txt";
            listOfResults = new List<SearchResult>();
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
                Console.WriteLine("Texts from three .txt documents loaded successfully into string[] arrays. Operations took  " + stopwatch.Elapsed);

                stopwatch = new Stopwatch();
                stopwatch.Start();
                documents = Utils.SortArrays(doc1Arr, doc2Arr, doc3Arr);
                stopwatch.Stop();
                Console.WriteLine("Text sare now sorted in arrays. Operations took " + stopwatch.Elapsed);

                stopwatch = new Stopwatch();
                stopwatch.Start();
                bintreeArr = Utils.InsertIntoBinaryTree(documents);
                stopwatch.Stop();

                Console.WriteLine("Texts are now inserted into three sorted binary trees. Operations took " + stopwatch.Elapsed);
                
            }
            else
            {
                Console.WriteLine(errormsg);
                Environment.Exit(0);
            }
        }

        // under construction
        private void MainMenu()
        {
            List<string> menuItems = new List<string>()
            {
                "Search for a word",
                "Show saved words",
                "Sort documents in alphabetical order. Then print or save them as new txt files",
                "Exit",
            };

            Console.WriteLine("\nUse arrow keys to navigate the menu\n");

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
                else if (selectedMenuItem == "Sort documents in alphabetical order. Then print or save them as new txt files")
                {
                    Console.Clear();
                    PrintOrWriteSubMenu();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Console.WriteLine("bye bye");
                    Environment.Exit(0);
                }
            }
        }

        private void PrintOrWriteSubMenu()
        {

            List<string> menuItems = new List<string>()
            {
                "Print out words from sorted array",
                "Write sorted arrays to new txt files",
                "Back",
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = Menu.DrawMenu(menuItems);
                if (selectedMenuItem == "Print out words from sorted array")
                {
                    Console.Clear();
                    bool allDocuments = false;
                    int documentIndex = ChooseDocumentSubmenu(out allDocuments);

                    HowManyWordsToPrint(documentIndex, allDocuments);

                    return;
                }
                else if (selectedMenuItem == "Write sorted arrays to new txt files")
                {
                    Console.Clear();
                    if (Utils.WriteToFiles(documents))
                    {
                        Console.WriteLine("Wrote to new txt files located in Textfiles directory");
                    }
                    else
                    {
                        Console.WriteLine("Could not write new files");
                    }
                }
                else if (selectedMenuItem == "Back")
                {
                    Console.Clear();
                    return;
                }
            }
        }

        private void HowManyWordsToPrint(int documentIndex, bool allDocuments)
        {
            Console.WriteLine("Enter how many words");
            string input = Console.ReadLine();
            int validIntInput;
            string errormsg = "";
            if (Input.IsIntInputValid(input, out validIntInput, out errormsg, false))
            {
                validIntInput--;

                if(allDocuments)
                {
                    for(int i = 0; i < documents.Length; i++)
                    {
                        Console.WriteLine($"______document {i + 1} ________");
                        if (validIntInput < documents[i].Length)
                        {
                            for (int j = 0; j < validIntInput; j++)
                            {
                                Console.WriteLine(documents[i][j]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("prints all becouse input was too high");
                            for(int k = 0; k < documents[i].Length; k++)
                            {
                                Console.WriteLine(documents[i][k]);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"______document {documentIndex + 1} ________");
                    if (validIntInput < documents[documentIndex].Length)
                    {
                        for (int l = 0; l < validIntInput; l++)
                        {
                            Console.WriteLine(documents[documentIndex][l]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(errormsg);
            }

        }

        private int ChooseDocumentSubmenu(out bool allDocuments)
        {
            allDocuments = false;
            List<string> menuItems = new List<string>()
            {
                "Document 1",
                "Document 2",
                "Document 3",
                "All documents",
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = Menu.DrawMenu(menuItems);
                if (selectedMenuItem == "Document 1")
                {
                    Console.Clear(); 
                    return 0;
                }
                else if (selectedMenuItem == "Document 2")
                {
                    Console.Clear();
                    return 1;
                }
                else if (selectedMenuItem == "Document 3")
                {
                    Console.Clear();
                    return 2;
                }
                else if (selectedMenuItem == "All documents")
                {
                    Console.Clear();
                    allDocuments = true;
                    return 0;
                }
            }
        }

        // under construction
        private void ShowSavedWords()
        {
            int count = 0;
            if (listOfResults.Count > 0)
            {
                for (int i = 0; i < listOfResults.Count; i++)
                {
                    Console.WriteLine($"Word searched: {listOfResults[i].SearchWord} | {listOfResults[i].Document} | {listOfResults[i].Count} Occurances");
                    count++;
                    if (count % 3 == 0)
                    {
                        Console.WriteLine($"----------------------------------------------------- Search no. {count / 3}");
                    }
                }
                Console.WriteLine();
            }
            else if (listOfResults.Count == 0)
            {
                Console.WriteLine("You have no saved searches.\n");
            }
        }

        // under construction
        private void SearchForAWord()
        {
            Console.Clear();
            Console.Write("Enter word to search for: ");
            string input = Console.ReadLine();
            Console.WriteLine("\n");

            int count = 0;
            bool wordDidNotExist = false;
            bool canSaveResults = false;
            SearchResult[] resultsTempArr = Utils.InitializeArray<SearchResult>(3);
            Stopwatch stopwatch = new Stopwatch();
            if (input != String.Empty)
            {
                for (int i = 0; i < bintreeArr.Length; i++)
                {
                    stopwatch.Start();

                    if (bintreeArr[i].FindNode(out count, input))
                    {
                        canSaveResults = true;
                        stopwatch.Stop();
                        SearchResult result = new SearchResult();
                        result.Count = count;
                        result.SearchWord = input;
                        if (i == 0)
                        {
                            result.Document = "document 1";
                        }
                        else if (i == 1)
                        {
                            result.Document = "document 2";
                        }
                        else
                        {
                            result.Document = "document 3";
                        }

                        resultsTempArr[i] = result;

                        if (result.Count < 10)
                        {
                            Console.WriteLine($"{result.SearchWord} | {result.Document} | {result.Count}  Occurances | Found word in {stopwatch.Elapsed}");
                        }
                        else
                        {
                            Console.WriteLine($"{result.SearchWord} | {result.Document} | {result.Count} Occurances | Found word in {stopwatch.Elapsed}");
                        }
                    }
                    else
                    {
                        wordDidNotExist = true;
                        
                    }
                }
                if(wordDidNotExist)
                {
                    Console.WriteLine("Word does not exist.");
                }
                Console.WriteLine("\n");

                if(canSaveResults)
                {
                    SearchForAWordSubMenu(resultsTempArr);
                }

            }
            else
            {
                Console.WriteLine("Input was null.");
            }
            
        }

        // under construction
        private void SearchForAWordSubMenu(SearchResult[] resultsTempArr)
        {

            List<string> menuItems = new List<string>()
            {
                "Yes",
                "No",
            };
            Console.WriteLine("Do you want to save results?\n");
            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = Menu.DrawMenu(menuItems);
                if (selectedMenuItem == "Yes")
                {
                    Console.Clear();
                    for(int i = 0; i < resultsTempArr.Length; i++)
                    {
                        listOfResults.Add(resultsTempArr[i]);
                    }
                    Console.WriteLine("saved words!\n");
                    return;
                }
                else if (selectedMenuItem == "No")
                {
                    Console.Clear();
                    Console.WriteLine("not saving\n");
                    return;
                }
            }

        }

        // FOR TESTING SPEED
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