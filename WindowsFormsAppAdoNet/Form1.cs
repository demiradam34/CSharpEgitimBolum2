﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Product productDAL = new Product(); // veritabanı işlemlerinin olduğu sınıfı tanımladık
        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvUrunler.DataSource = productDAL.GetAll(); //FromChildHandle ön yüzdeki 
        }
    }
}
