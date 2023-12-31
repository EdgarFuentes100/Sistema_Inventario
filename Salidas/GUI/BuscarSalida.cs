﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salidas.GUI
{
    public partial class BuscarSalida : Form
    {
        public BuscarSalida()
        {
            InitializeComponent();
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = " ";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                    DataTable datos = new DataTable();
                    Reportes.REP.Salidas oReporte = new Reportes.REP.Salidas();
                    datos = DataManager.DBConsultas.VerRegistroSalidas(txtDocumento.Text);
                    oReporte.SetDataSource(datos);
                    Reportes.GUI.VisorSalidas f = new Reportes.GUI.VisorSalidas();
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
                DataTable tEntradas = DataManager.DBConsultas.VerRegistroSalidas(txtDocumento.Text);
                dgvDatos.DataSource = tEntradas;
                dgvDatos.AutoGenerateColumns = false;//Impide generar automaticamente las columnas de encabezado
                                                     //Codigo para mostrar cuantas filas se
                if (dgvDatos.RowCount > 0)
                {
                    dtpFecha.Format = DateTimePickerFormat.Custom;
                    dtpFecha.CustomFormat = "yyyy/MM/dd";
                    txtDui.Text = dgvDatos.Rows[0].Cells["dui"].Value.ToString();
                    txtNombre.Text = dgvDatos.Rows[0].Cells["nombres_cliente"].Value.ToString();
                    dtpFecha.Text = dgvDatos.Rows[0].Cells["fecha_salida"].Value.ToString();
                    txtUsuario.Text = dgvDatos.Rows[0].Cells["usuario"].Value.ToString();
                    lblTotal.Text = dgvDatos.Rows[0].Cells["total"].Value.ToString();
                    lblRegistro.Text = dgvDatos.RowCount.ToString();
                }
                else
                {
                    dtpFecha.Format = DateTimePickerFormat.Custom;
                    dtpFecha.CustomFormat = " ";
                    txtDui.Text = "";
                    txtNombre.Text = "";
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
