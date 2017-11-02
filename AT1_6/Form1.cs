using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Name: Renee Alsop
//ID: P303319
//Date:27/10/2017
//Current version: 2.0          (ver1.0 was Space Time Calc)
// 3rd Party libraries contain some error handling, returning error codes in the form of 10 decimal place values as retrun double is limited to 9 decimal places to fit in textbox
namespace AT1_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Create array of strings for zero divide errors
        //array strings will called by randomly generated index to vary response to create
        //more interesting and humerous user experience
        string[] DivZero = new string[]
            {
             "Black holes are where God attempted to divide by Zero, don't you try it!",
             "Imagine that you have zero cookies and you split them evenly among zero friends. How many cookies does each person get? See? It doesn’t make sense. And Cookie Monster is sad that there are no cookies, and you are sad that you have no friends.",
             "I see you are attempting to divide by zero, I can not permit you do do this.",
             "Paradox! Can not divide by 0!",
             "Well, It was all fun and games until you decided to divide zero!"
            };
        //numerical onclick to enter numbers in display
        private void bt0_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt0.Text;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt1.Text;
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt2.Text;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt3.Text;
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt4.Text;
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt5.Text;
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt6.Text;
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt7.Text;
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt8.Text;
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + bt9.Text;
        }
        //clear screen
        private void btClear_Click(object sender, EventArgs e)
        {
            Click2();
            txtDisp.Clear();
        }

        private void btDecPt_Click(object sender, EventArgs e)
        {
            Click1();
            txtDisp.Text = txtDisp.Text + btDecPt.Text;
        }
        //set primary bool and integers
        double totalA = 0;
        double totalB = 0;
        double rtnDbl = 0;
        bool plusClicked = false;
        bool minusClicked = false;
        bool divClicked = false;
        bool multiClicked = false;
        bool PwrRTClicked = false;
        bool pwrClicked = false;
        bool IsNeg = false;
        //arithmetic and algebra libraries 
        private void btAdd_Click(object sender, EventArgs e)
        {
            //passing textbox text to totalA and setting bool for add

            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                totalA = double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { totalA = Math.Abs(totalA) * (-1); }   //using isNeg bool to determine if input should be negative for totalA
                txtDisp.Clear();
                plusClicked = true;
                minusClicked = false;
                divClicked = false;
                multiClicked = false;
                PwrRTClicked = false;
                pwrClicked = false;
                IsNeg = false;      //reset isNeg bool

            }
            else
            {
                txtDisp.Focus();    //if input was null, focus is put to txtbox for user input
            }


        }

        private void btSub_Click(object sender, EventArgs e)
        {
            //passing textbox text to totalA and setting bool for subtract
            //this method also allows for setting the bool for a negative number
            //if the input is null preceeding it
            Click2();   //sfx
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                totalA += double.Parse(txtDisp.Text);
                if (IsNeg == true) //check for isNeg bool
                { totalA = Math.Abs(totalA) * (-1); }
                txtDisp.Clear();

                plusClicked = false;
                minusClicked = true;
                divClicked = false;
                multiClicked = false;
                PwrRTClicked = false;
                pwrClicked = false;
                IsNeg = false;
            }
            else    //set isNeg bool to true in absence of precursor input
            {
                txtDisp.Focus();
                IsNeg = true;
            }
        }
        //division, passing txtbox text to totalA, set bool, check for neg nums
        private void btDiv_Click(object sender, EventArgs e)
        {
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                totalA += double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { totalA = Math.Abs(totalA) * (-1); }
                txtDisp.Clear();
                plusClicked = false;
                minusClicked = false;
                divClicked = true;
                multiClicked = false;
                PwrRTClicked = false;
                pwrClicked = false;
                IsNeg = false;
            }
            else
            {
                txtDisp.Focus();
            }
        }
        //Multiply, set bool for multiply, check for negative nums, set total from txtbox
        private void btMult_Click(object sender, EventArgs e)
        {
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                totalA += double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { totalA = Math.Abs(totalA) * (-1); }
                txtDisp.Clear();

                plusClicked = false;
                minusClicked = false;
                divClicked = false;
                multiClicked = true;
                PwrRTClicked = false;
                pwrClicked = false;
                IsNeg = false;
            }
            else
            {
                txtDisp.Focus();
            }
        }
        //Equals click, checking bools, executing method appropriate to bool, setting totalB to negative
        //number if inNeg is true, triggering appropriate method where required.
        private void btEquals_Click(object sender, EventArgs e)
        {
            Click2();
            if (plusClicked == true)
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))    //check string has input
                {
                    totalB = double.Parse(txtDisp.Text);
                    if (IsNeg == true)      //if IsNeg is true, make input negative
                    { totalB = Math.Abs(totalB) * (-1); }
                    txtDisp.Clear();
                    txtDisp.Text = Arithmetic.Arithmetic.Add(totalA, totalB).ToString(); //use 3rd party library function for add
                }

            }
            else if (minusClicked == true)
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))    //input check
                {
                    totalB = double.Parse(txtDisp.Text);    //parse input to doubleB
                    if (IsNeg == true)  //use bool to check if input should be neg
                    { totalB = Math.Abs(totalB) * (-1); }       //if IsNeg, set neg
                    txtDisp.Clear();
                    txtDisp.Text = Arithmetic.Arithmetic.Sub(totalA, totalB).ToString(); //use 3rd party subtraction
                }

                //see previous methods, process remains same for rest of = code block
            }
            else if (divClicked == true)    //divide totalA by TotalB using 3rd larty lib
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))
                {
                    totalB = double.Parse(txtDisp.Text);
                    if (IsNeg == true)
                    { totalB = Math.Abs(totalB) * (-1); }
                    txtDisp.Clear();
                    rtnDbl = Arithmetic.Arithmetic.div(totalA, totalB);
                    if (rtnDbl == 0.0000000002) //if libray returns code for zero division, divZero error handling triggered
                    {
                        UhOh();                 //warning for dividing zero
                        txtDisp.Clear();
                        txtDisp.Focus();
                    }
                    else
                    {
                        txtDisp.Text = rtnDbl.ToString();
                    }
                }
            }
            else if (multiClicked == true)  //multiply totalA by TotalB using 3rd larty lib
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))
                {
                    totalB = double.Parse(txtDisp.Text);
                    if (IsNeg == true)
                    { totalB = Math.Abs(totalB) * (-1); }
                    txtDisp.Clear();
                    txtDisp.Text = Arithmetic.Arithmetic.Multi(totalA, totalB).ToString();
                }
            }
            else if (PwrRTClicked == true)  //power root using 3rd party lib
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))
                {
                    totalB = double.Parse(txtDisp.Text);
                    txtDisp.Clear();
                    rtnDbl = Algebra.Algebra.PowerRT(totalA, totalB);
                    if (rtnDbl == 0.0000000002) //divZeo Error handling
                    {
                        UhOh();
                        txtDisp.Clear();
                        txtDisp.Focus();
                    }
                    else
                    {
                        txtDisp.Text = rtnDbl.ToString();
                    }
                }
            }
            else if (pwrClicked == true)    //power using 3rd party lib
            {
                if (!string.IsNullOrEmpty(txtDisp.Text))
                {
                    totalB = double.Parse(txtDisp.Text);
                    if (IsNeg == true)  //neg check
                    { totalB = Math.Abs(totalB) * (-1); }   //set to negative

                    if (totalB == 0 || totalA == 0) //if either total is 0, result is 0

                    {
                        txtDisp.Text = "0";
                    }
                    else
                    {
                        txtDisp.Text = Algebra.Algebra.Power(totalA, totalB).ToString();//power from lib
                    }
                }


            }
            totalA = 0;     //reset total
            clearBool();    //reset booleans
        }
        //Algebra libraries
        private void btSQRT_Click(object sender, EventArgs e)
        {    //using 3rd party lib for SQRT, which divides number by itself, lib returns error code where applicable
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {

                if (IsNeg == true)  //can not sqrt negative number, error handling
                {
                    Stream str = Properties.Resources.SadTrombone;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play();
                    MessageBox.Show("The action you have requested is not possible in Mathematics", "Impossible");
                    txtDisp.Clear();
                    txtDisp.Focus();
                }
                else if ((double.Parse(txtDisp.Text) >= 0) && IsNeg == false)   //control variable
                {
                    double num = double.Parse(txtDisp.Text);
                    if (num == 0) { //divZero check
                        rtnDbl = Algebra.Algebra.Sqrt(num);
                        if (rtnDbl == 0.0000000002)
                        {
                            UhOh();
                            txtDisp.Clear();
                            txtDisp.Focus();
                        }
                        else   //if variable meets safe requirement, output
                        {
                            txtDisp.Text = rtnDbl.ToString();
                        }
                    }
                }
            }
            else
            {
                txtDisp.Focus();
            }
            clearBool();    //clear bool
        }

        private void btCubeRT_Click(object sender, EventArgs e)
        {  //using 3rd party lib for cubic root, lib returns error code where applicable
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                if (IsNeg == true)  //controlling variable
                {
                    Stream str = Properties.Resources.SadTrombone;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play(); //sfx alert
                    MessageBox.Show("The action you have requested is not possible in Mathematics", "Impossible");  //cannot find root of negative number, variable controlled
                    txtDisp.Clear();
                    txtDisp.Focus();
                }
                else if ((double.Parse(txtDisp.Text) >= 0) && IsNeg == false)
                {

                    double num = double.Parse(txtDisp.Text);
                    rtnDbl = Algebra.Algebra.PowerRT(num, 3);       //3rd party lib called
                    if (rtnDbl == 0.0000000002)
                    {       //divZero check
                        UhOh();
                        txtDisp.Clear();
                        txtDisp.Focus();
                    }
                    else
                    {
                        txtDisp.Text = rtnDbl.ToString();
                    }
                }
            }
            else
            {
                txtDisp.Focus();
            }
            clearBool();
        }


        private void btPwrRT_Click(object sender, EventArgs e)
        {  //using 3rd party lib for power root, lib returns error code where applicable
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {   //see previos methods, variables controlled, appropriate errors executed or appropriate library used
                if (IsNeg == true)
                {
                    Stream str = Properties.Resources.SadTrombone;
                    System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                    snd.Play(); //sfx alert
                    MessageBox.Show("The action you have requested is not possible in Mathematics", "Impossible");  //cannot find root of negative number, variable controlled
                    txtDisp.Clear();
                    txtDisp.Focus();
                    clearBool();
                }
                totalA += double.Parse(txtDisp.Text);
                txtDisp.Clear();
                plusClicked = false;
                minusClicked = false;
                divClicked = false;
                multiClicked = false;
                PwrRTClicked = true;
            }
            else
            {
                txtDisp.Focus();
            }
        }

        private void btPower_Click(object sender, EventArgs e)
        {    //see previos methods, variables controlled, appropriate errors executed or appropriate library used

            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                totalA += double.Parse(txtDisp.Text);
                if (IsNeg == true)  //neg check
                { totalB = Math.Abs(totalB) * (-1); }   //set to negative
                txtDisp.Clear();
                plusClicked = false;
                minusClicked = false;
                divClicked = false;
                multiClicked = false;
                PwrRTClicked = false;
                pwrClicked = true;

            }
            else
            {
                txtDisp.Focus();
            }
        }

        private void btSqr_Click(object sender, EventArgs e)
        { //see previos methods, variables controlled, appropriate errors executed or appropriate library used

            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                double num = double.Parse(txtDisp.Text);
                if (num > 0)
                {
                    txtDisp.Text = Algebra.Algebra.Power(num, 2).ToString();

                }
                else if (num == 0)
                {
                    txtDisp.Text = "0";
                }
                else
                {
                    txtDisp.Focus();
                }
            }
            else
            {
                txtDisp.Focus();
            }
            clearBool();
        }

        private void btInv_Click(object sender, EventArgs e)
        {    //see previos methods, variables controlled, appropriate errors executed or appropriate library used

            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                double num = double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { num = Math.Abs(num) * (-1); }
                rtnDbl = Algebra.Algebra.Inverse(num);
                if (rtnDbl == 0.0000000002)
                {
                    UhOh();
                    txtDisp.Clear();
                    txtDisp.Focus();
                }

                txtDisp.Text = rtnDbl.ToString();
            }
            else
            {
                txtDisp.Focus();
            }
            clearBool();
        }
        //Trig libraries
        private void btTan_Click(object sender, EventArgs e)
        {//Tangent of number, variables controlled, appropriate errors executed or appropriate library used
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {   //null checks
                double num = double.Parse(txtDisp.Text);    //pass text
                if (IsNeg == true)      //check neg
                { num = Math.Abs(num) * (-1); }
                rtnDbl = Trig.Trig.Tan(num);    //execute lib
                if (rtnDbl == 0.0000000002)        //check error code
                {
                    UhOh();     //handle error
                    txtDisp.Focus();
                }
                else if (rtnDbl == 0.0000000001)    //undefined error code
                {
                    MessageBox.Show("Undefined", "Invalid");    //handle error
                    txtDisp.Clear();
                    txtDisp.Focus();
                }
                else
                {
                    txtDisp.Text = rtnDbl.ToString();
                }
            }
            else
            {
                txtDisp.Focus();
            }

            clearBool();
        }

        private void btSin_Click(object sender, EventArgs e)
        {       //method as abouve but for sin in trig lib, error handled appropriate to error code returned
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                double num = double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { num = Math.Abs(num) * (-1); }

                txtDisp.Text = Trig.Trig.Sin(num).ToString();

            }
            else if (rtnDbl == 0.0000000001)
            {
                MessageBox.Show("Undefined", "Invalid");
                txtDisp.Clear();
                txtDisp.Focus();
            }
            else
            {
                txtDisp.Clear();
                txtDisp.Focus();
            }
        
    
            clearBool();
        }

        private void btCos_Click(object sender, EventArgs e)
        {   //cos in trig, error handled, variable controlled
            Click2();
            if (!string.IsNullOrEmpty(txtDisp.Text))
            {
                double num = double.Parse(txtDisp.Text);
                if (IsNeg == true)
                { num = Math.Abs(num) * (-1); }      
                    rtnDbl = Trig.Trig.Cos(num);
                 if (rtnDbl == 0.0000000001)
                {
                    MessageBox.Show("Undefined", "Invalid");
                    txtDisp.Clear();
                    txtDisp.Focus();
                }
                else
                {
                    txtDisp.Text = rtnDbl.ToString();
                }
                
            }
            else
            {
                txtDisp.Focus();
            }
            clearBool();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {       //exit menu with sfx and entertaining messages
            Click1();
            Stream str = Properties.Resources.yeahScience;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            DialogResult dialogResult = MessageBox.Show("Did you enjoy the Break Bad Code inspired Calculator?", "One Last Thing...", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Brilliant!");      //glad you liked it
            }
            else if (dialogResult == DialogResult.No)
            {
                Stream st = Properties.Resources.SadTrombone;
                System.Media.SoundPlayer sd = new System.Media.SoundPlayer(st);
                sd.Play();
                MessageBox.Show("Dishonor on you!, Dishonor on your cow!"); //didn't like my calc? stfu
            }

            {
                
                Application.Exit();     //close eeeet
            }
        }

        public void UhOh () 
        {   //UhOh error for dividing zero, selects random error message string from array by index
            //plays sad trombone sfx
            Random rn = new Random();
            int i = rn.Next(0, 5);
            Stream str = Properties.Resources.SadTrombone;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            MessageBox.Show(DivZero[i], "UH-OH!");
        }
       public void Click1()     //sfx for numerical button clicks
       {       
            Stream str = Properties.Resources.click1;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
        public void Click2()    //sfx for function button clicks
        {
            Stream str = Properties.Resources.click2;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
        public void clearBool()
        {   //sets all booleans to false
            plusClicked = false;
            minusClicked = false;
            divClicked = false;
            multiClicked = false;
            PwrRTClicked = false;
            pwrClicked = false;
            IsNeg = false;
        }
        
    }
}
