/*
 * Author : MATHAN VAITHILINGAM
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnaSequenceApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Predefined set of DNA sequence
            IDictionary<string, string> dnaSequenceList = new Dictionary<string, string>();
            dnaSequenceList.Add("DNA-1", "ctatcaatggggacgcctaacggcgaccgagatattgtcgcactagtcacgtacccgcgatagccgccaaaggccgtgcattgtgaacgatactaagaaccccgttcagggttatctgtcgaggcactttcggggcccctcgctctcctctcgtgcggtcggctgaatgagagtggataagaaatcgtcgcacagaccgttgcgatactaagtcccatggcctcgaggggtagcctcctttagctgtaccactctgttccattaactattcaacctgcacaccaacacttttactttttattactcagtggggacggtagttaggaagtgacagattataagagaatcaccaatctgggggattgaccgcgctcatggctgaaccatcgcgctcaccgcagatggatccgaaagataaatgtagtcactcgacgggcagatggttccgcagcgctagaaccgtgaaagacagctacaaaggctggctattctgatttacgaagccttgccactgagagtcagcggcagcgacttcgaccagtgaaccggccaggtctccactcagtgcggccaaagcagcataaccctacccctgaagacgttctctttgattcaaccttcttagcttcgataagtatagcatgatttcgaacagagcgccagccagaaagtctcaaccgaatacgacgccccaaacacatgaatttgcaagcgaacactacgaaagaactagccatgggtgtcaattttctctatcatttggtagagctgtctctcagtatgcatagtactgcagaaagcgtggagtctgatgcatcttcacgaaccccggaataggtcttgtgaactaaacgcatctattgttttaaccgtgcgccccatgatcgcagttggccatgccgatgtcttccttccctactctcacaagacatggctcagtgacgagatcgggaggacgctttttctgttcccttcggtcgtgaccatcttaccttacgca");
            dnaSequenceList.Add("DNA-2", "cagcgtgcatatgacttggaactatcaaacgatcttgagtacccacagaggttagaactcccctacatttcgatccgaccgacacataaaccactcatgcatacgtttatacctattttgacgcaatcttgccgattctacgcggatagtggcgcaaagggtcgagccagaagtctcgtctggcttgacaggttgccctacggtcatggcttccggtcagtaaaggacgttatgcgagcaggggcacgatggatatgcaaattgtacgccaggatcaacgcggcgaagtacgcgcgccgctgtgagcttgtacagacacatcgagatcattccactctgcccctttgcgcggaacgccccaatctcatagctcattgcctttggacacagctctagcacaaagaagccatgactagaaaaaatcgactcttggggtcccgtagcgctaattatagcctggtaattccgatcctatttatggtatgcgaaggagtcagacaccagacggcagtcaagggcactaatcattcctctgttctgcatgggcgtcgaccactgcatagctttggtccactctaataatagaacaccgctgtttaagatcttatttctgccaaaaccgccgaaatggcctgatggaactatgcttggtagcttcgaagctagatttcttcggccgcgcggctacagatagccgtacctgcccctaggtgggaggccatccaaggcgggactgttgatgaattttgagcgtctactaactcaaatataacactatcgggtgtttcgtattgacatcacggtaaattagacgagacgtcgggggcaggttttgactgaggtcacagggattcggatggtgtgaatgtagctgcgagcaccgaacactgcatgatagtagtattacgtatagcaaactcgctcttgcaaacattggcacctttggttctgcggaaccgtccgccaaatccgcgtgcgtcccctcaccaatgaagtggct");
            dnaSequenceList.Add("DNA-3", "ccatgcgtcaacggaattataataagcacaactacccataatggtgtgaacggtatgtctcgtagctagacgccaatacaatttgattcaatgactcgggatataacgtcttgacccctcatataccggcctagcgctcc");
            dnaSequenceList.Add("DNA-4", "caatagtagctttagaaccgttattggaaatccgcagcccgactcatcgagcaaggagcgtgagttccgaagtaacgtccgcaaacgaccagcggtggcatcgtgttggtaccccccacctctacccgatgttttgtcaagcctcgcggtttggtggggaggttccttcgagggcccggcagggcgagtaaataccgaca");
            dnaSequenceList.Add("DNA-5", "gacgatgaggtgcctgagcggctggtgcgtttaggcacgtgaggaaagatgagaccattctggttagcatcataatcaaaagtccgagggggtgtacgggcgagtaccgtgttgtactgaacagaacgaggggtctggcaaaaagacttgttaaagcgctcgaaattgggcttgctgttggtaatgatctgccatcgacacaccaaagggaagtgtccgcatatagtactagcttctgtcagggctacac");
            dnaSequenceList.Add("DNA-6", "gtatccaggaccgttgaatatacccagggtcgcactgctttgcgtaaattactcacattgaactatatatgtgtaagcccgtttcgccactcaggttcctatgttgtcggacgcgtcaaactgcgatggagcgttgcgcaagcgaaattaaatagacgtcagattcggcttggcgcattcttcgagctttgtcaagacctcatggtggtagacggaatcaaagcttctctgtaggcgcaataactgtccccacacgcggctctgttcacagtctcccttagtcagatcgggagtagtgtc");
            dnaSequenceList.Add("DNA-7", "cgaaatgtggccgagtaggggccgatccataaaggcgggttcgctttcgacgagacggtgtagccttcttgccttcctcgagttccttgagagcaaggtaagtgacaaaagttcccgccgtcctccgtctgtagactgctaggttggggatatgacgcacgactcacagaagaccgtgataatgagcgtcgcaggtaagcacccacacctacaattgtgcgttccagggctggatatactcgtaggcatcaaatgatggcttagcggtattttagtgaagatctgcgggaaccctcatctcaagtaggctgtagggagcgctctaaggctgctcaccgtgccattccgacagatccggctctttttgccactagctgccgtctgcggcaccgcccgccctaccattagcttcaacgatacagaaaatcggcaattcgggtcacctttggggggttctccacagacctttcatccctgagccgtggtaaagggccaacaaaagctagtggacagaaatacgtcaatagacgaattactctagacaatgctcaaggatacgtagaagatttttcaacatcgcgctatactactagtcacgaggggcaagtctgtctaacacagaggtctttcgtaaggaattcgtaacggtaagacccctggttcctttcacgagagtaaactagaaatagtctgcgccaggcatgatgggagcacttttacggcagcatcggcgccacctccgttggtagacccggtggacttatcggtcgcctcgcgcgtttggtttctggggccctatctaaggcaatgatttaacgtctgagtgagggaatacgtggattaaatcgctcgctagtctcttagggcgcccgtttagacacgggctctcaattaactaca");
            dnaSequenceList.Add("DNA-8", "aaattgatacgaaatcattacaggatgcagcgggcgccagtcccccaattgagcttccacagtcattagcctcatacccagacctcctagttacatgaaccgatagagctcagggtgttgtcggcttgacttgaatattctccgctgatgttgactataacacatggggctagattgcagcacaatagatgacagcgagggcggccatggcctttcgtagtcccttccccatctctaatattcccacctctcgcgtctgttttataataatcatttcaaaatcgctgttcgaatccggtgcccactatgcgcatagtccggtagagagatccattccgcgttgcaagaggacagcggtcgttcttttgcccttagcgccgtcgcctactggtatccaaaccgtagggccgggtgacattggaattctgcgagcacggcaatccctgggcttttcccaagatattggggatattccatctggtactcctattgacgcagtcaataaacggtcctttgtcgtgagctatctcaaggggtgaaacctgttggcttatccccttggattgtcggatagtactgtagcatttcaggctccgtaggtagtgtaaagcatagtcccgacgatcgagccgcgagagaagcagttaaccaagaggcgggtaatatgttcagtttttcaacaagcaattggaggtgcgca");
            dnaSequenceList.Add("DNA-9", "agcaaccatagagatcggcactttccgattaagcccagaagtctgtttcctatgtcgtctcggtcctccggaagttcaggactctcgccctggttcggtacgtgagctaacgtctgccattttcactgttaccctaaggccttgtgagcaagcgtcaatccgagtcgtctgcgttaatctccaaatcttaagcggtttgtcaactaccgcgcagcaggccaggccgtgcgacagatcgtgttgtcaacatacagttaatgggcacctggcgctggggatttatccgtctacaaatcatgctaccgccgccgttacttcggttcgtgtgccacgctgtacactgggggctttacacagactcgctgacgtgcatttccacgcggagacatcccgaacggtgccatagttgcacctttaataaagatgattggttgatacttttagtaggacgtactccacagggcgatgctgggctgttttgatgagggtacactgataaattagataacatacatctctgggcttcatggcctcaacccatcggaaaacacccataaggagtaccaaccagacacctgtcaatcgtctcctgtgcattgtggcgtctttataggggatgtttaaggggtctcgacgggggcccgacgttg");
            dnaSequenceList.Add("DNA-10", "ctagcaagtcctaaaccactgcgtttgttgacagcttcgttctgggacacgcgcctgagcgaccaatgcgtagctagcgcgcctgctgagggggacttcctgacttctagaaagctcggtgaaattggccactgagtatgtatggtgaacgatatccccacggtctatcgcccccccattatccggaacaagggactttgctacttggactgaccaaccttgagtttcttacaacaatcgcatttcatccaggctttctcggacatcgatagaaccgtttgcggtctttagcccatgattcacgcgccatgccgggacattgaaggggctgttcacttgctgacctgagacttaaggaccggggagctgccagaattgttgcggcacatcaaactgctggttaggcagtaaataaaccagaactggcctccgtatggcctcccggcgcgagggtcgagcacatgagagtaagaaccaagacaatagggatggttaatatt");

            do
            {
                Console.Write("\n\n Enter search DNA sequence text from predefined List :");
                string matchSearch = Console.ReadLine();

                Console.Write("Number of mismatch character allowed :");
                int mismatchAllowed = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n METHOD-1 => DnaSequenceMatchCheck - Iterate all DNA sequence in the dictionary and search exact match or all possible match with allowed mismatch count :- \n");

                //Iterate all DNA sequence in the dictionary and search exact match or all possible match with allowed mismatch count
                foreach (var item in dnaSequenceList)
                {
                    IList<string> results = DnaSequenceMatchCheck(item.Value, matchSearch, mismatchAllowed);

                    if (results.Count() == 0)
                    {
                        Console.WriteLine("The DNA ID is (" + item.Key + ") - DNA Sequence exact match or all allowed mismatch are not found");

                    }
                    else
                    {
                        Console.WriteLine("The DNA ID is (" + item.Key + ") - DNA Sequence exact match or all allowed mismatch search result are,");

                        foreach (string result in results)
                        {
                            Console.WriteLine(result);
                        }
                    }

                    Console.WriteLine("\n ============================================================ \n");


                }

                Console.WriteLine("\n ============================================================ \n");

                Console.WriteLine("\n METHOD-2 => DnaSequenceNearestMatchCheck - Iterate all DNA sequence in the dictionary and search exact match or first occurrence of nearest match with allowed mismatch count :- \n");

                //Iterate all DNA sequence in the dictionary and search exact match or nearest match with allowed mismatch count
                foreach (var item in dnaSequenceList)
                {
                    IList<string> results = DnaSequenceNearestMatchCheck(item.Value, matchSearch, mismatchAllowed);

                    if (results.Count() == 0)
                    {
                        Console.WriteLine("The DNA ID is (" + item.Key + ") - DNA Sequence exact match or first occurrence of nearest nearest match within allowed mismatch are not found");

                    }
                    else
                    {
                        Console.WriteLine("The DNA ID is (" + item.Key + ") - DNA Sequence exact or first occurrence of nearest match search result are,");

                        foreach (string result in results)
                        {
                            Console.WriteLine(result);
                        }
                    }

                    Console.WriteLine("\n ============================================================ \n");

                }

                Console.WriteLine("\n ============================================================ \n");

                Console.Write("Press 'ESC' key to stop or press any other key to continue next search cycle : ");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        /// <summary>
        ///  DNA Sequence check Algorithm (This will find exact match or all possible match based on allowd mismatch character count limit)
        /// </summary>
        /// <param name="sequence">The DNA Sequence string need to be searched</param>
        /// <param name="matchSearchText">The match string need to search in DNA sequence</param>
        /// <param name="allowedMismatchCharCount"> Number of mismatch character allowed in the search</param>
        public static IList<string> DnaSequenceMatchCheck(string sequence, string matchSearchText, int allowedMismatchCharCount)
        {
            IList<string> result = new List<string>();

            //To make Case insensitive search
            sequence = sequence.ToLower();
            matchSearchText = matchSearchText.ToLower();

            if (sequence.Contains(matchSearchText))
            {
                result.Add(string.Format( "Exact Match found at {0} index location; The found characters are : {1}", sequence.IndexOf(matchSearchText), matchSearchText));
            }
            else
            {
                //Allowed mismatch character limit should be less than actual search text (match)
                if (matchSearchText.Count() <= allowedMismatchCharCount)
                {
                    result.Add("The allowed mismatch character count should be less than search text count");
                }
                else
                {
                    int n = sequence.Count(), m = matchSearchText.Count();
                    StringBuilder sb = new StringBuilder();
                    int k = 0; //Allowed mismatch character counter

                    for (int i = 0; i < n; i++)
                    {
                        k = 0; //Allowed mismatch character counter
                        sb.Clear();

                        for (int j = 0; j < m && (i + j) < n; j++)
                        {
                            sb.Append(sequence[i + j]);

                            if (sequence[i + j] != matchSearchText[j])
                            {
                                k++;
                            }

                            if (k > allowedMismatchCharCount)
                            {
                                break;
                            }
                            if ((j + 1) == m)
                            {
                                result.Add(string.Format("The number of charater mismatch is {0}; The match found in {1} index location ; The found text is : {2}", k.ToString(), i.ToString(), sb.ToString()));
                            }
                        }
                    }
                }
            }

            return result;
        }


        /// <summary>
        ///  DNA Sequence Nearest check Algorithm (This will find Exact match or First occurrence of Lowest character Mismatch on allowed mismatch character count limit )
        /// </summary>
        /// <param name="sequence">The DNA Sequence string need to be searched</param>
        /// <param name="matchSearchText">The match string need to search in DNA sequence</param>
        /// <param name="allowedMismatchCharCount"> Number of mismatch character allowed in the search</param>
        public static IList<string> DnaSequenceNearestMatchCheck(string sequence, string matchSearchText, int allowedMismatchCharCount)
        {
            IList<string> result = new List<string>();

            //To make Case insensitive search
            sequence = sequence.ToLower();
            matchSearchText = matchSearchText.ToLower();

            if (sequence.Contains(matchSearchText))
            {
                result.Add(string.Format("Exact Match found at {0} index location; The found characters are : {1}", sequence.IndexOf(matchSearchText), matchSearchText));
            }
            else
            {
                //Allowed mismatch character limit should be less than actual search text (match)
                if (matchSearchText.Count() <= allowedMismatchCharCount)
                {
                    result.Add("The allowed mismatch character count should be less than search text count");
                }
                else
                {
                    int n = sequence.Count(), m = matchSearchText.Count();
                    StringBuilder sb = new StringBuilder();
                    int k = 0; //Allowed mismatch character counter
                    int lowestMismatchCount = int.MaxValue;

                    for (int i = 0; i < n; i++)
                    {
                        k = 0; //Allowed mismatch character counter
                        sb.Clear();

                        for (int j = 0; j < m && (i + j) < n; j++)
                        {
                            sb.Append(sequence[i + j]);

                            if (sequence[i + j] != matchSearchText[j])
                            {
                                k++;
                            }

                            if (k > allowedMismatchCharCount)
                            {
                                break;
                            }
                            if ((j + 1) == m)
                            {
                                if (lowestMismatchCount > k)
                                {
                                    lowestMismatchCount = k;
                                    result.Clear();
                                    result.Add(string.Format("The lowest number of charater mismatch is {0}; The first occurrence of nearest match found in {1} index location ; The found text is : {2}", k.ToString(), i.ToString(), sb.ToString()));

                                    if (lowestMismatchCount == 1)
                                    {
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
