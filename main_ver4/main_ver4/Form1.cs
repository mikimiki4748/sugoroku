using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main_ver4
{
    public partial class Form1 : Form
    {
        int Dice1;
        int Dice2;
        int Twodice;
        int DiceALL;
        int Player1 = 0;
        int Player2 = 0;
        int Player3 = 0;
        int Player4 = 0;
        int turn;
        string Dices;
        bool DiceB = true;
        bool Player1B = true;
        bool Player2B = false;
        bool Player3B = false;
        bool Player4B = false;
        int SPALL;
        int Player1SP = 20;
        int Player2SP = 20;
        int Player3SP = 20;
        int Player4SP = 20;
        string SPs;
        int Event;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = Player1 + "マス目" + "スタミナ" + Player1SP;
            label4.Text = Player2 + "マス目" + "スタミナ" + Player2SP;
            label10.Text = Player3 + "マス目" + "スタミナ" + Player3SP;
            label13.Text = Player4 + "マス目" + "スタミナ" + Player4SP;
            label7.Text = "あなたの番です";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
            button6.Enabled = false;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            label9.Text = textBox1.Text;
            button7.Enabled = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            label12.Text = textBox1.Text;
            button8.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button9.Enabled = false;
            if (Player1B)
            {
                DiceALL = Player1;
                SPALL = Player1SP;
            }
            else if (Player2B)
            {
                DiceALL = Player2;
                SPALL = Player2SP;
            }
            else if (Player3B)
            {
                DiceALL = Player3;
                SPALL = Player3SP;
            }
            else if (Player4B)
            {
                DiceALL = Player4;
                SPALL = Player4SP;
            }
            Button button = (Button)sender;
            button.Name = button.ToString();
            if (button == button1)
            {
                if (SPALL < 1)
                {
                    label5.Text = "走れません";
                    DiceB = false;
                }
                else
                {
                    SPALL--;
                    Dice1 = r.Next(1, 7);
                    Dices = Dice1.ToString();
                    DiceALL += Dice1;
                    label5.Text = Dices + "が出ました";
                    DiceB = true;
                }
            }
            else if (button == button2)
            {
                if (SPALL < 3)
                {
                    label5.Text = "走れません";
                    DiceB = false;
                }
                else
                {
                    SPALL -= 3;

                    Dice1 = r.Next(1, 7);
                    Dice2 = r.Next(1, 7);
                    Twodice = Dice1 + Dice2;
                    DiceALL += Twodice;
                    Dices = Twodice.ToString();
                    label5.Text = Dices + "が出ました";
                    DiceB = true;
                }

            }
            else if (button == button3)
            {
                SPs = SPALL.ToString();
                Dice1 = r.Next(1, 3);
                DiceALL += Dice1;
                Dices = Dice1.ToString();
                label5.Text = Dices + "が出ました";
                DiceB = true;
            }
            if (DiceB)
            {
                Event = r.Next(0, 8);
                switch (Event)
                {
                    case 0:
                        label6.Text = "スタミナ１回復";
                        SPALL++;
                        break;

                    case 1:
                        label6.Text = "スタミナ２回復";
                        SPALL += 2;
                        break;

                    case 2:
                        if (SPALL < 1)
                        {
                            break;
                        }
                        else
                        {
                            label6.Text = "スタミナ１減少";
                            SPALL--;
                            break;
                        }

                    case 3:
                        if (SPALL < 2)
                        {
                            break;
                        }
                        else
                        {
                            label6.Text = "スタミナ2減少";
                            SPALL -= 2;
                            break;
                        }
                    case 4:
                        label6.Text = "1進む";
                        DiceALL++;
                        break;

                    case 5:
                        label6.Text = "２進む";
                        DiceALL += 2;
                        break;

                    case 6:
                        label6.Text = "１戻る";
                        DiceALL--;
                        break;

                    case 7:
                        if (DiceALL == 1)
                        {
                            break;
                        }
                        else
                        {
                            label6.Text = "2戻る";
                            DiceALL -= 2;
                            break;
                        }
                    case 8:
                        break;
                }
                if (Player1B)
                {
                    Player1 = DiceALL;
                    Player1SP = SPALL;
                    Player1B = false;
                    Player2B = true;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "あなたの番です";
                    label11.Text = "";
                    label14.Text = "";

                }
                else if (Player2B)
                {
                    Player2 = DiceALL;
                    Player2SP = SPALL;
                    Player1B = false;
                    Player2B = false;
                    Player3B = true;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "あなたの番です";
                    label14.Text = "";
                }
                else if (Player3B)
                {
                    Player3 = DiceALL;
                    Player3SP = SPALL;
                    Player1B = false;
                    Player2B = false;
                    Player3B = false;
                    Player4B = true;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "あなたの番です";
                }
                else if (Player4B)
                {
                    Player4 = DiceALL;
                    Player4SP = SPALL;
                    Player1B = true;
                    Player2B = false;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "あなたの番です";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "";

                }
                label3.Text = Player1 + "マス目" + "スタミナ" + Player1SP;
                label4.Text = Player2 + "マス目" + "スタミナ" + Player2SP;
                label10.Text = Player3 + "マス目" + "スタミナ" + Player3SP;
                label13.Text = Player4 + "マス目" + "スタミナ" + Player4SP;
                if (Player1 >= 60)
                {
                    label3.Text = "GOAL!";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                if (Player2 >= 60)
                {
                    label4.Text = "GOAL!";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                if (Player3 >= 60)
                {
                    label10.Text = "GOAL!";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                if (Player4 >= 60)
                {
                    label13.Text = "GOAL!";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            Player1 = 0;
            Player1SP = 20;
            Player1B = true;
            Player2 = 0;
            Player2SP = 20;
            Player2B = false;
            Player3 = 0;
            Player3SP = 20;
            Player3B = false;
            Player4 = 0;
            Player4SP = 20;
            Player4B = false;
            label1.Text = "";
            label2.Text = "";
            label9.Text = "";
            label12.Text = "";
            label3.Text = Player1 + "マス目" + "スタミナ" + Player1SP;
            label4.Text = Player2 + "マス目" + "スタミナ" + Player2SP;
            label10.Text = Player1 + "マス目" + "スタミナ" + Player1SP;
            label13.Text = Player2 + "マス目" + "スタミナ" + Player2SP;
            label5.Text = "リセットされました";
            label6.Text = "";
            label7.Text = "あなたの番です";
            label8.Text = "";
            label11.Text = "";
            label14.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            turn = r.Next(0, 7);
            switch (turn)
            {
                case 0:
                    Player1B = true;
                    Player2B = false;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "あなたの番です";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "";
                    break;

                case 1:
                    Player1B = false;
                    Player2B = true;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "あなたの番です";
                    label11.Text = "";
                    label14.Text = "";
                    break;

                case 2:
                    Player1B = false;
                    Player2B = false;
                    Player3B = true;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "あなたの番です";
                    label14.Text = "";
                    break;

                case 3:
                    Player1B = false;
                    Player2B = false;
                    Player3B = false;
                    Player4B = true;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "あなたの番です";
                    break;

                case 4:
                    Player1B = true;
                    Player2B = false;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "あなたの番です";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "";
                    break;

                case 5:
                    Player1B = false;
                    Player2B = true;
                    Player3B = false;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "あなたの番です";
                    label11.Text = "";
                    label14.Text = "";
                    break;

                case 6:
                    Player1B = false;
                    Player2B = false;
                    Player3B = true;
                    Player4B = false;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "あなたの番です";
                    label14.Text = "";
                    break;

                case 7:
                    Player1B = false;
                    Player2B = false;
                    Player3B = false;
                    Player4B = true;
                    label7.Text = "";
                    label8.Text = "";
                    label11.Text = "";
                    label14.Text = "あなたの番です";
                    break;
            }
        }
    }
}
