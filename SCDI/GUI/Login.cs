﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCDI.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Close();
            var Main = new Main();
            Main.Show();
        }

        private void bntRegistrarse_Click(object sender, EventArgs e)
        {
            Close();
            var registro = new Registro();
            registro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataManager.DBConexion o = new DataManager.DBConexion();
            if (o.Conectar())
            {
                MessageBox.Show("Conectado");
                o.Desconectar();
            }
        }
    }
}
