using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    public partial class yahtzee_form : Form
    {
        public yahtzee_form()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Visible = false;
            roll.Visible = true;
            game();
        }

        public bool rollClicked = false;
        public int rollClickedTimes = 0;
        public bool player_move = false;
        public bool computer_move = false;
        public int dOne, dTwo, dThree, dFour, dFive;
        public int p_total = 0;
        public int c_total = 0;
        public bool game_over = false;

        public int getNumbers()
        {
            int ones = 0;
            int twos = 0;
            int threes = 0;
            int fours = 0;
            int fives = 0;
            int sixes = 0;
            int[] numbersArray;
            numbersArray = new int[5] { dOne, dTwo, dThree, dFour, dFive };
            
            for (int i = 0; i < numbersArray.Length; i++)
            {
                switch (numbersArray[i])
                {
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                    case 3:
                        threes++;
                        break;
                    case 4:
                        fours++;
                        break;
                    case 5:
                        fives++;
                        break;
                    case 6:
                        sixes++;
                        break;
                }
            }

            errors.Text = "Testing this up in here!.\n You currently have " + ones + " ones, " + twos + " twos, " + threes + " threes,\n " + fours + " fours, " + fives + " fives,\n " + sixes + " sixes.";
            return ones;
        }

        public void playerHands()
        {
            
        }

        public void resetRolls()
        {
            rollClickedTimes = 0;
            dice_one.Text = "";
            dice_one.Checked = false;
            dice_two.Text = "";
            dice_two.Checked = false;
            dice_three.Checked = false;
            dice_three.Text = "";
            dice_four.Text = "";
            dice_five.Text = "";
            dice_four.Checked = false;
            dice_five.Checked = false;
            dOne = 0;
            dTwo = 0;
            dThree = 0;
            dFour = 0;
            dFive = 0;
            errors.Text = "";
            player_move = true; // remove when computer A.I comes into play
        }

        public void updateScore()
        {
            player_total.Text = "Total: " + p_total.ToString();
        }

        public void gameOver()
        {
            if (!player_ones.Enabled && !player_twos.Enabled && !player_threes.Enabled && !player_fours.Enabled && !player_fives.Enabled && !player_sixes.Enabled && !player_threek.Enabled && !player_fourk.Enabled && !player_fullhouse.Enabled && !player_largestr.Enabled && !player_smallstr.Enabled && player_yahtzee.Text != "Yahtzee!" && !player_chance.Enabled)
            {
                game_over = true;
                player_move = false;
                computer_move = false;
                errors.Text = "Game over!";
                if (p_total > c_total) errors.Text += " You win!";
                else if (p_total == c_total) errors.Text += " You Tie!";
                else if (c_total > p_total) errors.Text += " You lose!";
            }
        }

        public void computerPossibleMoves()
        {
            int[] compDice;
            compDice = new int[] { dOne, dTwo, dThree, dFour, dFive };
            int[] sortCompDice = (from element in compDice orderby element ascending select element).ToArray();
            // program possible A.I moves here.
            int distinctNums = compDice.Distinct().Count();
            switch (distinctNums)
            {
                case 1:
                    bool cYahtzee = true;
                    break;
                case 2:
                    // full house or 4 of a kind
                    if (sortCompDice[0] == sortCompDice[1] && sortCompDice[1] == sortCompDice[2] && sortCompDice[2] == sortCompDice[3] || sortCompDice[1] == sortCompDice[2] && sortCompDice[2] == sortCompDice[3] && sortCompDice[3] == sortCompDice[4]) 
                    { 
                        bool comp4K = true; 
                    }
                    else 
                    { 
                        bool compFH = true; 
                    }
                    break;
                case 3:
                    bool c3oK = true;
                    break;
                case 4:
                    break;
                case 5:
                    bool cLS = true;
                    break;
                default:
                    // sort the other dice here. Compare a all 6 possible numbers to all the numbers in an array and for each that returns true, add a true to the array. Whichever has more true = what computer will go with.
                    break;
            }
            
        }

        public void computerMove()
        {
            // AI logic here
            if (computer_move)
            {
                
            }
        }

        private void roll_Click(object sender, EventArgs e)
        {
            if (player_move || computer_move)
            {
                if (rollClickedTimes < 3) // set the d variables to = the dice to use later.
                {
                    Random dRandom = new Random();
                    if (!dice_one.Checked) dOne = dRandom.Next(1, 7); dice_one.Text = dOne.ToString();
                    if (!dice_two.Checked) dTwo = dRandom.Next(1, 7);  dice_two.Text = dTwo.ToString();
                    if (!dice_three.Checked) dThree = dRandom.Next(1, 7); dice_three.Text = dThree.ToString();
                    if (!dice_four.Checked) dFour = dRandom.Next(1, 7); dice_four.Text = dFour.ToString();
                    if (!dice_five.Checked) dFive = dRandom.Next(1, 7); dice_five.Text = dFive.ToString();
                    rollClickedTimes++;
                    getNumbers(); // displays numbers that users have, however this function will probably change to determining roll amount for what spot it takes.
                }
                else
                {
                    errors.Text = "You must take your score!";
                    player_move = false;
                    rollClickedTimes = 0;
                }
            }
        }

        private void game()
        {
            player_move = true;
        }

        private void player_ones_Click(object sender, EventArgs e)
        {
            int playerOneTotal = 0;
            if (dOne == 1) playerOneTotal = playerOneTotal + 1;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 1) playerOneTotal = playerOneTotal + 1;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 1) playerOneTotal = playerOneTotal + 1;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 1) playerOneTotal = playerOneTotal + 1;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 1) playerOneTotal = playerOneTotal + 1;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_ones.Text += ": " + playerOneTotal.ToString();
                p_total += playerOneTotal;
                player_ones.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_twos_Click(object sender, EventArgs e)
        {
            int playerTwoTotal = 0;
            if (dOne == 2) playerTwoTotal = playerTwoTotal + 2;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 2) playerTwoTotal = playerTwoTotal + 2;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 2) playerTwoTotal = playerTwoTotal + 2;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 2) playerTwoTotal = playerTwoTotal + 2;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 2) playerTwoTotal = playerTwoTotal + 2;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_twos.Text += ": " + playerTwoTotal.ToString();
                p_total += playerTwoTotal;
                player_twos.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_threes_Click(object sender, EventArgs e)
        {
            int playerThreeTotal = 0;
            if (dOne == 3) playerThreeTotal = playerThreeTotal + 3;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 3) playerThreeTotal = playerThreeTotal + 3;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 3) playerThreeTotal = playerThreeTotal + 3;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 3) playerThreeTotal = playerThreeTotal + 3;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 3) playerThreeTotal = playerThreeTotal + 3;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_threes.Text += ": " + playerThreeTotal.ToString();
                p_total += playerThreeTotal;
                player_threes.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_fours_Click(object sender, EventArgs e)
        {
            int playerFourTotal = 0;
            if (dOne == 4) playerFourTotal = playerFourTotal + 4;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 4) playerFourTotal = playerFourTotal + 4;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 4) playerFourTotal = playerFourTotal + 4;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 4) playerFourTotal = playerFourTotal + 4;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 4) playerFourTotal = playerFourTotal + 4;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_fours.Text += ": " + playerFourTotal.ToString();
                p_total += playerFourTotal;
                player_fours.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_fives_Click(object sender, EventArgs e)
        {
            int playerFiveTotal = 0;
            if (dOne == 5) playerFiveTotal = playerFiveTotal + 5;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 5) playerFiveTotal = playerFiveTotal + 5;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 5) playerFiveTotal = playerFiveTotal + 5;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 5) playerFiveTotal = playerFiveTotal + 5;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 5) playerFiveTotal = playerFiveTotal + 5;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_fives.Text += ": " + playerFiveTotal.ToString();
                p_total += playerFiveTotal;
                player_fives.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_sixes_Click(object sender, EventArgs e)
        {
            int playerSixTotal = 0;
            if (dOne == 6) playerSixTotal = playerSixTotal + 6;
            else if (dOne == 0) errors.Text = "You cannot take anything without rolling!";
            if (dTwo == 6) playerSixTotal = playerSixTotal + 6;
            else if (dTwo == 0) errors.Text = "You cannot take anything without rolling!";
            if (dThree == 6) playerSixTotal = playerSixTotal + 6;
            else if (dThree == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFour == 6) playerSixTotal = playerSixTotal + 6;
            else if (dFour == 0) errors.Text = "You cannot take anything without rolling!";
            if (dFive == 6) playerSixTotal = playerSixTotal + 6;
            else if (dFive == 0) errors.Text = "You cannot take anything without rolling!";
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_sixes.Text += ": " + playerSixTotal.ToString();
                p_total += playerSixTotal;
                player_sixes.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_threek_Click(object sender, EventArgs e)
        {
            int[] checkThree;
            int threeOfKindTotal = 0;
            checkThree = new int[5] {dOne, dTwo, dThree, dFour, dFive};
            int checkKind = checkThree.Distinct().Count();
            if (checkKind > 2) threeOfKindTotal = dOne + dTwo + dThree + dFour + dFive;
                if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
                {
                    player_threek.Text += ": " + threeOfKindTotal.ToString();
                    p_total += threeOfKindTotal;
                    player_threek.Enabled = false;
                    updateScore();
                    resetRolls();
                    gameOver(); // run this every time something is clicked.
                }
        }

        private void player_fourk_Click(object sender, EventArgs e)
        {
            // fix this so that it works prperly.
            int[] checkFour;
            int fourOfKindTotal = 0;
            checkFour = new int[5] { dOne, dTwo, dThree, dFour, dFive };
            //int checkFourKind = checkFour.Distinct().Count();
            int[] sort4kDice = (from element in checkFour orderby element ascending select element).ToArray();
            if ((sort4kDice[0] == sort4kDice[1] && sort4kDice[1] == sort4kDice[2] && sort4kDice[2] == sort4kDice[3]) || (sort4kDice[1] == sort4kDice[2] && sort4kDice[2] == sort4kDice[3] && sort4kDice[3] == sort4kDice[4])) fourOfKindTotal = dOne + dTwo + dThree + dFour + dFive;
            
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_fourk.Text += ": " + fourOfKindTotal.ToString();
                p_total += fourOfKindTotal;
                player_fourk.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_fullhouse_Click(object sender, EventArgs e)
        {
            // full house needs 3 distinct numbers and 2 distinct numbers...look into it.
            int fullHouseTotal = 0;
            int[] fullHouseChecker;
            fullHouseChecker = new int[5] { dOne, dTwo, dThree, dFour, dFive };
            int[] sortDice = (from element in fullHouseChecker orderby element ascending select element).ToArray();
            if ((sortDice[0] == sortDice[1] && sortDice[1] == sortDice[2] && sortDice[3] == sortDice[4]) || (sortDice[0] == sortDice[1] && sortDice[2] == sortDice[3] && sortDice[3] == sortDice[4])) fullHouseTotal = 25; 
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_fullhouse.Text += ": " + fullHouseTotal.ToString();
                p_total += fullHouseTotal;
                player_fullhouse.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_chance_Click(object sender, EventArgs e)
        {
            int chanceScore = 0;
            chanceScore += dOne + dTwo + dThree + dFour + dFive;
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_chance.Text += ": " + chanceScore.ToString();
                p_total += chanceScore;
                player_chance.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_yahtzee_Click(object sender, EventArgs e)
        {
            // make yahtzee able to get multiple times
            int yahtzeeTotal = 0;
            if (dOne == dTwo && dTwo == dThree && dThree == dFour && dFour == dFive) if (yahtzeeTotal == 0) yahtzeeTotal = 50;
                else yahtzeeTotal += 100;
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_yahtzee.Text += ": " + yahtzeeTotal.ToString();
                p_total += yahtzeeTotal;
                //player_yahtzee.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_smallstr_Click(object sender, EventArgs e)
        {
            // glitch: if duplicate of a small str number, it won't count it!
            int smallStraightTotal = 0;
            int[] smallstrDice;
            smallstrDice = new int[] { dOne, dTwo, dThree, dFour, dFive };
            int[] smallStrSort = (from element in smallstrDice orderby element ascending select element).ToArray();
            string checkSS = smallStrSort[0] + "" + smallStrSort[1] + "" + smallStrSort[2] + "" + smallStrSort[3] + "" + smallStrSort[4];
            string[] possibleSS;
            possibleSS = new string[] { "1234", "2345", "3456" };
            if (possibleSS.Any(checkSS.Contains)) smallStraightTotal = 30;
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_smallstr.Text += ": " + smallStraightTotal.ToString();
                p_total += smallStraightTotal;
                player_smallstr.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

        private void player_largestr_Click(object sender, EventArgs e)
        {
            // Glitch: possibly same as small straights
            int largeStraightTotal = 0;
            int[] largestrDice;
            largestrDice = new int[] { dOne, dTwo, dThree, dFour, dFive };
            int[] largeStrSort = (from element in largestrDice orderby element ascending select element).ToArray();
            string checkSS = largeStrSort[0] + "" + largeStrSort[1] + "" + largeStrSort[2] + "" + largeStrSort[3] + "" + largeStrSort[4];
            string[] possibleSS;
            possibleSS = new string[] { "12345", "23456" };
            if (possibleSS.Any(checkSS.Contains)) largeStraightTotal = 40;
            if (dOne != 0 || dTwo != 0 || dThree != 0 || dFour != 0 || dFive != 0)
            {
                player_largestr.Text += ": " + largeStraightTotal.ToString();
                p_total += largeStraightTotal;
                player_largestr.Enabled = false;
                updateScore();
                resetRolls();
                gameOver(); // run this every time something is clicked.
            }
        }

    }
}
