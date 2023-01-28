using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace login
{
    public partial class CalculateMaterialPrice : Form
    {
       
        private OleDbConnection connection = new OleDbConnection();
        Double r; String g;
        Double tonframe, tonpost,
               brokenBrickForHardcore,sandForHardcore,workerForHardcore,
               sandForSandFilling,workerWateringForSandFilling,workerCarryingForSandFilling,
               rebar16mmColumn,rebar6mmColumn,bindingWireforColumn,cementForColumn, sandForColumn, aggForColumn, woodForColumn,nailForColumn,plywoodForColumn,workerForColumn,
               cementForConcretFloor, sandForConcretFloor, aggForConcretFloor,workerForFloor,
               cementFor3inchesLean, sandFor3inchesLean, aggFor3inchesLean,workerFor3inchesLean,
               cementForTopping,sandForTopping,aggForTopping,workerForTopping,
               brickForWall4, cementForWall4, sandForWall4,workerForWall4,
               brickForWall9, cementForWall9, sandForWall9,workerForWall9,
               brickFor2SideWall, cementFor2SideWall, sandFor2SideRoom,workerFor2SideRoom,
               brickFor3SideWall, cementFor3SideWall, sandFor3SideRoom,workerFor3SideRoom,
               brickFor4SideWall, cementFor4SideWall, sandFor4SideRoom,workerFor4SideRoom,
               rebar16mmForBeam2Side, rebar6mmForBeam2Side, bindingWireforBeam2Side,cementForBeam2Side, sandForBeam2Side, aggForBeam2Side, woodForBeam2Side, nailFor2Side, plywoodFor2Side,workerFor2Side,
               rebar16mmForBeam3Side,rebar6mmForBeam3Side,bindingWireforBeam3Side, cementForBeam3Side, sandForBeam3Side, aggForBeam3Side, woodForBeam3Side, nailFor3Side, plywoodFor3Side,workerFor3Side,
               chocketWoodForWindow,chocketWoodForDoor,sftForChocket,sftForChocketDoor,
               leafForWindow,leafForDoor,sftWindowLeaf,sftDoorLeaf,
               priceForCeiling,sftForCeiling,
               earthWorker,
               priceForEmulsionPaint,priceForOilPaint,sftForEmulsionPaint,sftForOilPaint,
               rebarForFooting,bindingWireForFooting,
               cementForPlastering,sandForPlastering,workerForPlastering,
               woodForPurlin,woodForRafter,ZincNo,plainSheetForRoof,eaveboardWoodForRoof,workerForRoof,zincLength,pricePlainRidgingSheet,
               readyMadeGutter,gutterBracket,PVCPipe,pipeClick,
               brickStair,cementStair,sandStair;

        Double i=0, j=0, k=0, l = 0;

                                                                                                                                                  

        public CalculateMaterialPrice()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire  V5\Desktop\myTest\MaterialPrice.accdb;
                                           Persist Security Info=False;";
            InitializeComponent();
        }

        private void CalculateMaterialPrice_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;

            total.Visible = false;
            
            tabControl1.Hide();
            

            panel4.Hide();
            panel5.Hide();

            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
            panel22.Hide();
            panel21.Hide();


            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            groupBox7.Visible = false;
            groupBox8.Visible = false;
            groupBox10.Visible = false;
            groupBox11.Visible = false;
            groupBox12.Visible = false;
            groupBox19.Visible = false;
            groupBox20.Visible = false;

            if (myanmar.Checked == true)
            {

                tabPage1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
               tabPage1.Text = "ပတ္တန္း";

            }


        }
       
        

 //Column

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            if ((string.IsNullOrEmpty(txtcolumnlength.Text)) || (string.IsNullOrEmpty(txtcolumnwidth.Text)) || (string.IsNullOrEmpty(txtcolumnNo.Text)) || (string.IsNullOrEmpty(txtcolumnheight.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtcolumnlength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtcolumnwidth.Text, "^[a-zA-Z]")) 
                || (System.Text.RegularExpressions.Regex.IsMatch(txtcolumnheight.Text, "^[a-zA-Z]"))
                || (System.Text.RegularExpressions.Regex.IsMatch(txtcolumnNo.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {

                i = Double.Parse(txtcolumnlength.Text);
                j = Double.Parse(txtcolumnwidth.Text);
                k = Double.Parse(txtcolumnheight.Text);
                l = Double.Parse(txtcolumnNo.Text);
                Double m = Double.Parse(txtRebarColumnNo.Text);

                Double totalColumn = (i / 12) * (j / 12) * k;

                // for rebar column

                Double totalRebar = m * k;
                Double totalRebar2 = (totalRebar * 1.043) / 2240;
                rebar16mmColumn = totalRebar2 * l;

                textBox13.Text = rebar16mmColumn.ToString("#.###");

                // for rebar different

                Double n = 2 * k;
                Double totalRebar3 = (2 * (i - 2)) + (2 * (j - 2));
                Double totalRebar4 = ((((totalRebar3 + 4) / 12) * n) * 0.1669) / 2240;

                rebar6mmColumn = totalRebar4 * l;

                txtRebar6Column.Text = rebar6mmColumn.ToString("#.###");

                //for Binding Wire
                Double b = rebar16mmColumn + rebar6mmColumn;
                bindingWireforColumn = (b * 20) / 3.6;
                txtBindingWireColumn.Text = bindingWireforColumn.ToString("#.###");




                //for cement

                Double totalCement, resultCement;

                totalCement = (totalColumn * 2070) / 100;
                resultCement = totalCement / 112;

                cementForColumn = l * resultCement;

                textBox15.Text = cementForColumn.ToString("#.###");

                //for sand

                Double totalSand, resultSand;
                totalSand = (totalColumn * 46) / 100;
                resultSand = totalSand / 100;
                sandForColumn = resultSand * l;
                textBox16.Text = sandForColumn.ToString("#.###");

                //for Agg
                Double totalAgg;
                totalAgg = resultSand * 2;
                aggForColumn = totalAgg * l;
                textBox17.Text = aggForColumn.ToString("#.###");


                //for Wood
                Double totalWood, resultWood;
                totalWood = ((i + i + j + j) / 12) * k;
                resultWood = ((totalWood * 15) / 100) / 50;
                woodForColumn = resultWood * l;
                textBox9.Text = woodForColumn.ToString("#.###");

                //for Nail
                Double totalNail1, resultNail1;
                totalNail1 = ((i + i + j + j) / 12) * k;
                resultNail1 = ((totalNail1 * 3) / 100) / 3.6;
                nailForColumn = resultNail1 * l;
                txtNailFor4.Text = nailForColumn.ToString("#.###");

                //for 5PlyWood
                Double totalply1, resultply1;
                totalply1 = ((i + i + j + j) / 12) * k;
                resultply1 = (totalply1 * 3.4) / 100;
                plywoodForColumn = resultply1 * l;
                txtplyWoodFor4.Text = plywoodForColumn.ToString("#.###");

                //Workers
                workerForColumn = ((totalColumn * l) * 15) / 100;
                txtWorkerForColumn.Text = workerForColumn.ToString("#");


            }
        }
      
 //Floor 4" thick      

        private void button5_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrEmpty(textBox2.Text)) || (string.IsNullOrEmpty(textBox5.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]"))
                || (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {
                i = Double.Parse(textBox1.Text); // length
                j = Double.Parse(textBox2.Text); // width
                k = Double.Parse(textBox5.Text); // height

                Double total = (i * j) * (k / 12);
                cementForConcretFloor = ((total * 1440) / 100) / 112;



                textBox6.Text = cementForConcretFloor.ToString("#.###");

                sandForConcretFloor = ((total * 48) / 100) / 100;

                textBox7.Text = sandForConcretFloor.ToString("#.###");

                aggForConcretFloor = 2 * sandForConcretFloor;

                textBox8.Text = aggForConcretFloor.ToString("#.###");

                workerForFloor = (total * 8) / 100;

                txtWorkerFor4Floor.Text = workerForFloor.ToString("#");

            }
        }


// 3 " Lean Work floor 1:3:6 


        private void button15_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBox10.Text)) || (string.IsNullOrEmpty(textBox11.Text)) || (string.IsNullOrEmpty(textBox12.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(textBox10.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox11.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(textBox12.Text, "^[a-zA-Z]"))
                )
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {
                i = Double.Parse(textBox10.Text); // length
                j = Double.Parse(textBox11.Text); // width
                k = Double.Parse(textBox12.Text); //height

                Double total = (i * j) * (k / 12);
                cementFor3inchesLean = ((total * 1440) / 100) / 112;



                textBox14.Text = cementFor3inchesLean.ToString("#.###");
                sandFor3inchesLean = ((total * 48) / 100) / 100;

                textBox4.Text = sandFor3inchesLean.ToString("#.###");

                aggFor3inchesLean = 2 * sandFor3inchesLean;

                textBox3.Text = aggFor3inchesLean.ToString("#.###");

                workerFor3inchesLean = (total * 8) / 100;

                txtWorkerForLeanFloor.Text = workerFor3inchesLean.ToString("#");

            }
        }
//1 1/2 " thick Topping

        private void button18_Click(object sender, EventArgs e)
        {
            panel22.Visible = true;
            if ((string.IsNullOrEmpty(txtLengthForTopping.Text)) || (string.IsNullOrEmpty(txtWidthForTopping.Text)) )
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForTopping.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForTopping.Text, "^[a-zA-Z]")) )
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {
                i = Double.Parse(txtLengthForTopping.Text);
                j = Double.Parse(txtWidthForTopping.Text);

                cementForTopping = (((i * j) * 259) / 100) / 112;
                txtCementForTopping.Text = cementForTopping.ToString("#.###");

                sandForTopping = (((i * j) * 5.75) / 100) / 100;
                txtSandForTopping.Text = sandForTopping.ToString("#.###");

                aggForTopping = sandForTopping * 2;
                txtAggForTopping.Text = aggForTopping.ToString("#.###");

                workerForTopping = ((i * j) * 1.5) / 100;
                txtWorkerForTopping.Text = workerForTopping.ToString("#");
            }
        }
