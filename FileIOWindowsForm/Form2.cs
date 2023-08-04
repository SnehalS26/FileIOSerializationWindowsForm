using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Binary Serialization
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//XML
using System.Xml.Serialization;
//SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JSON
using System.Text.Json;

namespace FileIOWindowsForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.dat";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                BinaryFormatter formatter = new BinaryFormatter();
                Product p = new Product();
                p.Id = Convert.ToInt32(textProdId.Text);
                p.Name = textProdName.Text;
                p.Price = Convert.ToInt32(textProdPrice.Text);
                formatter.Serialize(fileStream, p);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnBinaryread_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.dat";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                Product p1 = new Product();
                // we done explicit type casting from Object --> Product
                p1 = (Product)formatter.Deserialize(fileStream);
                textProdId.Text = p1.Id.ToString();
                textProdName.Text = p1.Name.ToString();
                textProdPrice.Text = p1.Price.ToString();
                fileStream.Close();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.xml";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product p = new Product();
                p.Id = Convert.ToInt32(textProdId.Text);
                p.Name = textProdName.Text;
                p.Price = Convert.ToInt32(textProdPrice.Text);
                xmlSerializer.Serialize(fileStream, p);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLread_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.xml";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Product));
                Product p1 = new Product();
                p1 = (Product)xmlSerializer.Deserialize(fileStream);
                textProdId.Text = p1.Id.ToString();
                textProdName.Text = p1.Name.ToString();
                textProdPrice.Text = p1.Price.ToString();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.soap";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                SoapFormatter soapFormatter = new SoapFormatter();
                Product p = new Product();
                p.Id = Convert.ToInt32(textProdId.Text);
                p.Name = textProdName.Text;
                p.Price = Convert.ToInt32(textProdPrice.Text);
                soapFormatter.Serialize(fileStream, p);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.soap";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                SoapFormatter soapFormatter = new SoapFormatter();
                Product p1 = new Product();
                p1 = (Product)soapFormatter.Deserialize(fileStream);
                textProdId.Text = p1.Id.ToString();
                textProdName.Text = p1.Name.ToString();
                textProdPrice.Text = p1.Price.ToString();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.json";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
               
                Product p = new Product();
                p.Id = Convert.ToInt32(textProdId.Text);
                p.Name = textProdName.Text;
                p.Price = Convert.ToInt32(textProdPrice.Text);
                JsonSerializer.Serialize<Product>(fileStream,p);
                fileStream.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"C:\DP4-Laksha\prod.json";
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                
                Product p1 = new Product();
                p1 = (Product)JsonSerializer.Deserialize<Product>(fileStream);
                textProdId.Text = p1.Id.ToString();
                textProdName.Text = p1.Name.ToString();
                textProdPrice.Text = p1.Price.ToString();
                fileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
