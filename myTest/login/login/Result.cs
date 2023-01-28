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
    public partial class Result : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public Result()
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Aspire  V5\Desktop\myTest\MaterialPrice.accdb;
                                           Persist Security Info=False;";
            InitializeComponent();
        }


        Double allPriceTotal;
        String g;
        String priceBrick, priceSand, priceAgg, priceCement, priceWood, price16mmRebar, price6mmRebar, priceBindingWire,
               price5PlyWood, priceWireNail, priceBrokenBrick, price4AngleSheet, pricePlainRidgingSheet, priceReadyMadeGutter,
               priceGutterBracket, pricePVCPipe, priceChocket, priceLeaf, priceCeiling, priceEmulsionPaint, priceOilPaint,priceWorker,pricePipeClick,priceRidgingSheet;
        private void Result_Load(object sender, EventArgs e)
        {

// Pipe Click 
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

                    g = reader["TotalNumber"].ToString();
                    NoPipeClick.Text = g;

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
                String query = "select * from Price where MaterialName='Pipe Click'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    pricePipeClick  = reader["TotalPrice"].ToString();
                    PricePipeClick.Text = pricePipeClick;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

 // Binding Wire  
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

                g  = reader["TotalNumber"].ToString();
                    NoBindingWire.Text = g;

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
                String query = "select * from Price where MaterialName='Binding Wire'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceBindingWire  = reader["TotalPrice"].ToString();
                    PriceBindingWire.Text = priceBindingWire ;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }           
// 6mmRebar  
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

                    g = reader["TotalNumber"].ToString();
                    No6mmRebar.Text = g;

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
                String query = "select * from Price where MaterialName='6 mm Rebar'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   price6mmRebar  = reader["TotalPrice"].ToString();
                    Price6mmRebar.Text = price6mmRebar ;

                }
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

                    g = reader["TotalNumber"].ToString();
                    NoWireNail.Text = g;

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
                String query = "select * from Price where MaterialName='Wire Nail'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceWireNail  = reader["TotalPrice"].ToString();
                    PriceWireNail.Text = priceWireNail ;

                }
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

                    g = reader["TotalNumber"].ToString();
                    No5PlyWood.Text = g;

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
                String query = "select * from Price where MaterialName='5 Ply Wood'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    price5PlyWood  = reader["TotalPrice"].ToString();
                    Price5PlyWood.Text = price5PlyWood ;

                }
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
                String query = "select * from Price where MaterialName='Brick'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoBrick .Text =g;

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
                String query = "select * from Price where MaterialName='Brick'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceBrick  = reader["TotalPrice"].ToString();
                    PriceBrick.Text = priceBrick ;

                }
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
                String query = "select * from Price where MaterialName='Sand'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoSand .Text  = g;

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
                String query = "select * from Price where MaterialName='Sand'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceSand  = reader["TotalPrice"].ToString();
                    PriceSand.Text = priceSand ;

                }
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
                String query = "select * from Price where MaterialName='Aggregate'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoAgg.Text = g;

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
                String query = "select * from Price where MaterialName='Aggregate'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceAgg  = reader["TotalPrice"].ToString();
                    PriceAgg.Text = priceAgg ;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

// 16mmRebar  
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

                    g = reader["TotalNumber"].ToString();
                    No16mmRebar.Text = g;

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
                String query = "select * from Price where MaterialName='16 mm Rebar'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    price16mmRebar  = reader["TotalPrice"].ToString();
                    Price16mm.Text = price16mmRebar ;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

//Cement
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

                    g = reader["TotalNumber"].ToString();
                    NoCement.Text = g;

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
                String query = "select * from Price where MaterialName='Cement'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceCement  = reader["TotalPrice"].ToString();
                    PriceCement.Text = priceCement ;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
 //Wood
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

                    g = reader["TotalNumber"].ToString();
                    NoWood.Text = g;

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
                String query = "select * from Price where MaterialName='Jungle Wood'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceWood  = reader["TotalPrice"].ToString();
                    PriceWood.Text = priceWood ;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

