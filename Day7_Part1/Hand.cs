using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Part1
{
    internal class Hand
    {
        private string hand;
        public int bet;     
        private string labels = "  23456789TJQKA";
        public int[] LabelRank
        {
            get
            {

                int[] labels = new int[5];

                for (int i = 0; i < hand.Length; i++) 
                {
                    labels[i] = this.labels.IndexOf(hand[i]);                    
                }

                return labels;
            }
        }



        public int HandRank
        {
            get
            {
                int[] counts = new int[hand.Length];

                for (int i = 0; i < hand.Length; i++) 
                { 
                    for (int j = 0; j < hand.Length; j++)
                    {
                        if (hand[i] == hand[j])
                        {
                            counts[i]++;
                        }
                    }
                }
 
                int matches = counts.Max();
                char match = hand[Array.IndexOf(counts, counts.Max())];

                if (matches == 5)
                {
                    return 7;
                }
                else if (matches == 4)
                {
                    return 6;
                }
                else if (matches == 3)
                {
                    char char1 = ' ';
                    char char2 = ' ';
                    int count = 0;

                    for (int i = 0; i < hand.Length; i++)
                    {
                        
                        
                        if (hand[i] != match)
                        {
                            if (count == 0)
                            {
                                char1 = hand[i];
                                count++;
                            }
                            else
                            {
                                char2 = hand[i];
                            }
                        }
                    }

                    if (char1 == char2)
                    {
                        return 5;
                    }
                    else
                    {
                        return 4;
                    }
                }
                else if (matches == 2)
                {
                    char char1 = ' ';
                    char char2 = ' ';
                    char char3 = ' ';
                    int count = 0;

                    for (int i = 0; i < hand.Length; i++)
                    {

                        if (hand[i] != match)
                        {
                            if (count == 0)
                            {
                                char1 = hand[i];
                                count++;
                            }
                            else if (count == 1)
                            {
                                char2 = hand[i];
                                count++;
                            }
                            else
                            {
                                char3 = hand[i];
                            }
                        }
                    }

                    if (char1 == char2 || char1 == char3 || char2 == char3)
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }

                }
                else
                {
                    return 1;
                }
            }
        }

        public Hand(string hand, int bet) 
        { 
            this.hand = hand;
            this.bet = bet;
        }

        public override string ToString()
        {
            return hand + " -- " + HandRank.ToString();
        }
    }
}