//Wall

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Show();
           
            

        }



        //4 1/2 " Thick Wall
        private void button6_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txt1.Text)) || (string.IsNullOrEmpty(txt2.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txt1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txt2.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {
                i = 4 * Double.Parse(txt1.Text) * Double.Parse(txt2.Text);
                brickForWall4 = (i * 550) / 100;

                cementForWall4 = ((i * 297) / 100) / 112;
                sandForWall4 = ((i * 10) / 100) / 100;
                workerForWall4 = (i * 3) / 100; //Page 40

                txt3.Text = brickForWall4.ToString("#.###");
                txt4.Text = cementForWall4.ToString("#.###");
                txt5.Text = sandForWall4.ToString("#.###");
                txtWorkerForWall4.Text = workerForWall4.ToString("#");


            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            panel5.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //9" Thick Wall
        private void button7_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthFor9.Text)) || (string.IsNullOrEmpty(txtWidthFor9.Text)) || (string.IsNullOrEmpty(txtHeightFor9.Text)) )
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthFor9.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthFor9.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtHeightFor9.Text, "^[a-zA-Z]"))
                )
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {
                i = 4 * Double.Parse(txtLengthFor9.Text) * (Double.Parse(txtWidthFor9.Text) / 12) * Double.Parse(txtHeightFor9.Text);

                brickForWall9 = (i * 1350) / 100;
                cementForWall9 = ((i * 780) / 100) / 112;
                sandForWall9 = ((i * 26) / 100) / 100;
                workerForWall9 = (i * 3.5) / 100;

                txtBrickFor9.Text = brickForWall9.ToString("#.###");
                txtCementFor9.Text = (Convert.ToInt16(cementForWall9)).ToString("#.###");
                txtSandFor9.Text = sandForWall9.ToString("#.###");
                txtWorkerForWall9.Text = workerForWall9.ToString("#");

            }
        }



        


//PegOut
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(t1.Text))|| (string.IsNullOrEmpty(t2.Text)))
            {
                MessageBox.Show("Please Enter Value");
                
            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(t1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(t2.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }

            else
            {

                i = Double.Parse(t1.Text);
                j = Double.Parse(t2.Text);

                Double totalpeg = 2 * (i + 6) + 2 * (j + 6);

                Double frame = 0.5 * 0.083 * totalpeg;
                Double dif = totalpeg / 5;
                Double post = dif * 0.25 * 0.167 * 3.5;

                tonframe = frame / 50;
                tonpost = post / 50;

                t3.Text = tonframe.ToString("#.###");
                t4.Text = tonpost.ToString("#.###");
            }
        }
//EarthWork

        private void button20_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthForEarthWork.Text)) || (string.IsNullOrEmpty(txtWidthForEarthWork.Text)) ||
                (string.IsNullOrEmpty(txtHeightForEarthWork.Text)))
            { MessageBox.Show("Please Enter Value"); }
            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForEarthWork.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForEarthWork.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtHeightForEarthWork.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtLengthForEarthWork.Text);//length
                l = Double.Parse(txtWidthForEarthWork.Text);//width
                j = Double.Parse(txtHeightForEarthWork.Text);//height

                earthWorker = ((i * l * j) * 2) / 100;

                txtWorkerForEarthWork.Text = earthWorker.ToString("#");
            }
        }
//Paint

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox19.Visible = true;
            groupBox20.Visible = false;
            if ((string.IsNullOrEmpty(txtLengthForPaint.Text)) || (string.IsNullOrEmpty(txtWidthForPaint.Text)) || (string.IsNullOrEmpty(txt1sftPerRateForPaint.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForPaint.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForPaint.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txt1sftPerRateForPaint.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtLengthForPaint.Text);//length
                l = Double.Parse(txtWidthForPaint.Text);//width
                k = Double.Parse(txt1sftPerRateForPaint.Text);



                
                priceForEmulsionPaint = (i * l) * k;
                txtPriceForEmulsion.Text = priceForEmulsionPaint.ToString("#.###");

                sftForEmulsionPaint = i * l;
                lblEmulsionPaint.Text = sftForEmulsionPaint.ToString("#.##");



            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox20.Visible = true;
            groupBox19.Visible = false;
            if ((string.IsNullOrEmpty(txtLengthForPaint.Text)) || (string.IsNullOrEmpty(txtWidthForPaint.Text)) || (string.IsNullOrEmpty(t2.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForPaint.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForPaint.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(t1.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtLengthForPaint.Text);//length
                l = Double.Parse(txtWidthForPaint.Text);//width
                k = Double.Parse(txt1sftPerRateForPaint.Text);

                priceForOilPaint = (i * l) * k;
                txtPriceForOilPaint.Text = priceForOilPaint.ToString("#.###");


                sftForOilPaint = i * l;
                lblOilPaint.Text = sftForOilPaint.ToString("#.##");

               
            }
        }

      


//HardCore SandFilling

        private void button16_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthForHardcore.Text)) || (string.IsNullOrEmpty(txtWidthForHardcore.Text)) || (string.IsNullOrEmpty(txtHeightForHardcore.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForHardcore.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForHardcore.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtHeightForHardcore.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtLengthForHardcore.Text);//length
                l = Double.Parse(txtWidthForHardcore.Text);//width
                j = Double.Parse(txtHeightForHardcore.Text);//height
                k = i * l * (j / 12);
                brokenBrickForHardcore = (k * 1.2) / 100;
                sandForHardcore = (k * 0.3) / 100;
                workerForHardcore = (k * 2) / 100;

                txtBrokenBrickForHardcore.Text = brokenBrickForHardcore.ToString("#.###");
                txtSandForHardcore.Text = sandForHardcore.ToString("#.###");
                txtWorkerForHardcore.Text = workerForHardcore.ToString("#.###");
            }
        }

