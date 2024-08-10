using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Dungeons_DragonsByScott
{
    public partial class Form1 : Form
    {
         
        Player _player;
        Monster _currentMonster;


        public Form1()
        {
            InitializeComponent();


            _player = new Player(20, 20, 30, 10, 1,10,true);
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));


            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            
            
        }
            

            private void  MoveTo(Location newLocation)
            {
                btnChest.Visible = false;
                _player.CurrentLocation = newLocation;
                rtbLocations.Text = newLocation.Name + Environment.NewLine; 
                rtbLocations.Text += newLocation.Description + Environment.NewLine;
                rtbMessages.Text += "" + Environment.NewLine;


                if (newLocation.ChestAvailableHere != null)
                {
                   
                    if (_player.OpemChestYet)
                    {
                    
                    btnChest.Visible = true;
                    rtbMessages.Text += "You find a chest." + Environment.NewLine;
                    }
                    else
                    btnChest.Visible = false;
                }


                if (newLocation.QuestAvailableHere != null)
                {
                        if(_player.PlayerAlreadyHasQuest(newLocation.QuestAvailableHere))
                        {
                            foreach (PlayerQuest pq in _player.Quest)
                                {

                                }
                            if (_player.PlayerHasItemQuest(newLocation.QuestAvailableHere))
                            {
                                rtbMessages.Text += newLocation.QuestAvailableHere.EndDescription + Environment.NewLine;
                                rtbMessages.Text += "You complete "+newLocation.QuestAvailableHere.Name+" quest." + Environment.NewLine;
                                rtbMessages.Text += "You " + Environment.NewLine;
                                rtbMessages.Text += "" + Environment.NewLine;
                                rtbMessages.Text += "" + Environment.NewLine;
                                rtbMessages.Text += "" + Environment.NewLine;










                                foreach (InventoryItem ii in _player.Inventory)
                                {
                                    foreach (QuestCompletationItem qq in newLocation.QuestAvailableHere.QuestCompletationItems)
                                    {
                                        if (ii.Details==qq.Details)
                                        {
                                            ii.Quantity -= qq.Quantity;   
                                        }
                                    }
                                    
                                }
                            }
                            
                        }
                        else
                        {
                            rtbMessages.Text += "You have a new quest " + newLocation.QuestAvailableHere.Name +","+newLocation.QuestAvailableHere.Description + Environment.NewLine;
                            _player.Quest.Add(new PlayerQuest(World.QuestByID(newLocation.QuestAvailableHere.ID), false));
                            
                        }
                }








                if (newLocation.MonsterLivingHere != null)
                {
                    rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;
                    Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);
                    
                    _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.RewardExperiencePoints, 
                        standardMonster.RewardGold, standardMonster.MaximumHitPoints, standardMonster.CurrentHitPoints, standardMonster.MaximumDamage);
                    
                }
                UpDateInvetoryUI();
                UpDatePlayerQuest();


            }
        private void UpDatePlayerQuest()
        {
            
            dgvQuest.ColumnCount = 2;
            dgvQuest.Columns[0].Name = "Quest";
            dgvQuest.Columns[1].Name = "Is Completed?";
            dgvQuest.Rows.Clear();
            foreach (PlayerQuest pq in _player.Quest)
            {
                dgvQuest.Rows.Add(new[] { pq.Details.Name, pq.IsCompleted.ToString() });
            }
        }
        private void UpDateInvetoryUI()
        {
            dgvInventory.Rows.Clear();
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 230;
            dgvInventory.Columns[1].Name = "Quantity";

            foreach (InventoryItem ii in _player.Inventory)
            {
                dgvInventory.Rows.Add(new[] { ii.Details.Name, ii.Quantity.ToString() });
            }
        }


        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }
        private void btnAttack_Click(object sender, EventArgs e)
        {
            int currentPlayerDamage;
            int currentMonsterDamage;

            lblMonsterHitPoints.Visible = true;
            lblMonsterName.Visible = true;
            currentPlayerDamage = RandomNumberGenerator.NumberBetween(0, _player.Damage);
            _currentMonster.CurrentHitPoints -= currentPlayerDamage;  
            currentMonsterDamage = RandomNumberGenerator.NumberBetween(0,_currentMonster.MaximumDamage);
            _player.CurrentHitPoints -= currentMonsterDamage;
            rtbMessages.Text += "You deal " + currentPlayerDamage + Environment.NewLine;
            lblMonsterHitPoints.Text = _currentMonster.CurrentHitPoints.ToString();
            lblMonsterName.Text = _currentMonster.Name.ToString();
            
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                rtbMessages.Text += "You kill the" + _currentMonster.Name + Environment.NewLine;
                lblMonsterName.Visible = false;
                lblMonsterHitPoints.Visible = false;
            }

        }








        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       

       
       

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChest_Click(object sender, EventArgs e)
        {
            _player.OpemChestYet = false;
            btnChest.Visible = false;
            _player.Inventory.Add(new InventoryItem(_player.CurrentLocation.ChestAvailableHere, 1));
            UpDateInvetoryUI();
            rtbMessages.Text += "You get " + _player.CurrentLocation.ChestAvailableHere.Name + Environment.NewLine;

        }
    }
}
