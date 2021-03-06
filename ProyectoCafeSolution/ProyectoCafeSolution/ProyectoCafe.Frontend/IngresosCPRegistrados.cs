﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCafe.Backend;

namespace ProyectoCafe.Frontend
{
    public partial class IngresosCPRegistrados : Form
    {
        List<Ingresocp> lista;
        Ingresocp objigresosp;
        Lugar objlugar = new Lugar();

        public IngresosCPRegistrados()
        {
            InitializeComponent();
            lista = new List<Ingresocp>();
            objigresosp = new Ingresocp();

            try
            {
                cbxLugar.DataSource = objlugar.Ver();

                cbxLugar.DisplayMember = "Nombre";

                cbxLugar.ValueMember = "Nombre";

                cbxLugar.SelectedItem = null;

                lista = objigresosp.Ver();

                dgvISP.DataSource = lista;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al intentar conectarse con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNumIng.Text))
                {
                    if (string.IsNullOrEmpty(txtDPIoNom.Text))
                    {
                        if (cbxLugar.SelectedItem == null)
                        {
                            lista = objigresosp.BuscarFec(dtpf1.Value, dtpf2.Value);
                            dgvISP.DataSource = lista;
                        }
                        else
                        {
                            lista = objigresosp.BuscarPorLugar(cbxLugar.SelectedValue.ToString(), dtpf1.Value, dtpf2.Value);
                            dgvISP.DataSource = lista;
                        }

                    }
                    else
                    {
                        lista = objigresosp.BuscarDPIoNom(txtDPIoNom.Text.ToUpper(), dtpf1.Value, dtpf2.Value);
                        dgvISP.DataSource = lista;
                    }

                }
                else
                {
                    lista = objigresosp.BuscarNum(txtNumIng.Text);
                    dgvISP.DataSource = lista;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al intentar conectarse con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                txtNumIng.Clear();
                txtDPIoNom.Clear();
                cbxLugar.SelectedItem = null;
                dtpf1.Value = DateTime.Now;
                dtpf2.Value = DateTime.Now;

                lista = objigresosp.Ver();

                dgvISP.DataSource = lista;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error al intentar conectarse con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