//Sand Filling
        private void button17_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthForSandFilling.Text)) || (string.IsNullOrEmpty(txtWidthForSandFilling.Text)) || (string.IsNullOrEmpty(txtHeightForSandFilling.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForSandFilling.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForSandFilling.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtHeightForSandFilling.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {


                i = Double.Parse(txtLengthForSandFilling.Text);//length
                l = Double.Parse(txtWidthForSandFilling.Text);//width
                j = Double.Parse(txtHeightForSandFilling.Text);//height
                k = i * l * (j / 12);

                sandForSandFilling = ((k * 125) / 100) / 100;
                workerWateringForSandFilling = (k * 0.5) / 100;
                workerCarryingForSandFilling = (k * 0.5) / 100;

                txtSandForSandFilling.Text = sandForSandFilling.ToString("#.###");
                txtWorkerWateringForSandFilling.Text = workerWateringForSandFilling.ToString("#.###");
                txtWorkerCarryingForSandFilling.Text = workerCarryingForSandFilling.ToString("#.###");

            }

        }


//Room

        private void button8_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tt1.Text)) || (string.IsNullOrEmpty(tt2.Text)) || (string.IsNullOrEmpty(tt3.Text))|| (string.IsNullOrEmpty(tt4.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(tt1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(tt2.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(tt3.Text, "^[a-zA-Z]"))||(System.Text.RegularExpressions.Regex.IsMatch(tt4.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(tt1.Text);//length
                l = Double.Parse(tt2.Text);//width
                j = Double.Parse(tt3.Text);//height
                k = Double.Parse(tt4.Text);//no of room


                if (radioButton1.Checked == true)
                {

                    brickFor2SideWall = ((((i + l) * j) * 550) / 100) * k;
                    cementFor2SideWall = (((((i + l) * j) * 297) / 100) / 112) * k;
                    sandFor2SideRoom = (((10 * ((i + l) * j)) / 100) / 100) * k;
                    workerFor2SideRoom = (((i + l) * j) * 3) / 100;
                    textBox22.Text = brickFor2SideWall.ToString("#.###");
                    textBox23.Text = cementFor2SideWall.ToString("#.###");
                    textBox24.Text = sandFor2SideRoom.ToString("#.###");
                    textBox19.Text = workerFor2SideRoom.ToString("#");


                }

                else if (radioButton2.Checked == true)
                {

                    brickFor3SideWall = ((((i + i + l) * j) * 550) / 100) * k;
                    cementFor3SideWall = (((((i + i + l) * j) * 297) / 100) / 112) * k;
                    sandFor3SideRoom = (((10 * ((i + i + l) * j)) / 100) / 100) * k;
                    workerFor3SideRoom = (((i + i + l) * j) * 3) / 100;
                    textBox27.Text = brickFor3SideWall.ToString("#.###");
                    textBox26.Text = cementFor3SideWall.ToString("#.###");
                    textBox25.Text = sandFor3SideRoom.ToString("#.###");
                    textBox20.Text = workerFor3SideRoom.ToString("#");

                }

                else if (radioButton3.Checked == true)
                {

                    brickFor4SideWall = (((i + i + l + l) * j * 550) / 100) * k;
                    cementFor4SideWall = ((((i + i + l + l) * j * 297) / 100) / 112) * k;
                    sandFor4SideRoom = (((10 * (i + i + l + l) * j) / 100) / 100) * k;
                    workerFor4SideRoom = (((i + i + l + l) * j) * 3) / 100;
                    textBox30.Text = brickFor4SideWall.ToString("#.###");
                    textBox29.Text = cementFor4SideWall.ToString("#.###");
                    textBox28.Text = sandFor4SideRoom.ToString("#.###");
                    textBox21.Text = workerFor4SideRoom.ToString("#");

                }




            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel7.Show();
            panel8.Hide();
            panel9.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel8.Show();
            panel7.Hide();
            panel9.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel9.Show();
            panel7.Hide();
            panel8.Hide();
        }
//Beam

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            groupBox3.Visible = true;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
           
        }
        //BeamFor2Sides
        private void button10_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox6.Visible = false;
            groupBox5.Visible = true;
            if ((string.IsNullOrEmpty(txtBeamLength2.Text)) || (string.IsNullOrEmpty(txtBemWidth2.Text)) || (string.IsNullOrEmpty(txtNoBeam2.Text)) || (string.IsNullOrEmpty(txtBeamHeight2.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtBeamLength2.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtBemWidth2.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtBeamHeight2.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtNoBeam2.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {

                i = Double.Parse(txtBeamLength2.Text);
                j = Double.Parse(txtBemWidth2.Text);

                k = Double.Parse(txtBeamHeight2.Text);
                l = Double.Parse(txtNoBeam2.Text);
                Double m = Double.Parse(txt16mmRebar2Side.Text);

                Double totalColumn = (j / 12) * (k / 12) * i;

                // for rebar column

                Double totalRebar = m * i;
                Double totalRebar2 = (totalRebar * 1.043) / 2240;

                // for rebar different

                Double n = 2 * i;
                Double totalRebar3 = (2 * (k - 2)) + (2 * (j - 2));
                Double totalRebar4 = ((((totalRebar3 + 4) / 12) * n) * 0.1669) / 2240;




                rebar16mmForBeam2Side = totalRebar2 * l;
                rebar6mmForBeam2Side = totalRebar4 * l;

                rebarBeam2Side.Text = rebar16mmForBeam2Side.ToString("#.###");
                nn.Text = rebar6mmForBeam2Side.ToString("#.###");

                //for Binding Wire
                Double b = rebar16mmForBeam2Side + rebar6mmForBeam2Side;
                bindingWireforBeam2Side = (b * 20) / 3.6;
                txtBeam2SideBD.Text = bindingWireforBeam2Side.ToString("#.###");

                //for cement

                Double totalCement, resultCement;

                totalCement = (totalColumn * 2070) / 100;
                resultCement = totalCement / 112;

                cementForBeam2Side = l * resultCement;

                cementBeam2Side.Text = cementForBeam2Side.ToString("#.###");

                //for sand

                Double totalSand, resultSand;
                totalSand = (totalColumn * 46) / 100;
                resultSand = totalSand / 100;
                sandForBeam2Side = resultSand * l;
                sandBeam2Side.Text = sandForBeam2Side.ToString("#.###");

                //for Agg
                Double totalAgg;
                totalAgg = resultSand * 2;
                aggForBeam2Side = totalAgg * l;
                aggBeam2Side.Text = aggForBeam2Side.ToString("#.###");


                //for Wood
                Double totalWood, resultWood;
                totalWood = ((k + k) / 12) * i;
                resultWood = ((totalWood * 15) / 100) / 50;
                woodForBeam2Side = resultWood * l;
                woodBeam2Side.Text = woodForBeam2Side.ToString("#.###");

                //for Nail
                Double totalNail2;
                totalNail2 = ((k + k) / 12) * i;
                nailFor2Side = ((totalNail2 * 3) / 100) / 3.6;
                txtNailFor2Side.Text = nailFor2Side.ToString("#.###");

                //for 5PlyWood
                Double totalply2, resultply2;
                totalply2 = ((k + k) / 12) * i;
                resultply2 = (totalply2 * 3.4) / 100;
                plywoodFor2Side = resultply2 * l;
                txtplywoodFor2Side.Text = plywoodFor2Side.ToString("#.###");


                //Workers
                workerFor2Side = ((totalColumn * l) * 15) / 100;
                txtWorkerForBeam2Side.Text = workerFor2Side.ToString("#");
            }
        }

        // Beam 3 Side

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = true;
            groupBox6.Visible = true;

            if ((string.IsNullOrEmpty(txtBeamLength.Text)) || (string.IsNullOrEmpty(txtBeamWidth.Text)) || (string.IsNullOrEmpty(txtBeamHeight.Text)) || (string.IsNullOrEmpty(txtNoBeam.Text)) || (string.IsNullOrEmpty(txt3SideRebarBeam.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtBeamLength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtBeamWidth.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtBeamHeight.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtNoBeam.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txt3SideRebarBeam.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {



                i = Double.Parse(txtBeamLength.Text);
                j = Double.Parse(txtBeamWidth.Text);

                k = Double.Parse(txtBeamHeight.Text);
                l = Double.Parse(txtNoBeam.Text);
                Double m = Double.Parse(txt3SideRebarBeam.Text);
                Double totalColumn = (j / 12) * (k / 12) * i;

                // for rebar column

                Double totalRebar = m * i;
                Double totalRebar2 = (totalRebar * 1.043) / 2240;

                // for rebar different
                Double n = 2 * i;
                Double totalRebar3 = (2 * (k - 2)) + (2 * (j - 2));
                Double totalRebar4 = ((((totalRebar3 + 4) / 12) * n) * 0.1669) / 2240;




                rebar16mmForBeam3Side = totalRebar2 * l;
                rebar6mmForBeam3Side = totalRebar4 * l;

                rebarBeam3Sides.Text = rebar16mmForBeam3Side.ToString("#.###");
                txtBeam3Side6mm.Text = rebar6mmForBeam3Side.ToString("#.###");

                //for Binding Wire
                Double b = rebar16mmForBeam3Side + rebar6mmForBeam3Side;
                bindingWireforBeam3Side = (b * 20) / 3.6;
                txtBeam3SideBD.Text = bindingWireforBeam3Side.ToString("#.###");

                //for cement

                Double totalCement, resultCement;

                totalCement = (totalColumn * 2070) / 100;
                resultCement = totalCement / 112;

                cementForBeam3Side = l * resultCement;

                cementBeam3Sides.Text = cementForBeam3Side.ToString("#.###");

                //for sand

                Double totalSand, resultSand;
                totalSand = (totalColumn * 46) / 100;
                resultSand = totalSand / 100;
                sandForBeam3Side = resultSand * l;
                sandBeam3Sides.Text = sandForBeam3Side.ToString("#.###");

                //for Agg
                Double totalAgg;
                totalAgg = resultSand * 2;
                aggForBeam3Side = totalAgg * l;
                aggBeam3Sides.Text = aggForBeam3Side.ToString("#.###");



                //for Wood
                Double totalWood, resultWood;
                totalWood = (((2 * k) + j) / 12) * i;
                resultWood = ((totalWood * 15) / 100) / 50;
                woodForBeam3Side = resultWood * l;
                woodBeam3Sides.Text = woodForBeam3Side.ToString("#.###");

                //for Nail
                Double totalNail3, resultNail3;
                totalNail3 = (((2 * k) + j) / 12) * i;
                resultNail3 = ((totalNail3 * 3) / 100) / 3.6;
                nailFor3Side = resultNail3 * l;
                txtNailFor3Side.Text = resultNail3.ToString("#.###");

                //for 5PlyWood
                Double totalply3, resultply3;
                totalply3 = (((2 * k) + j) / 12) * i;
                resultply3 = (totalply3 * 3.4) / 100;
                plywoodFor3Side = resultply3 * l;
                txtplyWoodFor3Side.Text = resultply3.ToString("#.###");

                //Workers
                workerFor3Side = ((totalColumn * l) * 15) / 100;
                txtWorkerForBeam3Sides.Text = workerFor3Side.ToString("#");
            }
        }
//Ceiling 
        private void button19_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthForCeiling.Text)) || (string.IsNullOrEmpty(txtWidthForCeiling.Text)) || (string.IsNullOrEmpty(txt1sftForCeiling.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthForCeiling.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthForCeiling.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txt1sftForCeiling.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtLengthForCeiling.Text);
                j = Double.Parse(txtWidthForCeiling.Text);
                k = Double.Parse(txt1sftForCeiling.Text);


                priceForCeiling = ((i * j) * k);
                txtPriceForCeiling.Text = priceForCeiling.ToString("#.###");

                sftForCeiling = (i * j);
                lblCeiling.Text = sftForCeiling.ToString("#.##");

            }


        }


//Chocket
       

        //Chocket For window
        private void button11_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(ttt1.Text)) || (string.IsNullOrEmpty(ttt2.Text)) || (string.IsNullOrEmpty(txtNoOfWoodLength.Text)) || (string.IsNullOrEmpty(ttt3.Text)) || (string.IsNullOrEmpty(txtWoodHeight.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(ttt1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(ttt2.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(ttt3.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWoodHeight.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfWoodLength.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                groupBox7.Visible = true;
                groupBox8.Visible = false;
                i = Double.Parse(ttt1.Text); // length
                j = Double.Parse(ttt2.Text); // height
                k = Double.Parse(ttt3.Text); // Number
                l = Double.Parse(txtNoOfWoodLength.Text);
                Double m = Double.Parse(txtWoodHeight.Text);

                Double total = (i * l) + (j * m); //rft
                chocketWoodForWindow = total * k;

                sftForChocket = chocketWoodForWindow * (0.417 + 0.167);

                txtChocketWoodWindow.Text = chocketWoodForWindow.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(ttt1.Text)) || (string.IsNullOrEmpty(ttt2.Text)) || (string.IsNullOrEmpty(ttt3.Text))
                || (string.IsNullOrEmpty(txtNoOfWoodLength.Text)) || (string.IsNullOrEmpty(txtWoodHeight.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(ttt1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(ttt2.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(ttt3.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfWoodLength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWoodHeight.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                groupBox8.Visible = true;
                groupBox7.Visible = true;

                i = Double.Parse(ttt1.Text);
                j = Double.Parse(ttt2.Text);
                k = Double.Parse(ttt3.Text);
                l = Double.Parse(txtNoOfWoodLength.Text);
                Double m = Double.Parse(txtWoodHeight.Text);

                Double total = (i * l) + (j * m);
                chocketWoodForDoor = total * k;

                sftForChocketDoor = chocketWoodForDoor * (0.417 + 0.167);

                txtChocketWoodDoor.Text = chocketWoodForDoor.ToString("#.###");
            }
        }
//Leaf 
        private void btnLeafWindow_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtlengthLeaf.Text)) || (string.IsNullOrEmpty(txtWidthLeaf.Text)) || (string.IsNullOrEmpty(txtNoOfLeaf.Text)) || (string.IsNullOrEmpty(txtRateLeaf.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtlengthLeaf.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthLeaf.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfLeaf.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtRateLeaf.Text , "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                groupBox11.Visible = true;
                groupBox12.Visible = false;
                i = Double.Parse(txtlengthLeaf.Text);
                j = Double.Parse(txtWidthLeaf.Text);
                k = Double.Parse(txtNoOfLeaf.Text);
                l = Double.Parse(txtRateLeaf.Text);

                leafForWindow = (i * j) * l * k;
                txtPriceWinLeaf.Text = leafForWindow.ToString("#.###");

                sftWindowLeaf = (i * j * k);
                lblWindowLeaf.Text = sftWindowLeaf.ToString("#.##");
            }
        }
        private void btnLeafDoor_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = true;
            groupBox12.Visible = true;
            if ((string.IsNullOrEmpty(txtlengthLeaf.Text)) || (string.IsNullOrEmpty(txtWidthLeaf.Text)) || (string.IsNullOrEmpty(txtNoOfLeaf.Text)) || (string.IsNullOrEmpty(txtRateLeaf.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtlengthLeaf.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthLeaf.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfLeaf.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtRateLeaf.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(txtlengthLeaf.Text);
                j = Double.Parse(txtWidthLeaf.Text);
                k = Double.Parse(txtNoOfLeaf.Text);
                l = Double.Parse(txtRateLeaf.Text);

                leafForDoor = (i * j) * l * k;
                txtPriceDoorLeaf.Text = leafForDoor.ToString("#.###");

                sftDoorLeaf = i * j * k;
                lblDoorLeaf.Text = sftDoorLeaf.ToString("#.##");
            }
        }
//Gutter and Downtake Pipe
        private void button21_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtGutterLength.Text)) || (string.IsNullOrEmpty(txtDistanceBetweengutterFeet.Text)) || (string.IsNullOrEmpty(txtDistanceBetweenGutterInches.Text))
                || (string.IsNullOrEmpty(txtHeightPipe.Text)) || (string.IsNullOrEmpty(txtNoOfPipe.Text)) || (string.IsNullOrEmpty(txtPipeLength.Text))
                 || (string.IsNullOrEmpty(txtDistancePipeClickFeet.Text)) || (string.IsNullOrEmpty(txtDistancePipeClickInch.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtGutterLength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtDistanceBetweengutterFeet.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtDistanceBetweenGutterInches.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtHeightPipe.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfPipe.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtPipeLength.Text, "^[a-zA-Z]"))
                || (System.Text.RegularExpressions.Regex.IsMatch(txtDistancePipeClickFeet.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtDistancePipeClickInch.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                panel21.Visible = true;
                //  i = Double.Parse(txtGutterWidth.Text);
                j = Double.Parse(txtGutterLength.Text);

                k = Double.Parse(txtDistanceBetweengutterFeet.Text);
                l = Double.Parse(txtDistanceBetweenGutterInches.Text);
                Double t = k + (l / 12);

                Double m = Double.Parse(txtHeightPipe.Text);
                Double n = Double.Parse(txtNoOfPipe.Text);
                Double o = Double.Parse(txtPipeLength.Text);

                Double a = Double.Parse(txtDistancePipeClickFeet.Text);
                Double b = Double.Parse(txtDistancePipeClickInch.Text);
                Double c = a + (b / 12);

                readyMadeGutter = j;
                gutterBracket = j / t;
                PVCPipe = (m * n) / o;
                pipeClick = (m * n) / c;

                // txtReadyMadeGutter.Text = readyMadeGutter.ToString("#.###");
                txtGutterBracket.Text = gutterBracket.ToString("#.###");
                txtPVCPipe.Text = PVCPipe.ToString("#.##");
                txtPipeClick.Text = pipeClick.ToString("#.##");


            }
        }


//Footing
        private void button13_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(tr1.Text)) || (string.IsNullOrEmpty(tr2.Text)) || (string.IsNullOrEmpty(tr3.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(tr1.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(tr2.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(tr3.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {

                groupBox10.Visible = true;
                i = Double.Parse(tr1.Text);
                j = Double.Parse(tr2.Text);
                k = Double.Parse(tr3.Text);

                Double total = ((((2 * j) * i)) * 1.043) / 2240;
                rebarForFooting = total * k;
                bindingWireForFooting = (rebarForFooting * 20) / 3.6;
                tr4.Text = rebarForFooting.ToString("#.###");
                bDforFooting.Text = bindingWireForFooting.ToString("#.###");
            }
        }


//Plastering

        private void button14_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(ttLength.Text)) || (string.IsNullOrEmpty(ttWidth.Text)) )
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(ttLength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(ttWidth.Text, "^[a-zA-Z]")) 
              )
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                i = Double.Parse(ttLength.Text);
                j = Double.Parse(ttWidth.Text);
                cementForPlastering = ((i * j * 225) / 100) / 112;
                ttCement.Text = cementForPlastering.ToString();
                sandForPlastering = ((i * j * 7.5) / 100) / 100;
                ttSand.Text = sandForPlastering.ToString("#.###");
                workerForPlastering = ((i * j) * 3) / 100;
                txtWorkerForPlastering.Text = workerForPlastering.ToString("#");

            }
        }
//Stair
        private void btnStair_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtLengthStair.Text)) || (string.IsNullOrEmpty(txtWidthStair.Text)) || (string.IsNullOrEmpty(txtHeightStair.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtLengthStair.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtWidthStair.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtHeightStair.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                Double tot, yy = 0;
                i = Double.Parse(txtLengthStair.Text);
                j = Double.Parse(txtWidthStair.Text);
                k = Double.Parse(txtHeightStair.Text);
                for (Double t = 1; t <= i; t++)
                {
                    tot = t * j * (k / 12);
                    yy += tot;


                }



                brickStair = (yy * 1350) / 100;
                cementStair = ((yy * 780) / 100) / 112;
                sandStair = ((yy * 26) / 100) / 100;

                txtBrickStair.Text = brickStair.ToString();
                txtCementStair.Text = (Convert.ToInt16(cementStair)).ToString("#.###");
                txtSandStair.Text = sandStair.ToString("#.###");

            }
        }
//Roof

        private void button4_Click_1(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtPurlinLength.Text)) || (string.IsNullOrEmpty(txtRafterLength.Text)) || (string.IsNullOrEmpty(txtPainSheetWidth.Text)) || (string.IsNullOrEmpty(txtZincLength.Text)))
            {
                MessageBox.Show("Please Enter Value");

            }

            else if ((System.Text.RegularExpressions.Regex.IsMatch(txtPurlinLength.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtRafterLength.Text, "^[a-zA-Z]")) ||
                (System.Text.RegularExpressions.Regex.IsMatch(txtPainSheetWidth.Text, "^[a-zA-Z]")) || (System.Text.RegularExpressions.Regex.IsMatch(txtZincLength.Text, "^[a-zA-Z]")))
            {
                MessageBox.Show("not Accept Character,only integer");
            }
            else
            {
                Double purlinLength, rafterLength, plainSheetWidth;
                Double zincWidth = 2.5;
                purlinLength = Double.Parse(txtPurlinLength.Text);
                rafterLength = Double.Parse(txtRafterLength.Text);
                plainSheetWidth = Double.Parse(txtPainSheetWidth.Text);
                zincLength = Double.Parse(txtZincLength.Text);

                woodForPurlin = ((((rafterLength / 2) * purlinLength * 0.167 * 0.167)) * 2) / 50;  // 2 " 2 "

                woodForRafter = ((((purlinLength / 4) * 0.333 * 0.167 * rafterLength)) * 2) / 50;  //4" 2 "

                ZincNo = (((purlinLength / zincWidth) * 2)) * zincLength;

                eaveboardWoodForRoof = (((2 * purlinLength) * 0.667 * 0.083) / 50) + (((4 * rafterLength) * 0.667 * 0.083) / 50);// 8 " 1 "

                plainSheetForRoof = purlinLength;

                workerForRoof = ((purlinLength * rafterLength) * 3) / 100;

                pricePlainRidgingSheet = purlinLength * (Double.Parse(txtPainSheetWidth.Text));



                txtPurlinWood.Text = woodForPurlin.ToString("#.###");
                txtRafterWood.Text = woodForRafter.ToString("#.###");
                txtWoodForEvaeboard.Text = eaveboardWoodForRoof.ToString("#.###");
                txtNoOfPlainSheet.Text = plainSheetForRoof.ToString("#.###");
                txtZincNo.Text = ZincNo.ToString("#.###");
                txtWorkerForRoof.Text = workerForRoof.ToString("#");
                txtPlainRidgingSheetKyat.Text = pricePlainRidgingSheet.ToString("#.##");

            }

        }
      //Variable Declaration      
         Double totalCement, totalSand, totalAgg, totalBrick, totalJungleWood,totalRebar16mm,totalRebar6mm,totalBindingWire,
                totalNail,totalPlyWood,totalWorker,totalChocket,totalsftForLeaf,totalPriceForLeaf;
       
       
     // total Number And Price

        private void total_Click(object sender, EventArgs e)
        {

            totalBrick = brickForWall4 + brickForWall9 + brickFor2SideWall + brickFor3SideWall +
                        brickFor4SideWall + brickStair;

            totalSand = sandForColumn + sandForConcretFloor + sandForWall4 + sandForWall9 + sandFor2SideRoom +
                          sandFor3SideRoom + sandFor4SideRoom + sandForBeam2Side + sandForBeam3Side +
                          sandForPlastering + sandForSandFilling + sandFor3inchesLean + sandForTopping + sandStair +
                          sandForHardcore;

            totalCement = cementForColumn + cementForConcretFloor + cementForWall4 + cementForWall9 + cementFor2SideWall +
                         cementFor3SideWall + cementFor4SideWall + cementForBeam2Side + cementForBeam3Side +
                         cementForPlastering+cementFor3inchesLean+cementForTopping ;

            totalAgg = aggForColumn + aggForConcretFloor + aggForBeam2Side + aggForBeam3Side;

            totalJungleWood = woodForColumn + woodForBeam2Side + woodForBeam3Side + tonframe + tonpost + woodForPurlin +
                              woodForRafter + eaveboardWoodForRoof;
                           

            totalRebar16mm = rebar16mmColumn + rebar16mmForBeam2Side + rebar16mmForBeam3Side + rebarForFooting;

            totalRebar6mm = rebar6mmColumn + rebar6mmForBeam2Side + rebar6mmForBeam3Side;

            totalBindingWire = bindingWireforColumn + bindingWireForFooting + bindingWireforBeam2Side + bindingWireforBeam3Side;

            totalNail = nailForColumn + nailFor2Side + nailFor3Side;

            totalPlyWood = plywoodForColumn + plywoodFor2Side + plywoodFor3Side;

            totalWorker = workerForHardcore + workerWateringForSandFilling + workerCarryingForSandFilling + workerForColumn +
                          workerFor2Side + workerFor3Side + workerFor2SideRoom + workerFor3SideRoom + workerFor4SideRoom +
                          workerForFloor + workerFor3inchesLean + workerForTopping + workerForWall4 + workerForWall9 + 
                          workerForRoof + earthWorker + workerForPlastering;

            totalChocket = sftForChocket + sftForChocketDoor;

            totalsftForLeaf = sftDoorLeaf + sftWindowLeaf;

            totalPriceForLeaf = leafForDoor + leafForWindow;


            //Pipe Click
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + pipeClick  + "'" + " where MaterialName='Pipe Click' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //3" PVC Pipe
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + PVCPipe  + "'" + " where MaterialName='3\" PVC Pipe' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Gutter Bracket
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + gutterBracket  + "'" + " where MaterialName='Gutter Bracket' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Ready Made Gutter
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + readyMadeGutter + "'" + " where MaterialName='Ready Made Gutter' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //0.42 mm 4 Angle Sheet
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + ZincNo + "'" + " where MaterialName='0.42 mm 4 Angle Sheet' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Plain Ridging Sheet
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + plainSheetForRoof  + "'" + " where MaterialName='Plain Ridging Sheet' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Oil Paint
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + sftForOilPaint + "'" + " where MaterialName='Oil Paint' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Emulsion Paint
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + sftForEmulsionPaint  + "'" + " where MaterialName='Emulsion Paint' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 

            //Ceiling
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + sftForCeiling  + "'" + " where MaterialName='Ceiling' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Leaf
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalsftForLeaf  + "'" + " where MaterialName='Teak Pannel Door Leave' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //Chocket
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalChocket  + "'" + " where MaterialName='5\" 2\" Chocket' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
            //BrokenBrick
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + brokenBrickForHardcore  + "'" + " where MaterialName='Broken Brick' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Worker
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalWorker + "'" + " where MaterialName='Worker' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Ply wood
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalPlyWood + "'" + " where MaterialName='5 Ply Wood' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Nail
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalNail + "'" + " where MaterialName='Wire Nail' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Binding Wire
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalBindingWire + "'" + " where MaterialName='Binding Wire' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

       //6 mm Rebar
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalRebar6mm  + "'"+" where MaterialName='6 mm Rebar' ";
                
                
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //16 mm Rebar
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalRebar16mm + "'" + " where MaterialName='16 mm Rebar' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Brick
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalNumber='" + totalBrick + "'" + " where MaterialName='Brick' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            } 
       // cement


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                
                String query1 = "update Price set TotalNumber='" + totalCement + "'" + " where MaterialName='Cement' ";

               
                command.CommandText = query1;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            //Sand
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;


                String query1 = "update Price set TotalNumber='" + totalSand  + "'" + " where MaterialName='Sand' ";


                command.CommandText = query1;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            

        // Agg

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;


                String query1 = "update Price set TotalNumber='" + totalAgg  + "'" + " where MaterialName='Aggregate' ";


                command.CommandText = query1;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        //Jungle Wood 

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;


                String query1 = "update Price set TotalNumber='" + totalJungleWood  + "'" + " where MaterialName='Jungle Wood' ";


                command.CommandText = query1;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