//Broken Brick
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

                    g = reader["TotalNumber"].ToString();
                    NoBrokenBrick.Text  = g;

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
                String query = "select * from Price where MaterialName='Broken Brick'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceBrokenBrick  = reader["TotalPrice"].ToString();
                    PriceBrokenBrick.Text  = priceBrokenBrick ;

                }
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
                String query = "select * from Price where MaterialName='0.42 mm 4 Angle Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    No4AngleSheet .Text  = g;

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
                String query = "select * from Price where MaterialName='0.42 mm 4 Angle Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    price4AngleSheet = reader["TotalPrice"].ToString();
                    Price4AngleSheet.Text = price4AngleSheet;

                }
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
                String query = "select * from Price where MaterialName='Plain Ridging Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoPlainRidging.Text = g;

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
                String query = "select * from Price where MaterialName='Plain Ridging Sheet'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceRidgingSheet= reader["TotalPrice"].ToString();
                    PricePlainRidging.Text = priceRidgingSheet;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

           // Ready Made Gutter
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

                    g = reader["TotalNumber"].ToString();
                    NoReadyMadeGutter.Text = g;

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
                String query = "select * from Price where MaterialName='Ready Made Gutter'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceReadyMadeGutter = reader["TotalPrice"].ToString();
                    PriceReadyMadeGutter.Text = priceReadyMadeGutter;

                }
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
                String query = "select * from Price where MaterialName='Gutter Bracket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                   NoGutterBracket.Text = g;

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
                String query = "select * from Price where MaterialName='Gutter Bracket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceGutterBracket  = reader["TotalPrice"].ToString();
                   PriceGutterBracket.Text = priceGutterBracket;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            //PVC Pipe
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

                    g = reader["TotalNumber"].ToString();
                    NoPVCPipe.Text = g;

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
                String query = "select * from Price where MaterialName='3\" PVC Pipe'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    pricePVCPipe = reader["TotalPrice"].ToString();
                    PricePVCPipe.Text = pricePVCPipe;

                }
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
                String query = "select * from Price where MaterialName='5\" 2\" Chocket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoChocket.Text = g;

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
                String query = "select * from Price where MaterialName='5\" 2\" Chocket'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceChocket  = reader["TotalPrice"].ToString();
                    PriceChocket.Text = priceChocket;

                }
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
                String query = "select * from Price where MaterialName='Teak Pannel Door Leave'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoLeaf.Text = g;

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
                String query = "select * from Price where MaterialName='Teak Pannel Door Leave'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceLeaf  = reader["TotalPrice"].ToString();
                   PriceLeaf.Text = priceLeaf;

                }
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
                String query = "select * from Price where MaterialName='Ceiling'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoCeiling.Text = g;

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
                String query = "select * from Price where MaterialName='Ceiling'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceCeiling  = reader["TotalPrice"].ToString();
                    PriceCeiling.Text = priceCeiling;

                }
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
                String query = "select * from Price where MaterialName='Emulsion Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoEmulsionPaint.Text = g;

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
                String query = "select * from Price where MaterialName='Emulsion Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    priceEmulsionPaint  = reader["TotalPrice"].ToString();
                    PriceEmulsionPaint.Text = priceEmulsionPaint;

                }
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
                String query = "select * from Price where MaterialName='Oil Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    g = reader["TotalNumber"].ToString();
                    NoOilPaint.Text = g;

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
                String query = "select * from Price where MaterialName='Oil Paint'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceOilPaint  = reader["TotalPrice"].ToString();
                   PriceOilPaint.Text = priceOilPaint;

                }
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

                    g = reader["TotalNumber"].ToString();
                    NoWorker.Text = g;

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
                String query = "select * from Price where MaterialName='Worker'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                   priceWorker  = reader["TotalPrice"].ToString();
                  

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }


            allPriceTotal = Double.Parse(priceBrick) + Double.Parse(priceSand) + Double.Parse(priceAgg) +
                Double.Parse(priceCement) + Double.Parse(priceWood) + Double.Parse(price16mmRebar) +
                Double.Parse(price6mmRebar) + Double.Parse(priceBindingWire) +
               Double.Parse(price5PlyWood) + Double.Parse(priceWireNail) + Double.Parse(priceBrokenBrick) + Double.Parse(price4AngleSheet) +
               Double.Parse(priceRidgingSheet ) + Double.Parse(priceReadyMadeGutter) +
               Double.Parse(priceGutterBracket) + Double.Parse(pricePVCPipe) +
               Double.Parse(priceChocket) + Double.Parse(priceLeaf) + Double.Parse(priceCeiling) +
               Double.Parse(priceEmulsionPaint) + Double.Parse(priceOilPaint);


            lblAllTotalPrice.Text = allPriceTotal.ToString("#.###");
            Double h = Double.Parse(priceWorker);
            lblTotalWorkerPrice.Text = h.ToString("#") ;

            Double t = allPriceTotal + h;
            lblAllTotal.Text = t.ToString("#.###");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome w = new welcome();
            w.Show();
        }

       

       

        

       
        }

        
    }

