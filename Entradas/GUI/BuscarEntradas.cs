﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entradas.GUI
{
    public partial class BuscarEntradas : Form
    {
        public BuscarEntradas()
        {
            InitializeComponent();
        }

        private void BuscarEntradas_Load(object sender, EventArgs e)
        {
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            txtDocProveedor.Text = "";
            txtNombreProveedor.Text = "";
            txtUsuario.Text = "";
            dgvDatos.DataSource = null;
            dgvDatos.Rows.Clear();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = " ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                DataTable datos = new DataTable();
                Reportes.REP.Entradas oReporte = new Reportes.REP.Entradas();
                datos = DataManager.DBConsultas.Entradas(txtDocumento.Text);
                oReporte.SetDataSource(datos);
                Reportes.GUI.VisorEntradas f = new Reportes.GUI.VisorEntradas();
                f.crvVisor.ReportSource = oReporte;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos que mostrar en el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tEntradas = DataManager.DBConsultas.Entradas(txtDocumento.Text);
                dgvDatos.DataSource = tEntradas;
                dgvDatos.AutoGenerateColumns = false;//Impide generar automaticamente las columnas de encabezado
                                                     //Codigo para mostrar cuantas filas se
                if (dgvDatos.RowCount > 0)
                {
                    dtpFecha.Format = DateTimePickerFormat.Custom;
                    dtpFecha.CustomFormat = "yyyy/MM/dd";
                    txtDocProveedor.Text = dgvDatos.Rows[0].Cells["documento"].Value.ToString();
                    txtNombreProveedor.Text = dgvDatos.Rows[0].Cells["nombre_proveedor"].Value.ToString();
                    dtpFecha.Text = dgvDatos.Rows[0].Cells["fecha_entrada"].Value.ToString();
                    txtUsuario.Text = dgvDatos.Rows[0].Cells["usuario"].Value.ToString();
                    lblTotal.Text = dgvDatos.Rows[0].Cells["total"].Value.ToString();
                    lblRegistro.Text = dgvDatos.RowCount.ToString();
                }
                else
                {
                    dtpFecha.Format = DateTimePickerFormat.Custom;
                    dtpFecha.CustomFormat = " ";
                    txtDocProveedor.Text = "";
                    txtNombreProveedor.Text = "";
                    dtpFecha.Text = "";
                    txtUsuario.Text = "";
                    lblTotal.Text = "0.00";
                    lblRegistro.Text = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
