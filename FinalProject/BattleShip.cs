/// Chapter No. Lecture  10	Exercise No. 1
/// File Name: 
/// @author: Alvaro Espinoza
/// Date:  December 2, 2019
///
/// Problem Statement: Code that holds the logic for the battlship game made with GUI 
/// 
/// Instance Variables: 
/// List<Button> playerPosition- List of Buttons that holds the positon Buttons that the player chooses  
/// List<Button> enemyPostition- List of Buttons that holds the positon Buttons that the enemy chooses  
/// Random random - random object that creates random rumbers for the enemy positions for attacking and location finding 
/// int totalShips - total number of ships that the player has 
/// int totalEnemy - total number of ships enemy has 
/// int rounds- total number od rounds in the gane 
/// int playerTotalScore- total for the player score; increased with every enemey destoryed 
/// int enemyTotalScore- total for the enemy score ; increased with every player ship destroyed 
/// 
///Methods- 
///
/// void void playerPicksPosition()- lets player pick three postions for there ships, this allows the player to pick
/// postions for their ships at the beginging of the game 
///
/// void attackEnemyPosition(object sender, EventArgs e)- allows player to attack eneemny postion 
/// by using drop down list to allow player to choose a position
///  
/// void attackEnemyPosition(object sender, EventArgs e)- allows player to attack eneemny postion 
/// by using drop down list to allow player to choose a position
/// calls base ToString Method 
///  
/// void enemyAttackPlayer(object sender, EventArgs e)- method that allows CPU 
/// to attack the player 
/// 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; 

namespace FinalProject
{
    public partial class BattleShip : Form
    {
        List<Button> playerPosition;//position buttons for the player and enemy
        List<Button> enemyPosition;
        Random random = new Random();
        int totalShips = 5;//number of total ships for player and AI enemy 
        int totalEnemy = 5;
        int rounds = 20;//total number of rounds played for the game 
        int playerTotalScore = 0;//scores for the player and enemy 
        int enemyTotalScore = 0;

        public BattleShip()
        {
            InitializeComponent();
            loadButtons();
            randomFlag();
            attackButton.Enabled = false;//disables player attack button before game begins 
            enemyLocationList.Text = null;
        }
        //void void playerPicksPosition()- lets player pick three postions for there ships, this allows the player to pick 
        //postions for their ships at the beginging of the game 
        private void playerPicksPosition(object sender, EventArgs e)
        {
            //if totalShips variable is greater then 0 
            //we check which button was clicked and change its tag to say friendly ship and make it green and disable the button 
            if (totalShips > 0)
            {
                var button = (Button)sender;
                button.Enabled = false;
                button.Tag = "playerShip";
                button.BackColor = System.Drawing.Color.Green;
                totalShips--; 

            }
            //if botalShips is 0 then player has picked all postions and can now attack 
            // attackButton can now be enabled and color changed to Red 
            // the helpText is moved and changed to give player further instructions 
            if (totalShips ==0)
            {
                attackButton.Enabled = true;
                attackButton.BackColor = System.Drawing.Color.Red;
                helpText.Text = "Pick an attack position from drop down";
            }



        }

