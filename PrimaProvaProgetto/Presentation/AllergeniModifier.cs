﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimaProvaProgetto.Model;

namespace PrimaProvaProgetto.Presentation
{
    public partial class AllergeniModifier : UserControl
    {
        public AllergeniModifier()
        {
            InitializeComponent();
            foreach (Allergene all in Ristorante.GetInstance().Allergeni)
            {
                CheckBox cb = new CheckBox();
                cb.Name = "_" + all.Nome + "CheckBox";
                cb.Text = all.Nome;
                cb.Tag = all;
                tableLayoutPanel1.Controls.Add(cb);
                tableLayoutPanel1.RowCount++;
            }
        }

        public List<Allergene> Allergeni
        {
            get
            {
                List<Allergene> res = new List<Allergene>();
                tableLayoutPanel1.Controls.OfType<CheckBox>()
                    .ToList()
                    .FindAll(c => c.Checked)
                    .ForEach(c => res.Add((Allergene)c.Tag));
                return res;
            }
            set
            {
                value.ForEach(all => tableLayoutPanel1.Controls.OfType<CheckBox>()
                    .ToList()
                    .Find(c => c.Tag == all).Checked = true);
            }
        }

    }
}