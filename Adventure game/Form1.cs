using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Adventure_game
{
    public partial class form : Form
    {
        public form()
        {
            //Setup and loading the form
            InitializeComponent();
            yellowImage.Hide();
            yellowText.Hide();
            greenImage.Hide();
            greenText.Hide();
            blueImage.Hide();
            redText.Hide();
            redImage.Hide();
            blueText.Hide();
            //Changing initial text 
            outputLable.Text = "Press blue button (C) to start";
        }
        //Store scene value
        double scene = 0;
        //Store previous scene value
        double sceneStored = 0;
        //Creating a random generator
        new Random randGen = new Random();
        //Create sound players
        SoundPlayer Win = new SoundPlayer(Properties.Resources.smb_stage_clear);
        SoundPlayer Lose = new SoundPlayer(Properties.Resources.smb_gameover);



        private void inputEvent(object sender, KeyEventArgs e)
        {
            //store current scene before change
            sceneStored = scene;

            if (e.KeyCode == Keys.C)       //blue button press
            {
                //logic to determine which scene is next if blue is pressed
                if (scene == 0) { scene = 1; }
                else if (scene == 1) { scene = 2; }
                else if (scene == 2) { scene = 4; }
                else if (scene == 3) { scene = 6; }
                else if (scene == 4) { scene = 8; }
                //randomly choose between 3 options for next scene
                else if (scene == 5) { scene = randGen.Next(27, 30); }
                else if (scene == 6) { scene = 12; }
                else if (scene == 7) { scene = 7.5; /*are you sure*/}
                else if (scene == 7.5) { scene = 17; }
                else if (scene == 9) { scene = 16; }
                else if (scene == 17) { scene = 17.5; /*outside*/}
                else if (scene == 17.5) { scene = 53; }
                else if (scene == 19) { scene = 17.5; }
                else if (scene == 21) { scene = 25; }
                //randomly choose between 6 options for next scene
                else if (scene == 23) { scene = randGen.Next(32, 38); }
                else if (scene == 32) { scene = 42; }
                else if (scene == 34) { scene = 44; }
                else if (scene == 45) { scene = 48; }
                else if (scene == 47) { scene = 50; }
                else if (scene == 53) { scene = 54; }
                else if (scene == 54) { scene = 58; }
                else if (scene == 57) { scene = 61; }
                else if (scene == 61) { scene = 58; }
                //if game over or win and selected play again
                else if (scene == 97 || scene == 63) { scene = 98; }


            }
            else if (e.KeyCode == Keys.X)  //red button press
            {
                //logic to determine which scene is next if red is pressed
                if (scene == 1) { scene = 3; }
                else if (scene == 2) { scene = 5; }
                else if (scene == 3) { scene = 7; }
                else if (scene == 4) { scene = 9; }
                else if (scene == 5) { scene = 11; }
                else if (scene == 6) { scene = 13; }
                else if (scene == 7) { scene = 14; }
                else if (scene == 7.5) { scene = 7; }
                //randomly selects a scene between 18 and 22
                else if (scene == 9) { scene = randGen.Next(18, 23); }
                else if (scene == 17) { scene = 23; }
                else if (scene == 17.5) { scene = 47; }
                else if (scene == 19) { scene = 24; }
                else if (scene == 21) { scene = 26; }
                else if (scene == 23) { scene = 97; }
                else if (scene == 32) { scene = 43; }
                else if (scene == 34) { scene = 45; }
                else if (scene == 45) { scene = 49; }
                else if (scene == 47) { scene = 51; }
                else if (scene == 53) { scene = 55; }
                else if (scene == 54) { scene = 59; }
                else if (scene == 57) { scene = 62; }
                else if (scene == 61) { scene = 59; }
                //if gameover or win and not play again go to end scene
                else if (scene == 97 || scene == 63) { scene = 99; }
            }
            //determines if yellow pushed AND yellow is an option
            else if (e.KeyCode == Keys.V && yellowImage.Visible == true)  //yellow button press
            {
                //change scene when pushed
                if (scene == 4) { scene = 10; }
                else if (scene == 7) { scene = 15; }
                else if (scene == 53) { scene = 56; }
            }
            //determines if green pushed AND green is an option
            else if (e.KeyCode == Keys.Z && greenImage.Visible == true)  //green button press
            {
                //change scene when pushed
                if (scene == 53) { scene = 57; }
            }
            //check if scene has changed then change scene
            if (sceneStored != scene)
            {
                //clear text
                blueText.Text = "";
                redText.Text = "";
                yellowText.Text = "";
                greenText.Text = "";
                Refresh();
                //switch case for every diffrent scene (note to Mr T. only commented when something is diffrent or new after first scene)
                switch (scene)
                {
                    case 1: //start scene
                    start:
                        //change image to match scene
                        imageBox.Image = Properties.Resources._1;
                        //refresh image
                        imageBox.Refresh();
                        //change text to match scene
                        outputLable.Text = "You just finished a long day at school.";
                        //refresh text
                        outputLable.Refresh();
                        //wait so user can read dialog
                        Thread.Sleep(4000);
                        //change text to the question/option
                        outputLable.Text = "Are you tired?";
                        //show and hide the diffrent options
                        blueImage.Show();
                        redText.Show();
                        redImage.Show();
                        blueText.Show();
                        greenImage.Hide();
                        greenText.Hide();
                        yellowImage.Hide();
                        yellowText.Hide();
                        //change option text
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 2:
                        imageBox.Image = Properties.Resources._2;
                        imageBox.Refresh();
                        outputLable.Text = "You walk to your room and stop at the door.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you go inside?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 3:
                        //this is where goto food; leads
                        food:
                        imageBox.Image = Properties.Resources._3;
                        imageBox.Refresh();
                        outputLable.Text = "You head to the kitchen to get something to eat.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Where do you get your food from?";
                        blueText.Text = "The Fridge";
                        redText.Text = "The Cupboard";
                        break;
                    case 4://3 options
                        room:
                        imageBox.Image = Properties.Resources._4;
                        imageBox.Refresh();
                        yellowImage.Show();
                        yellowText.Show();
                        outputLable.Text = "You walk in and see a Lego brick sitting on your bed.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "What do you do with it?";
                        blueText.Text = "Examine it";
                        redText.Text = "Throw it outside";
                        yellowText.Text = "Put it away";
                        break;
                    case 5:
                        imageBox.Image = Properties.Resources._5;
                        imageBox.Refresh();
                        outputLable.Text = "You hear footsteps coming up the stairs, and a painful cry of someone stepping on Lego.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "What will you do?";
                        blueText.Text = "Kick them";
                        redText.Text = "Nothing";
                        break;
                    case 6:
                        imageBox.Image = Properties.Resources._6;
                        imageBox.Refresh();
                        outputLable.Text = "You open the fridge and find a black glowing object.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you eat it?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 7://3 options
                        imageBox.Image = Properties.Resources._7;
                        imageBox.Refresh();
                        //show the text and button for the third option
                        yellowImage.Show();
                        yellowText.Show();
                        outputLable.Text = "You open the cupboard and grab a bag of chips.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "What type of chips are they?";
                        blueText.Text = "Doritios";
                        redText.Text = "Lays";
                        //text for option 3 changes
                        yellowText.Text = "Pringles";
                        break;
                    case 7.5:
                        imageBox.Image = Properties.Resources._7_5;
                        imageBox.Refresh();
                        yellowImage.Hide();
                        yellowText.Hide();
                        outputLable.Text = "Are you sure you want them?";
                        outputLable.Refresh();
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 8:
                        imageBox.Image = Properties.Resources._8;
                        imageBox.Refresh();
                        yellowImage.Hide();
                        yellowText.Hide();
                        outputLable.Text = "You catch on fire starting at your eyes because you looked at it funny";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changing scene and case to gameover by using goto
                        scene = 97;
                        goto gameOver;
                    case 9:
                        imageBox.Image = Properties.Resources._9;
                        imageBox.Refresh();
                        yellowImage.Hide();
                        yellowText.Hide();
                        outputLable.Text = "As you throw it out the window it lights on fire";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "What will you do now?";
                        blueText.Text = "Sleep";
                        redText.Text = "Stay Awake";
                        break;
                    case 10:
                        imageBox.Image = Properties.Resources._10;
                        imageBox.Refresh();
                        yellowImage.Hide();
                        yellowText.Hide();
                        outputLable.Text = "You notice your room is starting to get really hot. There is a fire.";
                        outputLable.Refresh();
                        Thread.Sleep(3000);
                        scene = 97;
                        goto gameOver;
                    case 11:
                        imageBox.Image = Properties.Resources._11;
                        imageBox.Refresh();
                        outputLable.Text = "The person comes up the stairs and proceeds to stab you.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 12:
                        imageBox.Image = Properties.Resources._12;
                        imageBox.Refresh();
                        outputLable.Text = "It surprisingly tastes like chocolate. You remember you are lactose intolerant";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 13:
                        imageBox.Image = Properties.Resources._13;
                        imageBox.Refresh();
                        outputLable.Text = "You throw out the food and it explodes!";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 14:
                        imageBox.Image = Properties.Resources._14;
                        imageBox.Refresh();
                        outputLable.Text = "You accidentally eat a green one.The bag was half air anyways.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 15:
                        imageBox.Image = Properties.Resources._15;
                        imageBox.Refresh();
                        outputLable.Text = "That chip had a few too many chemicals on it.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 16:
                        imageBox.Image = Properties.Resources._16;
                        imageBox.Refresh();
                        outputLable.Text = "You go to sleep, and don't wake up... Ever";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 17:
                        imageBox.Image = Properties.Resources._17;
                        imageBox.Refresh();
                        outputLable.Text = "They taste pretty good.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "It looks nice outside. Do you go?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 17.5:
                        //this is where goto outside; leads
                    outside:
                        imageBox.Image = Properties.Resources._1;
                        imageBox.Refresh();
                        outputLable.Text = "You are outside.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Where do you go?";
                        blueText.Text = "The bank";
                        redText.Text = "The park";
                        break;
                    case 18:
                        imageBox.Image = Properties.Resources._18;
                        imageBox.Refresh();
                        outputLable.Text = "You stayed up all night and now you feel  hungry.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //change scene and case to 3 
                        scene = 3;
                        goto food;
                    case 19:
                        imageBox.Image = Properties.Resources._17;
                        imageBox.Refresh();
                        outputLable.Text = "You stayed up all night and it looks nice out.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you go outside?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 20:
                        imageBox.Image = Properties.Resources._11;
                        imageBox.Refresh();
                        outputLable.Text = "In the middle of the night you hear a noise  then feel warm liquid dripping out of your chest.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 21:
                        imageBox.Image = Properties.Resources._11;
                        imageBox.Refresh();
                        outputLable.Text = "You somehow fell asleep in the night and woke up in the middle of your front yard.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "You feel a strange urge to go to the bank. Do you?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 22:
                        imageBox.Image = Properties.Resources._18;
                        imageBox.Refresh();
                        outputLable.Text = "You stayed up all night playing video games.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 1 (starting case)
                        scene = 1;
                        goto start;
                    case 23:
                        imageBox.Image = Properties.Resources._23;
                        imageBox.Refresh();
                        outputLable.Text = "Your mom yells at you for being a potato.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Would you like to play a game?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 24:
                        imageBox.Image = Properties.Resources._24;
                        imageBox.Refresh();
                        outputLable.Text = "Your mom forces you outside against your will.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 17.5 (outside)
                        scene = 17.5;
                        goto outside;
                    case 25:
                        imageBox.Image = Properties.Resources._25;
                        imageBox.Refresh();
                        outputLable.Text = "You make your way to the bank...";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 53 (bank)
                        scene = 53;
                        goto bank;
                    case 26:
                        imageBox.Image = Properties.Resources._26;
                        imageBox.Refresh();
                        outputLable.Text = "You turn around to go back inside but get hit by a car in the process.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 27:
                        imageBox.Image = Properties.Resources._27;
                        imageBox.Refresh();
                        outputLable.Text = "The person falls down the stairs and dies, revealing a hidden blade.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 30
                        scene = 30;
                        goto next2;
                    case 28:
                        imageBox.Image = Properties.Resources._28;
                        imageBox.Refresh();
                        outputLable.Text = "You then realize the person you kicked is your mom. You are grounded for life.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 29:
                        imageBox.Image = Properties.Resources._29;
                        imageBox.Refresh();
                        outputLable.Text = "You kick the person down the stairs only to find out it was a mirror. You fall down the stairs.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 1;
                        goto start;
                    case 30:
                        next2:
                        imageBox.Image = Properties.Resources._2;
                        imageBox.Refresh();
                        outputLable.Text = "You go into your room.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 4 (bedroom)
                        scene = 4;
                        goto room;
                    case 32:
                        imageBox.Image = Properties.Resources._32;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play Kario Mart.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you buy a Moped or a Lamborghini?";
                        blueText.Text = "Moped";
                        redText.Text = "Lamborghini";
                        break;
                    case 33:
                        imageBox.Image = Properties.Resources._33;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play Super Brario Mothers.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 38 (question existance)
                        scene = 38;
                        goto existance;
                    case 34:
                        imageBox.Image = Properties.Resources._34;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play The Zegend of Lelda";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you steal the saster mword?";
                        blueText.Text = "No";
                        redText.Text = "Yes";
                        break;
                    case 35:
                        imageBox.Image = Properties.Resources._35;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play Tplasoon";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 39 (where ink explodes)
                        scene = 39;
                        goto explode;
                    case 36:
                        imageBox.Image = Properties.Resources._36;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play sii wports";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 40 (pass out)
                        scene = 40;
                        goto unfit;
                    case 37:
                        imageBox.Image = Properties.Resources._37;
                        imageBox.Refresh();
                        outputLable.Text = "You begin to play Lky Sanders";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 41 (khaos)
                        scene = 41;
                        goto khaos;
                    case 38:
                        existance:
                        imageBox.Image = Properties.Resources._38;
                        imageBox.Refresh();
                        outputLable.Text = "You then realize you have two mothers and question your existance.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 39:
                        explode:
                        imageBox.Image = Properties.Resources._39;
                        imageBox.Refresh();
                        outputLable.Text = "You cartridge explodes spewing ink across the room. It hits your mom. You are grounded for life.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 40:
                        unfit:
                        imageBox.Image = Properties.Resources._40;
                        imageBox.Refresh();
                        outputLable.Text = "You consider how unfit you are and pass out.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 41:
                        khaos:
                        imageBox.Image = Properties.Resources._41;
                        imageBox.Refresh();
                        outputLable.Text = "Shaok kills you.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 42:
                        imageBox.Image = Properties.Resources._42;
                        imageBox.Refresh();
                        outputLable.Text = "You bring the moped to your first race and realize it dosen't work.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 43:
                        imageBox.Image = Properties.Resources._43;
                        imageBox.Refresh();
                        outputLable.Text = "You dont have enough money for a lambo so you steal it.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 46 (lamboghini)
                        scene = 46;
                        goto lambo;
                    case 44:
                        imageBox.Image = Properties.Resources._44;
                        imageBox.Refresh();
                        outputLable.Text = "You do not steal the saster mword so a koboblin kills you.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 45:
                        imageBox.Image = Properties.Resources._45;
                        imageBox.Refresh();
                        outputLable.Text = "You steal the saster mword successfully";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "What do you kill with it?";
                        blueText.Text = "Kill koboblin";
                        redText.Text = "Kill chicken";
                        break;
                    case 46:
                        lambo:
                        imageBox.Image = Properties.Resources._43;
                        imageBox.Refresh();
                        outputLable.Text = "You somehow get away with it because there are no laws in the game world. You win the race!";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 63 (win)
                        scene = 63;
                        goto win;
                    case 47:
                        imageBox.Image = Properties.Resources._47;
                        imageBox.Refresh();
                        outputLable.Text = "You go to the park and see some trash on the ground.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you pick it up?";
                        blueText.Text = "Leave it";
                        redText.Text = "Pick it up";
                        break;
                    case 48:
                        imageBox.Image = Properties.Resources._48;
                        imageBox.Refresh();
                        outputLable.Text = "You got disarmed in the fight and got killed with no way to fight back.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 49:
                        imageBox.Image = Properties.Resources._49;
                        imageBox.Refresh();
                        outputLable.Text = "You killed the chicken and it didn't fight back! Free food!";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 52;
                        goto freefood;
                    case 50:
                        imageBox.Image = Properties.Resources._50;
                        imageBox.Refresh();
                        outputLable.Text = "You leave the trash on the ground and walk away, slipping on it and banging the back of your head on the trash";
                        outputLable.Refresh();
                        Thread.Sleep(3000);
                        scene = 97;
                        goto gameOver;
                    case 51:
                        imageBox.Image = Properties.Resources._51;
                        imageBox.Refresh();
                        outputLable.Text = "Someone shows up behind you claiming that the trash was their treasure. They throw you into the trashbin.";
                        outputLable.Refresh();
                        Thread.Sleep(3000);
                        scene = 97;
                        goto gameOver;
                    case 52:
                        //this is where goto freefood; leads
                        freefood:
                        imageBox.Image = Properties.Resources._7_5;
                        imageBox.Refresh();
                        outputLable.Text = "This is a rare achievement in the game, you are recognized worldwide and win infinite Doritos!.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 63;
                        goto win;
                    case 53://4 options
                        //this is where goto bank; leads
                    bank:
                        imageBox.Image = Properties.Resources._53;
                        imageBox.Refresh();
                        //shows yellow and green buttons/text for 4 options
                        yellowText.Show();
                        greenImage.Show();
                        yellowImage.Show();
                        greenText.Show();
                        outputLable.Text = "You arrive at the bank and decide to take some money out.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "How much do you take?";
                        blueText.Text = "$10";
                        redText.Text = "$100";
                        //options 3 and 4 text is set
                        yellowText.Text = "$1000";
                        greenText.Text = "$1000000";
                        break;
                    case 54:
                        imageBox.Image = Properties.Resources._54;
                        imageBox.Refresh();
                        //hide options 3 and 4 as they no longer exist
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "You take out 10$ and head to the convenience store.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you rob it?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 55:
                        imageBox.Image = Properties.Resources._55;
                        imageBox.Refresh();
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "You take out $100 from your moms account, and she grounds you forever.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 56:
                        imageBox.Image = Properties.Resources._56;
                        imageBox.Refresh();
                        //hide options 3 and 4 as they no longer exist
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "You do not have $1000 so you steal $1000 and are arrested.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 57:
                        imageBox.Image = Properties.Resources._57;
                        imageBox.Refresh();
                        //hide options 3 and 4 as they no longer exist
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "You don't have $1000000 so you steal it. You get away.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Where do you go next?";
                        blueText.Text = "Convenience store";
                        redText.Text = "Home";
                        break;
                    case 58:
                        imageBox.Image = Properties.Resources._7_5;
                        imageBox.Refresh();
                        outputLable.Text = "You steal the whole stock of Doritos.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //changes scene and case to 60 (doritos)
                        scene = 60;
                        goto doritos;
                    case 59:
                        imageBox.Image = Properties.Resources._59;
                        imageBox.Refresh();
                        outputLable.Text = "Despite your choice they think you look suspicious, so the workers beat you up. ";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 60:
                        doritos:
                        imageBox.Image = Properties.Resources._56;
                        imageBox.Refresh();
                        outputLable.Text = "You have achieved your dream of eating tons of Doritos, and have landed yourself a full time position in jail.";
                        outputLable.Refresh();
                        Thread.Sleep(3000);
                        scene = 63;
                        goto win;
                    case 61:
                        imageBox.Image = Properties.Resources._54;
                        imageBox.Refresh();
                        outputLable.Text = "You arrive at the convenience store craving Doritos.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Do you rob it?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 62:
                        imageBox.Image = Properties.Resources._11;
                        imageBox.Refresh();
                        outputLable.Text = "You walk home only to find that the person in your house is still there and they stab you.";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        scene = 97;
                        goto gameOver;
                    case 63://win
                        win:
                        imageBox.Image = Properties.Resources._63;
                        imageBox.Refresh();
                        //hide options 3 and 4 as they no longer exist
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "Congratulations you have successfully found a correct path through the adventure.";
                        //play win sound effect
                        Win.Play();
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Would you like to play again?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 97://game over
                        gameOver:
                        imageBox.Image = Properties.Resources._97;
                        imageBox.Refresh();
                        //hide options 3 and 4 as they no longer exist
                        yellowText.Hide();
                        greenImage.Hide();
                        yellowImage.Hide();
                        greenText.Hide();
                        outputLable.Text = "Game over";
                        //play game over sound effect
                        Lose.Play();
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        outputLable.Text = "Would you like to play again?";
                        blueText.Text = "Yes";
                        redText.Text = "No";
                        break;
                    case 98:
                        imageBox.Image = Properties.Resources._98;
                        imageBox.Refresh();
                        blueImage.Hide();
                        redImage.Hide();
                        outputLable.Text = "You dare test your edgyness once again?";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //change scene and case to 1 (start)
                        scene = 1;
                        goto start;
                    case 99:
                        imageBox.Image = Properties.Resources._99;
                        imageBox.Refresh();
                        outputLable.Text = "Bye Bye :)";
                        outputLable.Refresh();
                        Thread.Sleep(4000);
                        //end the program 
                        Application.Exit();
                        break;
                }
            }
        }
    }
}