//Set Price in Table

            //Pipe Click
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Pipe Click'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * pipeClick ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Pipe Click' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //3" PVC Pipe
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='3\" PVC Pipe'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * PVCPipe ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='3\" PVC Pipe' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // Gutter Bracket For Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Gutter Bracket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * gutterBracket ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Gutter Bracket' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // Ready Made Gutter For Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Ready Made Gutter'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * readyMadeGutter ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Ready Made Gutter' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // 0.42mm4AngleSheet
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='0.42 mm 4 Angle Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) *ZincNo ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r  + "'" + " where MaterialName='0.42 mm 4 Angle Sheet' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // Plain Ridging Sheet For Price
         /*   try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Plain Ridging Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * plainSheetForRoof ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + pricePlainRidgingSheet + "'" + " where MaterialName='Plain Ridging Sheet' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            // Oil Paint For Price
            /*try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Oil Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalChocket;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + priceForOilPaint + "'" + " where MaterialName='Oil Paint' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // Emulsion Paint For Price
            /*try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Emulsion Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalChocket;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + priceForEmulsionPaint  + "'" + " where MaterialName='Emulsion Paint' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            
            // Ceiling For Price
            /*try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Ceiling'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalChocket;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + priceForCeiling  + "'" + " where MaterialName='Ceiling' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // Leaf For Price
            /*try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Teak Pannel Door Leave'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalChocket;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }*/
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" +totalPriceForLeaf + "'" + " where MaterialName='Teak Pannel Door Leave' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            // Chocket for Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='5\" 2\" Chocket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) *totalChocket  ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='5\" 2\" Chocket' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            // Broken Brick For Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Broken Brick'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * brokenBrickForHardcore ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Broken Brick' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        // Brick For Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Brick'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalBrick ;
                    

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Brick' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //Cement For Price
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Cement'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalCement ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

  
            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Cement' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

     //Sand For Price

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Sand'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalSand ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Sand' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        // Wood for Price

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Jungle Wood'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalJungleWood ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Jungle Wood' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
           
            // total Aggregate

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Aggregate'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalAgg ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Aggregate' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //16mm Rebar

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='16 mm Rebar'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalRebar16mm ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='16 mm Rebar' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //6mm Rebar

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='6 mm Rebar'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalRebar6mm;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='6 mm Rebar' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
 //Binding Wire

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Binding Wire'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalBindingWire;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Binding Wire' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

 // Nail

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Wire Nail'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalNail;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Wire Nail' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            // 5 Ply Wood

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='5 Ply Wood'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) * totalPlyWood;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='5 Ply Wood' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //Worker

            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                String query = "select * from Price where MaterialName='Worker'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["MaterialPrice"].ToString();
                    r = Double.Parse(g) *totalWorker ;


                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            try
            {


                connection.Open();


                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;

                String query = "update Price set TotalPrice='" + r + "'" + " where MaterialName='Worker' ";


                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

           

           

            this.Hide();
            Result rs = new Result();
            rs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome w = new welcome();
            w.Show();
        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
        private void english_CheckedChanged(object sender, EventArgs e)
        {

            total.Visible = true;

            label353.Visible = false;
            label367.Visible = false;

            myanmar.Visible = false;
            english.Visible = false;
            
            tabControl1.Show();
            
            
        }


        private void myanmar_CheckedChanged(object sender, EventArgs e)
        {
            
            total.Visible = true;

            label353.Visible = false;
            label367.Visible = false;

            myanmar.Visible = false;
            english.Visible = false;
            

            tabControl1.Show();

            //PegOut

            label254.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label254.Text = "ပတ္တန္း";

            label2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label2.Text = "အလ်ား";

            label3.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label3.Text = "အနံ";

            label32.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label32.Text = "ေပ";

            label33.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label33.Text = "ေပ";

            label1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label1.Text = "ပတ္တန္း အတြက္ ကုန္က်ေသာ သစ္အေရအတြက္";

            button1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button1.Text = "တြက္ရန္";


            label4.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label4.Text = "ေဘာင္အတြက္ ကုန္က်ေသာ သစ္ ( ၆\" ၁\") ";

            label5.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label5.Text = "ေထာက္တိုင္္အတြက္ ကုန္က်ေသာ သစ္ ( ၃\" ၂\") ";

            label6.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label6.Text = "တန္ ";

            label7.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label7.Text = "တန္ ";

            //HardCore

            label267.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label267.Text = "အုတ္က်ိဳး နွင့္ သဲ ျဖည့္ျခင္း";

            label247.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label247.Text = "အလ်ား";

            label246.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label246.Text = "အနံ";

            label245.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label245.Text = "အျမင့္";

            label244.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label244.Text = "ေပ";

            label243.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label243.Text = "ေပ";

            button16.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button16.Text = "တြက္ရန္";


            label242.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label242.Text = "လက္မ ";

            label413.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label413.Text = "အုတ္က်ဳိးအတြက္ ကုန္က်ေသာ ပစၥည္းစားရင္း ";

            label253.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label253.Text = "အုတ္က်ဳိး ";

            label252.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label252.Text = "သဲ ";

            label251.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label251.Text = "အလုပ္သမား";

            label248.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label248.Text = "ေယာက္ ";

            label250.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label250.Text = "က်င္း ";

            label249.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label249.Text = "က်င္း ";

            groupBox13.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox13.Text = "အုတ္က်ဳိးခင္းလိုေသာ အက်ယ္၀န္းကို ထည့္ပါ";


            //Column

            label13.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label13.Text = "တိုင္ ၏ အလ်ား  ";

            label12.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label12.Text = "တိုင္ ၏ အနံ	";

            label11.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label11.Text = "တိုင္ ၏ အျမင့္";

            label29.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label29.Text = "လက္မ";

            label30.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label30.Text = "လက္မ";

            label31.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label31.Text = "ေပ";

            label43.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label43.Text = "ေပ";

            label208.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label208.Text = " 16mm သံအေရအတြက္ ";

            label10.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label10.Text = "တိုင္ အေရအတြက္";

            label146.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label146.Text = "တိုင္ အေရအတြက္";

           

            label200.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label200.Text = "6mm သံအေရအတြက္  ";

            label201.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label201.Text = "ခ်ည္ေသာ၀ါယာအေရအတြက္";

            label203.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label203.Text = "ခ်ည္ေသာ၀ါယာအေရအတြက္";

            label205.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label205.Text = "ပိသာ";

            label169.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label169.Text = "ပိသာ";

            label202.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label202.Text = "ပိသာ";

            label21.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label21.Text = "ဘိလပ္ေျမအေရအတြက";

            label25.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label25.Text = "အိတ္";

            label20.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label20.Text = "သဲအေရအတြက္";

            label26.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label26.Text = "က်င္း";

            label27.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label27.Text = "က်င္း";
           

            label14.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label14.Text = "ေက်ာက္";

            label23.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label23.Text = "ေတာသစ္္";

            label170.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label170.Text = "သံ";

            label168.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label168.Text = "လက္မ";

            label167.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label167.Text = "လက္မ";

            label319.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label319.Text = "ေပ";

            label145.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label145.Text = "ေပ";

            label332.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label332.Text = "ေခ်ာင္း";

            label333.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label333.Text = "တိုင္";

            label334.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label334.Text = "ေခ်ာင္း";

            label335.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label335.Text = "တိုင္";

            label318.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label318.Text = "ေယာက္";

            label148.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label148.Text = "ျခားေသာအကြာအေ၀း";


            label146.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label146.Text = "တိုင္အေရအတြက္";

            label143.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label143.Text = "ေပ";

            label149.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label149.Text = "သံေခ်ာင္း၏အရွည";

            label22.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label22.Text = "16mm သံအေရအတြက္္";

            label24.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label24.Text = "တန္";


            label144.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label144.Text = "တန္";


            label204.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label204.Text = "တန္";


            label28.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label28.Text = "တန္";

            label149.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label149.Text = "သံေခ်ာင္း၏အရွည္";


            label21.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label21.Text = "ဘိလပ္ေျမအေရအတြက္";



            button13.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button13.Text = "တြက္ရန္";


            button3.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button3.Text = "တြက္ရန္";
            //Roof

            label17.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label17.Text = "ျမွားတန္းအလ်ား";

            label16.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label16.Text = "ဒိုင္းအလ်ား";

            label19.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label19.Text = "4 Angle သြပ္အလ်ား";

            label239.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label239.Text = "၁ေပပတ္လည္ သြပ္ျပားေစ်းႏႈန္း";

            label35.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label35.Text = "ျမွားတန္းအတြက္ ၂”၂” သစ္အေရအတြက္";

            label34.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label34.Text = "ဒိုင္းအတြက္ ၄”၂” သစ္အေရအတြက္";

            label236.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label236.Text = "တံစက္ျမိတ္အတြက္ ၈”၁”သစ္အေရအတြက္";

            label36.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label36.Text = "4 Angle သြပ္အေရအတြက္";

            label238.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label238.Text = "သြပ္ျပားအေရအတြက္";

            label415.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label415.Text = "သြပ္ျပားကုန္က်ေငြ";

            label331.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label331.Text = "အလုပ္သမား";

            label18.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label18.Text = "ေပ";

           


            label171.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label171.Text = "ေပ";

            label172.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label172.Text = "ေပ ";

            label240.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label240.Text = "က်ပ္";

            label173.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label173.Text = "တန္";

            label174.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label174.Text = "တန္";

            label220.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label220.Text = "တန္";

            label175.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label175.Text = "ေပ ";

            label237.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label237.Text = "ေပ";

            label416.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label416.Text = "က်ပ္";

            label330.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label330.Text = "ေယာက္";

            label15.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label15.Text = "အမိုး မိုးျခင္း";

            //
            label141.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label141.Text = "တိုင္";

            label142.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label142.Text = "တိုင္ေအာက္ေျခ";

            label274.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label274.Text = "၁း၂း၄ ဘိလပ္ေျမ ကြန္ဂရစ္လုပ္ငန္း";

            groupBox1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox1.Text = "တိုင္အတြက္အခ်က္အလက္မ်ား";

            groupBox9.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox9.Text = "တိုင္ေအာက္ေျခအတြက္အခ်က္အလက္မ်ား";

            groupBox2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox2.Text = "တိုင္အတြက္ကုန္က်မည့္ပစၥည္း";

            groupBox10.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox10.Text = "တိုင္ေအာက္ေျခအတြက္ကုန္က်မည့္သံ";
            


            button4.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button4.Text = "တြက္ရန္";

            //Ceiling

            label296.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label296.Text = "အလ်ား	";

            label294.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label294.Text = "အနံ	";

            label292.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label292.Text = "တစ္ေပေစ်းႏႈန္း";

            label376.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label376.Text = "sft အတြက္မ်က္ႏွာက်က္";

            label290.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label290.Text = "က်ပ္";

            label295.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label295.Text = "ေပ";

            label293.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label293.Text = "ေပ";

            label291.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label291.Text = "က်ပ္";

            label297.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label297.Text = "ေစ်းႏႈန္း";

            label415.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label415.Text = "ေစ်းႏႈန္း";

            label289.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label289.Text = "မ်က္ႏွာက်က္";

            button19.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button19.Text = "တြက္ရန္";

            groupBox15.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox15.Text = "မ်က္နွာက်က္ အတြက္ ကုန္က်စရိတ္";
            
           //Beam

            label276.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label276.Text = "ရက္မ";

            label275.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label275.Text = "၁း၂း၄ ရွိေသာဘိလပ္ေၿမအခ်ိဳး";

            label212.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label212.Text = "၁၆မူးသံ";

            label111.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label111.Text = "တန္";

            label211.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label211.Text = "၆မူးသံ";

            label116.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label116.Text = "တန";

            label214.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label214.Text = "သြပ္နန္းၾကိဴး";

            label213.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label213.Text = "ပိႆာ";

            label115.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label115.Text = "ဘိလပ္ေၿမ";

            label110.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label110.Text = "အိတ္";

            label114.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label114.Text = "သဲ";

            label109.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label109.Text = "က်င္း";




            label113.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label113.Text = "ေက်ာက္";

            label107.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label107.Text = "က်င္း";

            label112.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label112.Text = "ေတာသစ္";

            label103.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label103.Text = "တန္";

            label159.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label159.Text = "သံ";

            label158.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label158.Text = "ပိႆာ";

            label160.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label160.Text = "၅ထပ္သား";

            label161.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label161.Text = "ခ်ပ္";

            label321.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label321.Text = "အလုပ္သမား";

            label320.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label320.Text = "ေယာက";

            label126.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label126.Text = "၁၆မူးသံ";


           
            label121.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label121.Text = "တန္";

            label218.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label218.Text = "၆မူးသံ ";

            label217.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label217.Text = "က်ပ္";

            label216.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label216.Text = "သြပ္နန္းၾကိဴး";

            label215.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label215.Text = "ပိႆာ";

            label125.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label125.Text = "ဘိလပ္ေၿမ";

            label120.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label120.Text = " အိတ္";

            label124.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label124.Text = "သဲ";

            label119.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label119.Text = "က်င္း";

            label123.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label123.Text = "ေက်ာက္";

            label118.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label118.Text = "က်င္း";

            
            label122.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label122.Text = "ေတာသစ္";

            label117.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label117.Text = "တန္";

            label165.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label165.Text = "သံ";

            label163.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label163.Text = "၅ထပ္သား";

            label164.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label164.Text = "ပိႆာ";

            label162.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label162.Text = "ခ်ပ္";

            label323.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label323.Text = "တန္";

            label322.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label322.Text = "ေယာက္";

           linkLabel1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
           linkLabel1.Text = "ေက်ာက္ပံုးေလာင္းၿခင္း ( ၂ဖက္ )";

           groupBox5.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
           groupBox5.Text = "ေက်ာက္ပံုးအတြက္ကုန္က်မူမ်ား(၂ဖက္)";

            linkLabel2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            linkLabel2.Text = "ေက်ာက္ပံုးအတြက္ကုန္က်မူမ်ား(၃ဖက္)";

            groupBox6.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox6.Text = "ေက်ာက္ပံုးအတြက္ကုန္က်မူမ်ား(၃ဖက္)";



            button4.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button4.Text = "တြက္ရန္";


            ////
            label108.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label108.Text = "အလ်ား";

            label104.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label104.Text = "ေပ";

            label127.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label127.Text = "အနံ";

            label128.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label128.Text = "လက္မ";

            label106.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label106.Text = "အၿမင့္";

            label102.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label102.Text = "လက္မ";

            label209.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label209.Text = "၁၆မူးသံ(၂ဖက္)";

            label105.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label105.Text = "ပရက္အေရအတြက္";

            label101.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label101.Text = "အလ်ား";

            label97.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label97.Text = "ေပ";

            label100.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label100.Text = "အနံ";

            label96.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label96.Text = "လက္မ";




            label99.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label99.Text = "အၿမင့္";

            label95.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label95.Text = "က်င္း";

            label210.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label210.Text = "၁၆မူးသံ(၂ဖက္)";

            label98.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label98.Text = "ပရက္အေရအတြက္";

            


            groupBox4.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox4.Text = "ပရက္အတြက္လိုအပ္္ခ်က္မ်ားရိုက္ထည္႔ရန္";

            groupBox3.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox3.Text = "ပရက္အတြက္လိုအပ္္ခ်က္မ်ားရိုက္ထည္႔ရန";


            button9.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button9.Text = "တြက္ရန္";

            button10.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button10.Text = "တြက္ရန္";
            //Floor

           

            label233.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label233.Text = "ၾကမ္းခင္း ၏ အလ်ား	";

            label44.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label44.Text = "ၾကမ္းခင္း ၏ အလ်ား	";

            label43.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label43.Text = "ၾကမ္းခင္း ၏ အနံ";

            label42.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label42.Text = "ၾကမ္းခင္း ၏ အျမင့္";

            label40.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label40.Text = "ကုန္က်မည့္ဘိလပ္ေျမအေရအတြက္";

            label48.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label48.Text = "ကုန္က်မည့္သဲအေရအတြက္္";

            label49.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label49.Text = "ကုန္က်မည့္ ေက်ာက္အေရအတြက္";

            label337.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label337.Text = "ကုန္က်မည့္အလုပ္သမားအေရအတြက္";

            label45.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label45.Text = "(၁း၃း၆ )ဘိလပ္ေျမကြန္ကရစ္ၾကမ္းခင္းလုပ္ငန္း(Lean Work)";

            label223.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label223.Text = "ၾကမ္းခင္း ၏ အလ်ား";

            label232.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label232.Text = "ၾကမ္းခင္း ၏ အနံ";

            label231.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label231.Text = " ၾကမ္းခင္း၏အျမင ";




            label226.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label226.Text = "ကုန္က်မည့္ဘိလပ္ေျမအေရအတြက္";

            label225.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label225.Text = "ကုန္က်မည့္သဲအေရအတြက္";

            label222.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label222.Text = "ကုန္က်မည့္ ေက်ာက္အေရအတြက္";

            label339.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label339.Text = "ကုန္က်မည့္အလုပ္သမားအေရအတြက္";

           
            label39.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label39.Text = "ေပ";

            label38.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label38.Text = "ေပ";

            label37.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label37.Text = "လက္မ";




            label46.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label46.Text = "အိတ္";

            label47.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label47.Text = "က်င္း";

            label50.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label50.Text = "က်င္း";

            label336.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label336.Text = " ေယာက္";

          
            label229.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label229.Text = "ေပ";

            label228.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label228.Text = "ေပ";

            label227.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label227.Text = "လက္မ";




            label224.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label224.Text = "အိတ္";

            label223.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label223.Text = "က်င္း";

            label221.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label221.Text = "က်င္း";

            label338.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label338.Text = "ေယာက္";

            label235.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label235.Text = "ေက်ာက္စရစ္(သို႕)လိပ္သဲေက်ာက္ကိုသံုး၍(၁း၃း၆)ဘိလပ္ေျမကြန္ကရစ္ၾကမ္းခင္းလုပ္ငန္း";


            button15.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button15.Text = "တြက္ရန္";

            button5.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button5.Text = "တြက္ရန္";

            //Plastering
            



            label150.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label150.Text = "အေခ်ာကိုင္မည့္ အလ်ား";

            label153.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label153.Text = "အေခ်ာကိုင္မည့္ အနံ";

            label152.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label152.Text = "ကုန္က်မည့္ဘိလပ္ေျမအေရအတြက္္";

            label151.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label151.Text = "ကုန္က်မည့္ သဲအေရအတြက္";

            label339.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label339.Text = "ကုန္က်မည့္အလုပ္သမားအေရအတြက";

            label154.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label154.Text = "အိတ္";

            label157.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label157.Text = "က်င္း";

            label350.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label350.Text = "ေယာက္";

            label155.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label155.Text = "ေပ";

            label156.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label156.Text = "ေပ";

            button14.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button14.Text = "တြက္ရန္";

            label147.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label147.Text = "အေခ်ာကိုင္ျခင္း";

            label351.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label351.Text = "အလုပ္သမားအေရအတြက္";

            //Earth Worth

            label299.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label299.Text = "တြင္းအလ်ား";

            label300.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label300.Text = "တြင္းအနံ ";

            label302.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label302.Text = "တြင္းအျမင့္";

            label307.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label307.Text = "အလုပ္သမား";

            label301.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label301.Text = "ေယာက္";

            label305.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label305.Text = "ေပ";

            label306.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label306.Text = "ေပ";

            label308.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label308.Text = "ေပ";

            label298.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label298.Text = "ေျမတြင္းတူးျခင္း";

            groupBox16.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox16.Text = "ေျမတြင္းတူးျခင္းအခ်က္အလတ္မ်ားထည့္ပါ";

            groupBox17.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox17.Text = "အလုပ္သမားအေရအတြက္မ်ား";

            button20.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button20.Text = "တြက္ရန္";


           

            // Wall
            label116.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label116.Text = "ဘိလပ္ေျမအခ်ိဳးအဆ(၁:၃)";

            label57.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label57.Text = "အလ်ား";

            label56.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label56.Text = "အျမင့္";

            label55.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label55.Text = "အုတ္";

            label54.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label54.Text = "ဘိလပ္ေျမ";

            label53.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label53.Text = "သဲ";

            label325.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label325.Text = "အလုပ္သမားအေရအတြက္";

            label58.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label58.Text = "ေပ";

            label59.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label59.Text = "ေပ";

            label329.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label329.Text = "လံုး";

            label52.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label52.Text = "အိတ္";

            label51.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label51.Text = "က်င္း";

            label324.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label324.Text = "ေယာက္";

            button6.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button6.Text = "တြက္ရန္";

            button7.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button7.Text = "တြက္ရန္";


            label68.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label68.Text = "အလ်ား";

            label166.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label166.Text = "အုတ္စီလုပ္ငန္း";

            

            label67.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label67.Text = "အနံ";

            label69.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label69.Text = "အျမင့္ ";

            label66.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label66.Text = "အုတ္";

            label65.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label65.Text = "ဘိလပ္ေျမ";

            label64.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label64.Text = "သဲ";

            label327.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label327.Text = "အလုပ္သမားအေရအတြက္";

            label61.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label61.Text = "ေပ";

            label60.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label60.Text = "လက္မ";

            label70.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label70.Text = "ေပ";

            
            label328.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label328.Text = "လံုး";

            label63.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label63.Text = "အိတ";

            label62.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label62.Text = "က်င္း";

            label326.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label326.Text = "ေယာက္";

            checkBox2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            checkBox2.Text = "၉လက္မ(သို ့)၉လက္မထက္အထူရွိေသာနံရံ";

            checkBox1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            checkBox1.Text = "၄လက္မအထူရွိေသာနံရံ";

            //Door and Window 


            label133.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label133.Text = "က်ည္းေဘာင္";

            label134.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label134.Text = "အလ်ား";

            label135.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label135.Text = "အျမင့္";

            label268.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label268.Text = "အလ်ားလိုက္သစ္အေရအတြက္";

            label271.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label271.Text = "ေဒါင္လိုက္သစ္အေရအတြက္";

            label136.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label136.Text = "က်ည္းေဘာင္အေရအတြက္";
             
            label372.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label372.Text = "ေခ်ာင္း";

            label377.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label377.Text = "ေခ်ာင္း";

            label379.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label379.Text = "ခု";


            label9.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label9.Text = "ေပ";

            label8.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label8.Text = "ေပ";


            label137.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label137.Text = "၅\"၂\" သစ္";

            label138.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label138.Text = "ေပ";

            label140.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label140.Text = "၅\"၂\" သစ္";

            label139.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label139.Text = "ေပ";

            label389.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label389.Text = "တံခါးရြက္";

            label177.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label177.Text = "အလ်ား";


            label176.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label176.Text = "ေပ";

            label179.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label179.Text = "အျမင့္";

            label178.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label178.Text = "ေပ";

            label187.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label187.Text = "တံခါးရြက္အေရအတြက္";


            label380.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label380.Text = "ခု";

            label181.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label181.Text = "၁ေပပတ္လည္ေစ်းႏႈန္း";

            label180.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label180.Text = "က်ပ္";

            label373.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label373.Text = "sft ျပတင္းေပါက္ အတြက္";


            label183.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label183.Text = "ကုန္က်ေငြ";

            label182.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label182.Text = "က်ပ္";

            label374.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label374.Text = "sft တံခါး အတြက္";

            label185.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label185.Text = "ကုန္က်ေငြ";


            label184.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label184.Text = "က်ပ္";

            button11.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button11.Text = "ျပတင္းေပါက္ တြက္ရန္";

            button12.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button12.Text = "တံခါး တြက္ရန္";

            btnLeafWindow.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            btnLeafWindow.Text = "ျပတင္းေပါက္ တြက္ရန္";

            btnLeafDoor.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            btnLeafDoor.Text = "တံခါး တြက္ရန္";

            groupBox8.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox8.Text = "တံခါးအတြက္ကုန္က်မည့္ပစၥည္း";

            groupBox11.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox11.Text = "ျပတင္းေပါက္ အတြက္ကုန္က်မည့္ပစၥည္း";

            groupBox12.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox12.Text = "တံခါး အတြ က္ကုန္က်မည့္ပစၥည္း";

            groupBox7.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox7.Text = "ျပတင္းေပါက္အတြက္ကုန္က်မည့္ပစၥည္း";


            //Stair

           


            label188.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label188.Text = "ေလွကား";

            label206.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label206.Text = "ေက်းဇူးျပဳ၍ေလွကားအခ်က္အလက္မ်ားကိုရုိက္ထည့္ပါ";

            label194.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label194.Text = "အလ်ား";

            label193.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label193.Text = "အနံ";

            label190.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label190.Text = "အျမင့္";

            label192.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label192.Text = "ေပ";

            label189.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label189.Text = "ေပ";

            label191.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label191.Text = "လက္မ";

            label207.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label207.Text = "ေလွကားအတြက္ကုန္က်ေသာအခ်က္အလက္";


            label199.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label199.Text = "အုတ္";

            label198.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label198.Text = "ဘိလပ္ေျမ";


            label197.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label197.Text = "သဲ";

            label381.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label381.Text = "လံုး";

            label196.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label196.Text = "အိတ္";

            label195.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label195.Text = "က်င္း";

            btnStair.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            btnStair.Text = "တြက္ရန္";

            //sand filling

            label241.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label241.Text = "သဲဖို႔ပီးေရေလာင္းၿခင္းလုပ္ငန္း";

            label255.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label255.Text = "အလ်ား";

            label261.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label261.Text = "ေပ";

            label256.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label256.Text = "အနံ";

            label262.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label262.Text = "ေပ";

            label258.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label258.Text = "အၿမင့္ ";

            label264.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label264.Text = "လက္မ";

            label414.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label414.Text = " သဲဖို႔ပီးေရေလာင္းၿခင္းအတြက္ကုန္က်စရိတ္မ်ား";

            label266.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label266.Text = "သဲ";


            label260.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label260.Text = "က်င္း";

            label265.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label265.Text = "ေရေလာင္းလုပ္သား";


            label259.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label259.Text = "ေယာက္";

            label263.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label263.Text = "သဲသယ္/ဒင္ထုလုပ္သား";

            label257.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label257.Text = "ေယာက္";

            groupBox14.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox14.Text = "လိုအပ္ေသာအခ်က္အလက္မ်ား႐ိုက္ထည့္ေပးရန္";

            button17.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button17.Text = "တြက္ရန္";

           
            //Paint

            label303.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label303.Text = "ေဆးသုတ္ၿခင္းလုပ္ငန္း";

            label311.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label311.Text = "အလ်ား";

            label304.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label304.Text = "ေပ";

            label310.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label310.Text = "အနံ";

            label309.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label309.Text = "ေပ";

            label317.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label317.Text = "၁စတုရန္းေပအတြက္ကုန္က်ေငြ ";

            label316.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label316.Text = "က်ပ္";

            label313.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label313.Text = "စတုရန္းေပတခုၿခင္းအတြက္ကုန္က်ေငြ";

            label314.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label314.Text = "က်ပ္";


            label378.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label378.Text = "စတုရန္းေပတခုၿခင္းစီအတြက္ကုန္က်ေငြ";

            label312.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label312.Text = "က်ပ္";

            label408.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label408.Text = "ပံု (၁) ေရေဆး ၄၀၈";

            label409.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label409.Text = "ပံု (၁) ေရေဆး ၄၀၈";


            groupBox18.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox18.Text = "လိုအပ္ေသာအခ်က္မ်ား႐ိုက္ထည္႔ေပးရန္";

            groupBox20.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox20.Text = "ဆီေဆးသုတ္ၿခင္းအတြက္ကုန္က်ၿခင္းမ်ား";

            radioButton4.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            radioButton4.Text = "ပလပ္စတစ္ေဆးတစ္ထပ္သုတ္လုပ္ငန္း";

            radioButton5.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            radioButton5.Text = "ဆီေဆးသုတ္ၿခင္းလုပ္ငန္း";

            groupBox19.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox19.Text = "ပလပ္စတစ္ေဆးတစ္ထပ္သုတ္ၿခင္းအတြက္ကုန္က်ၿခင္းမ်ား";


            /////
            //Topping

            label277.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label277.Text = "ၾကမ္းခင္းအပါးခင္းျခင္း ( ၁ း၂ း ၃ )";

            label287.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label287.Text = "ၾကမ္းခင္းအပါးအလ်ား";

            label286.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label286.Text = " ၾကမ္းခင္းအပါးအနံ ";

            label283.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label283.Text = "ကုန္က်မည့္ဘိလပ္ေျမအေရအတြက္	";

            label282.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label282.Text = "ကုန္က်မည့္သဲအေရအတြက္	";

            label288.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label288.Text = "ကုန္က်မည့္ ေက်ာက္အေရအတြက္";

            label348.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label348.Text = "ကုန္က်မည့္အလုပ္သမားအေရအတြက";

            label281.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label281.Text = "အိတ";

            label284.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label284.Text = "က်င္း";

            label285.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label285.Text = " ေပ";


            label278.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label278.Text = "က်င္း";

            label280.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label280.Text = "က်င္း";

            label349.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label349.Text = "ေယာက္";

            button18.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button18.Text = "တြက္ရန္";

           //Gutter and Pipe

            label352.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label352.Text = "ေရတေလ်ာက္နွင့္ပိုက္တပ္ဆင္ျခင္း";

            label354.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label354.Text = "ေရတေလ်ာက္အရွည္";

            label356.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label356.Text = "ေပ";

            label357.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label357.Text = "ေရတေလ်ာက္ခ်ိတ္အျကားျခားမည့္အကြာအေ၀း";

            label358.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label358.Text = "ေပ";

            label359.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label359.Text = "လက္မ";

            label360.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label360.Text = "လိုအပ္ေသာအိမ္အျမင့္";

            label363.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label363.Text = "ေပ";

            label361.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label361.Text = "ပိုက္အေရအတြက္";

            label364.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label364.Text = "ေခ်ာင္း";

            label362.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label362.Text = "ပိုက္အရွည္";

            label365.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label365.Text = "ေပ";




            label395.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label395.Text = "ပိုက္ကလစ္တစ္ခုနွင့္တစ္ခုျကားျခားမည့္အကြာအေ၀း";

            label394.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label394.Text = "ေပ ";

            label393.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label393.Text = "လက္မ";

            label369.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label369.Text = "ေရတေလ်ာက္ခ်ိတ္အေရအတြက္";

            label368.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label368.Text = "ေခ်ာင္း";

            label370.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label370.Text = "PVC ပိုက္အေရအတြက္";

            label371.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label371.Text = "ေခ်ာင္း ";

            label397.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label397.Text = "ပိုက္ကလစ္အေရအတြက္";

            label400.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label400.Text = "ၿခားေသာ အကြာအေ၀း";

            label398.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label398.Text = " အရွည္";

            label396.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label396.Text = "ေခ်ာင္း";

            groupBox21.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox21.Text = "အသင့္ထုတ္ထားေသာေရတေလ်ာက္";

            groupBox22.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox22.Text = "ေရတေလ်ာက္ခ်ိတ္";

            groupBox23.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            groupBox23.Text = "ပိုက္";

            


            button21.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button21.Text = "တြက္ရန္";

 
            // Room

            label72.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label72.Text = "အခန္းဖြဲ႕ၿခင္း";

            label73.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label73.Text = "နံရံအမ်ိဳးအစားေရြးရန္";

            radioButton1.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            radioButton1.Text = "၂ဖက္";

            radioButton2.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            radioButton2.Text = "၃ဖက္";

            radioButton3.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            radioButton3.Text = "၄ဖက္";

            label75.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label75.Text = "အလ်ား";

            label130.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label130.Text = "ေပ";

            label129.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label129.Text = "အနံ";

            label131.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label131.Text = "ေပ";

            label74.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label74.Text = "အၿမင့္";

            label132.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label132.Text = "ေပ";

            label76.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label76.Text = "အခန္းအေရအတြက္";




            label315.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label315.Text = "ခန္း";

            label94.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label94.Text = "လ္ိုအပ္ေသာကုန္က်ၿခင္းမ်ား(၄ဖက္) ";

            label93.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label93.Text = "အုတ္";

            label92.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label92.Text = "ဘိလပ္ေၿမ";

            label90.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label90.Text = "အိတ္";

            label91.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label91.Text = "သဲ";

            label89.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label89.Text = "က်င္း";

            label345.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label345.Text = "အလုပ္သမား ";

            label342.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label342.Text = "ေယာက္";

            label77.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label77.Text = "လ္ိုအပ္ေသာကုန္က်ၿခင္းမ်ား(၂ဖက္)";

            label78.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label78.Text = " အုတ္";

            label346.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label346.Text = "လုံး";

          ////
            label79.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label79.Text = "ဘိလပ္ေၿမ";

            label81.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label81.Text = "အိတ္";

            label80.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label80.Text = "သဲ";

            label82.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label82.Text = "က်င္း";

            label341.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label341.Text = "အလုပ္သမား";

            label344.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label344.Text = "ေယာက္";


            label88.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label88.Text = "လ္ိုအပ္ေသာကုန္က်ၿခင္းမ်ား(၃ဖက္)";

            label87.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label87.Text = "အုတ္ ";

            label347.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label347.Text = "လုံး";

            label86.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label86.Text = "ဘိလပ္ေၿမ";

            label84.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label84.Text = "အိတ္";

            label85.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label85.Text = "သဲ";

            label83.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label83.Text = "က်င္း ";

            label343.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label343.Text = "အလုပ္သမား";

            label340.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            label340.Text = "ေယာက္";

           


            button8.Font = new Font("Zawgyi-One", 12, FontStyle.Bold);
            button8.Text = "တြက္ရန္";

            


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

      
       

        
       
        
        
      

        
       

       

     
       
      
       
      

       

      

       
        
       

       
       

    }
}
