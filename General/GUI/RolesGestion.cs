﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class RolesGestion : Form
    {

        BindingSource datos = new BindingSource();

        private void CargarDatos()
        {
            try
            {
                datos.DataSource = DataManager.DBConsultas.Roles();
                dgvDatos.DataSource = datos;
                dgvDatos.AutoGenerateColumns = false;//Impide generar automaticamente las columnas de encabezado
                //Codigo para insertar los datos en el datagrid

            }
            catch (Exception)
            {

                throw;
            }
        }

        public RolesGestion()
        {
            InitializeComponent();
        }

        private void RolesGestion_Load(object sender, EventArgs e)
        {
            CargarDatos();
            //Codigo para mostrar cuantas filas se 
            lblRegistros.Text = datos.List.Count.ToString() + " Registros Encontrados";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RolesEdicion f = new RolesEdicion();
            f.ShowDialog();
        }
    }
}