        //void attackEnemyPosition(object sender, EventArgs e)- allows player to attack eneemny postion 
        //by using drop down list to allow player to choose a position
        private void attackEnemyPosition(object sender, EventArgs e)
        {
            if (enemyLocationList.Text != "")
            {
                //var object used to get the text from the enemyLocationList 
                string attackPos = enemyLocationList.Text;
                string letter = attackPos[0].ToString().ToLower();
                string number = attackPos[1].ToString();
                attackPos = letter + number;
               
                //changes attackPos to lower case letter in order to correspond to proper button name 
                int index = enemyPosition.FindIndex(a => a.Name == attackPos);//index of the button in the List is found 

                //if the enemey button is stilled endabled and number of rounds is greater then 0 
                if (enemyPosition[index].Enabled && rounds > 0)
                {
                    //rounds is reduced and text for the rounds on screen is updated
                    rounds--;
                    roundsText.Text = "Rounds " + rounds;
                    if (enemyPosition[index].Tag == "enemyShip")
                    {
                        //if enemy postitions picked by player is an enemyShip then that button is disabled and updated to show image of fire
                        enemyPosition[index].Enabled = false;
                        enemyPosition[index].BackgroundImage = Properties.Resources.fireIcon;
                        enemyPosition[index].BackColor = System.Drawing.Color.DarkBlue;
                        playerTotalScore++;
                        //player score is increased and text on screen is updated 
                        playerScore.Text = "" + playerTotalScore;
                        //eneemyTimer is started 
                        enemyPlayTimer.Start();


                    }
                    else
                    {
                        //if player misses does not hit an enemyShip  then button is disabled and updated to show X image 
                        enemyPosition[index].Enabled = false;
                        enemyPosition[index].BackgroundImage = Properties.Resources.missIcon;
                        enemyPosition[index].BackColor = System.Drawing.Color.DarkBlue;
                        //eneemyTimer is started 
                        enemyPlayTimer.Start();

                    }

                }

            }
            else
            {
                //if player does not pick postion alert them using message box 
                MessageBox.Show("Choose position from drop down list");
            
            }

        }
        // void enemyAttackPlayer(object sender, EventArgs e)- method that allows CPU 
        //to attack the player 
        private void enemyAttackPlayer(object sender, EventArgs e)
        {
            if (playerPosition.Count > 0 && rounds > 0)
            {
                rounds--;//number of rounds is reduced and text on screen updated when enemy starts round
                roundsText.Text = "Rounds:" + rounds;

                int index = random.Next(playerPosition.Count);

                if (playerPosition[index].Tag == "playerShip")
                {
                    enemyMoves.Text = "" + playerPosition[index].Text;//label is updated to show enemy attack position
                    playerPosition[index].BackgroundImage = Properties.Resources.fireIcon;
                    //if player postitions picked by enemy is an enemyShip then that button is disabled and updated to show image of fire
                    playerPosition[index].Enabled = false;
                    playerPosition[index].BackColor = System.Drawing.Color.DarkBlue;
                    //removes button from playerList in order to prevent CPU from attacking agin
                    playerPosition.RemoveAt(index);
                    enemyTotalScore++;
                    //enemy score is increased and text on screen is updated 
                    enemyScore.Text = "" + playerTotalScore;
                    //eneemyTimer is started 
                    enemyPlayTimer.Stop();


                }
                else
                {
                    //if player misses does not hit an enemyShip  then button is disabled and updated to show X image 
                    playerPosition[index].Enabled = false;
                    enemyMoves.Text = "" + playerPosition[index].Text;//label is updated to show enemy attack position 
                    playerPosition[index].BackgroundImage = Properties.Resources.missIcon;
                    playerPosition[index].BackColor = System.Drawing.Color.DarkBlue;
                    playerPosition.RemoveAt(index);
                    //eneemyTimer is started 
                    enemyPlayTimer.Stop();

                }

            }
            //checks to see if player or CPU have won the game 
            if(rounds < 1 || playerTotalScore > 4 || enemyTotalScore > 4)
            {
                //displays image corresponding to players won 
                if (playerTotalScore > enemyTotalScore)
                {
                    MessageBox.Show("You WIN");
                
                }
                if (playerTotalScore == enemyTotalScore)
                {
                    MessageBox.Show("No one wins this, DRAW");

                }
                if (playerTotalScore < enemyTotalScore)
                {
                    MessageBox.Show("HHAAHHA! I sunk your BattleShip","Lost");

                }

            }
            

        }

        /// void enemyPicksPositions(object sender, EventArgs e)- method for CPU picking position in the game 
        private void enemyPicksPositions(object sender, EventArgs e)
        {
            int index = random.Next(enemyPosition.Count);

            if (enemyPosition[index].Enabled == true && enemyPosition[index].Tag ==null)
            {
                enemyPosition[index].Tag = "enemyShip";
                totalEnemy--;
                Debug.WriteLine("Enemy Position " + enemyPosition[index].Text);

            }
            else
            {
                index = random.Next(enemyPosition.Count);
            
            }
            if (totalEnemy < 1)
            {
                enemyPositionPicker.Stop();
            
            }


        }
        private void randomFlag()
        {
            string currentTime = DateTime.Now.ToString("h:mm tt");
            int minuteFirst = Int32.Parse(currentTime[2].ToString());
            int minuteSec = Int32.Parse(currentTime[3].ToString());
            
                if (minuteSec % 5 == 0)
                {
                    pictureEnemy.Image = Properties.Resources._220px_Flag_of_the_Ottoman_Empire_svg;
                }
                else if (minuteFirst == minuteSec)
                {
                    picturePlayer.Image = Properties.Resources._255px_Flag_of_the_United_Kingdom_svg;
                    pictureEnemy.Image = Properties.Resources._200px_Flag_of_German_Empire__jack_1903__svg;
                }
                else if (minuteSec % 2 == 0)
                {
                    pictureEnemy.Image = Properties.Resources._220px_Naval_Ensign_of_Japan_svg;

                }
                




 
            
        
        }
        //void loadButtons()- intialize list objects for the player and enemy postion and adds enemy postion elements into drop 
        //down list for player to pick postion later 
        private void loadButtons()
        {
            playerPosition = new List<Button> {w1,w2,w3,w4,x1,x2,x3,x4,y1,y2,y3,y4,z1,z2,z3,z4 };//intializes the list for the player and enemy postion with button elements from the list
            enemyPosition = new List<Button> {a1,a2,a3,a4,b1,b2,b3,b4,c1,c2,c3,c4,d1,d2,d3,d4 };

            //for loops from 0 to enemyPostion list size in order to add buttons into drop down list 
            for (int i =0; i < enemyPosition.Count;i++)
            {
                enemyPosition[i].Tag = null;
                enemyLocationList.Items.Add(enemyPosition[i].Text);
            }
        }

        private void BattleShip_Load(object sender, EventArgs e)
        {

        }
    }
}
